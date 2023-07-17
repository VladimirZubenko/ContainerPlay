using ContainerPlay.Abstract;
using ContainerPlay.Abstract.Models;
using k8s;
using k8s.Models;

namespace ContainerPlay.Gke;

public class GkeClient : IContainerRuntime
{
    private readonly GkeSettings _gkeSettings;
    private readonly Lazy<KubernetesClientConfiguration> _clientConfiguration;

    public GkeClient(GkeSettings gkeSettings)
    {
        _gkeSettings = gkeSettings;

        _clientConfiguration = new Lazy<KubernetesClientConfiguration>(() =>
        {
            return KubernetesClientConfiguration.BuildConfigFromConfigFile("config");
        });
    }

    public async Task<IEnumerable<ContainerModel>> GetAll()
    {
        if (string.IsNullOrEmpty(_gkeSettings.DefaultNamespace))
            throw new Exception("Empty DefaultNamespace.");

        using var client = new Kubernetes(_clientConfiguration.Value);
        var allPods = await client.ListNamespacedDeploymentAsync(_gkeSettings.DefaultNamespace);

        return allPods.Items.Select(x => new ContainerModel
        {
            Name = x?.Metadata?.Name,
            Image = x?.Spec?.Template?.Spec?.Containers?.FirstOrDefault()?.Image,
            IsRunning = x?.Spec?.Replicas > 0,
            RuntimeType =
                (x?.Spec?.Template?.Spec?.NodeSelector?.TryGetValue("pool", out var pool) == true ? pool : string.Empty)
                    == _gkeSettings.ContainerdPool
                ? RuntimeType.Containerd
                : RuntimeType.Docker
        }).ToArray();
    }

    public async Task CreateContainer(string name, string image, int[] ports, RuntimeType runtimeType)
    {
        if (string.IsNullOrEmpty(_gkeSettings.DefaultNamespace))
            throw new Exception("Empty DefaultNamespace.");

        if (string.IsNullOrEmpty(_gkeSettings.ContainerdPool))
            throw new Exception("Empty ContainerdPool.");

        if (string.IsNullOrEmpty(_gkeSettings.DockerPool))
            throw new Exception("Empty DockerPool.");

        var deployment = new V1Deployment
        {
            ApiVersion = "apps/v1",
            Kind = "Deployment",
            Metadata = new V1ObjectMeta
            {
                Name = name,
                NamespaceProperty = _gkeSettings.DefaultNamespace
            },
            Spec = new V1DeploymentSpec
            {
                Replicas = 1,
                Selector = new V1LabelSelector
                {
                    MatchLabels = new Dictionary<string, string>
                    {
                        { "app", name }
                    }
                },
                Template = new V1PodTemplateSpec
                {
                    Metadata = new V1ObjectMeta
                    {
                        Labels = new Dictionary<string, string>
                        {
                            { "app", name }
                        }
                    },
                    Spec = new V1PodSpec
                    {
                        Containers = new List<V1Container>
                        {
                            new V1Container
                            {
                                Name = name,
                                Image = image,
                                Ports = ports.Select(x => new V1ContainerPort { ContainerPort = x }).ToList()
                            }
                        },
                        NodeSelector = new Dictionary<string, string>
                        {
                            {"pool", runtimeType == RuntimeType.Containerd ? _gkeSettings.ContainerdPool : _gkeSettings.DockerPool }
                        }
                     }
                 }
            }
        };

        using var client = new Kubernetes(_clientConfiguration.Value);
        await client.CreateNamespacedDeploymentAsync(deployment, _gkeSettings.DefaultNamespace);
    }

    public async Task DeleteContainer(string name)
    {
        if (string.IsNullOrEmpty(_gkeSettings.DefaultNamespace))
            throw new Exception("Empty DefaultNamespace.");

        using var client = new Kubernetes(_clientConfiguration.Value);
        await client.DeleteNamespacedDeploymentAsync(name, _gkeSettings.DefaultNamespace);
    }

    public Task StartContainer(string name) => SetReplicasCount(name, 1);

    public Task StopContainer(string name) => SetReplicasCount(name, 0);

    private async Task SetReplicasCount(string name, int count)
    {
        if (string.IsNullOrEmpty(_gkeSettings.DefaultNamespace))
            throw new Exception("Empty DefaultNamespace.");

        using var client = new Kubernetes(_clientConfiguration.Value);
        var deployment = await client.ReadNamespacedDeploymentAsync(name, _gkeSettings.DefaultNamespace);
        deployment.Spec.Replicas = count;
        await client.ReplaceNamespacedDeploymentAsync(deployment, name, _gkeSettings.DefaultNamespace);
    }
}
