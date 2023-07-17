using ContainerPlay.Abstract.Models;
using ContainerPlay.LocalRuntime.Helpers;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace ContainerPlay.LocalRuntime.DockerRuntimeClient;

public class DockerRuntimeClient : IRuntimeClient
{
    private readonly DockerRuntimeSettings _dockerRuntimeSettings;
    private readonly Lazy<DockerClientConfiguration> _clientConfiguration;

    public DockerRuntimeClient(DockerRuntimeSettings dockerRuntimeSettings)
    {
        _dockerRuntimeSettings = dockerRuntimeSettings;

        _clientConfiguration = new Lazy<DockerClientConfiguration>(() =>
        {
            if (string.IsNullOrEmpty(_dockerRuntimeSettings.DockerUrl))
                throw new Exception("Empty DockerUrl.");

            var endpoint = new Uri(_dockerRuntimeSettings.DockerUrl);
            return new DockerClientConfiguration(endpoint);
        });
    }

    public RuntimeType RuntimeType => RuntimeType.Docker;

    public async Task<IEnumerable<ContainerModel>> GetAll()
    {
        if (string.IsNullOrEmpty(_dockerRuntimeSettings.RunningState))
            throw new Exception("Empty RunningState.");

        using var client = _clientConfiguration.Value.CreateClient();

        var containers = await client.Containers.ListContainersAsync(
            new ContainersListParameters() { All = true });

        return containers.Select(x => new ContainerModel
        {
            Name = x?.Names?.FirstOrDefault()?.Substring(1),
            Image = x?.Image,
            IsRunning = string.Equals(x?.State, _dockerRuntimeSettings.RunningState, StringComparison.InvariantCultureIgnoreCase),
            RuntimeType = RuntimeType.Docker
        }).ToArray();
    }

    public async Task CreateContainer(string name, string image, int[] ports)
    {
        using var client = _clientConfiguration.Value.CreateClient();
        await client.Containers.CreateContainerAsync(new CreateContainerParameters
        {
            Name = name,
            Image = image,
            ExposedPorts = ports.ToDictionary(x => x.ToString(), x => default(EmptyStruct)),
            HostConfig = new HostConfig
            {
                PortBindings = ports.ToDictionary(
                    x => x.ToString(),
                    x =>
                    {
                        IList<PortBinding> res;
                        var freePort = PortsHelper.GetFreePort().ToString();
                        res = new List<PortBinding> { new PortBinding { HostPort = freePort } };
                        return res;
                    })
            }
        });
    }

    public async Task DeleteContainer(string name)
    {
        using var client = _clientConfiguration.Value.CreateClient();
        var containerId = await GetContainerId(name, client);
        await client.Containers.RemoveContainerAsync(containerId, new ContainerRemoveParameters { Force = true });
    }

    public async Task StartContainer(string name)
    {
        using var client = _clientConfiguration.Value.CreateClient();
        var containerId = await GetContainerId(name, client);
        await client.Containers.StartContainerAsync(containerId, new ContainerStartParameters());
    }

    public async Task StopContainer(string name)
    {
        using var client = _clientConfiguration.Value.CreateClient();
        var containerId = await GetContainerId(name, client);
        await client.Containers.StopContainerAsync(containerId, new ContainerStopParameters());
    }

    private async Task<string> GetContainerId(string name, DockerClient client)
    {
        var containers = await client.Containers.ListContainersAsync(
            new ContainersListParameters() { All = true });

        return containers.First(
            x => x.Names.Any(n => string.Equals(n, $"/{name}", StringComparison.InvariantCultureIgnoreCase))).ID;
    }
}
