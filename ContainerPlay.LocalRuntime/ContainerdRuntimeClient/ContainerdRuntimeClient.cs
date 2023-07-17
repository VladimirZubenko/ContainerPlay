using Containerd.Services.Containers.V1;
using Containerd.Services.Tasks.V1;
using ContainerPlay.Abstract.Models;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Newtonsoft.Json;
using static Containerd.Services.Tasks.V1.Tasks;

namespace ContainerPlay.LocalRuntime.ContainerdRuntimeClient;

public class ContainerdRuntimeClient : IRuntimeClient
{
    private readonly ContainerdRuntimeSettings _containerdRuntimeSettings;
    private readonly Lazy<Containers.ContainersClient> _containersClient;
    private readonly Lazy<TasksClient> _tasksClient;

    public ContainerdRuntimeClient(ContainerdRuntimeSettings containerdRuntimeSettings)
    {
        _containerdRuntimeSettings = containerdRuntimeSettings;

        _containersClient = new Lazy<Containers.ContainersClient>(() =>
        {
            if (string.IsNullOrEmpty(_containerdRuntimeSettings.ContainerdUrl))
                throw new Exception("Empty ContainerdUrl.");

            var endpoint = new Uri(_containerdRuntimeSettings.ContainerdUrl);
            var channel = GrpcChannel.ForAddress(_containerdRuntimeSettings.ContainerdUrl);
            return new Containers.ContainersClient(channel);
        });

        _tasksClient = new Lazy<TasksClient>(() =>
        {
            if (string.IsNullOrEmpty(_containerdRuntimeSettings.ContainerdUrl))
                throw new Exception("Empty ContainerdUrl.");

            var endpoint = new Uri(_containerdRuntimeSettings.ContainerdUrl);
            var channel = GrpcChannel.ForAddress(_containerdRuntimeSettings.ContainerdUrl);
            return new TasksClient(channel);
        });
    }

    public RuntimeType RuntimeType => RuntimeType.Containerd;

    public async Task<IEnumerable<ContainerModel>> GetAll()
    {
        var containersClient = _containersClient.Value;

        var containers = await containersClient.ListAsync(new ListContainersRequest());

        return containers.Containers.Select(x => new ContainerModel
        {
            Name = x?.Id,
            Image = x?.Image,
            IsRunning = null,
            RuntimeType = RuntimeType.Containerd
        }).ToArray();
    }

    public async Task CreateContainer(string name, string image, int[] ports)
    {
        if (string.IsNullOrEmpty(_containerdRuntimeSettings.RuntimeName))
            throw new Exception("Empty RuntimeName.");

        if (string.IsNullOrEmpty(_containerdRuntimeSettings.RuntimeOptionsTypeUrl))
            throw new Exception("Empty RuntimeOptionsTypeUrl.");

        if (string.IsNullOrEmpty(_containerdRuntimeSettings.SpecTypeUrl))
            throw new Exception("Empty SpecTypeUrl.");

        if (string.IsNullOrEmpty(_containerdRuntimeSettings.SpecVersion))
            throw new Exception("Empty SpecVersion.");

        if (string.IsNullOrEmpty(_containerdRuntimeSettings.SpecProcessArgs))
            throw new Exception("Empty SpecProcessArgs.");

        if (string.IsNullOrEmpty(_containerdRuntimeSettings.SpecProcessCwd))
            throw new Exception("Empty SpecProcessCwd.");

        if (string.IsNullOrEmpty(_containerdRuntimeSettings.SpecRootPath))
            throw new Exception("Empty SpecRootPath.");

        var spec = new Spec
        {
            Version = _containerdRuntimeSettings.SpecVersion,
            Process = new Process
            {
                Args = _containerdRuntimeSettings.SpecProcessArgs.Split(' ').ToList(),
                Cwd = _containerdRuntimeSettings.SpecProcessCwd
            },
            Root = new Root
            {
                Path = _containerdRuntimeSettings.SpecRootPath
            }
        };
        var specJson = JsonConvert.SerializeObject(spec);
        var specBytes = ByteString.CopyFromUtf8(specJson);

        var containersClient = _containersClient.Value;
        await containersClient.CreateAsync(new CreateContainerRequest
        {
            Container = new Container
            {
                Id = name,
                Image = image,
                Runtime = new Container.Types.Runtime
                {
                    Name = _containerdRuntimeSettings.RuntimeName,
                    Options = new Any
                    {
                        TypeUrl = _containerdRuntimeSettings.RuntimeOptionsTypeUrl
                    }
                },
                Spec = new Any
                {
                    TypeUrl = _containerdRuntimeSettings.SpecTypeUrl,
                    Value = specBytes
                }
            }
        });
    }

    public async Task DeleteContainer(string name)
    {
        var containersClient = _containersClient.Value;
        var containerId = await GetContainerId(name, containersClient);
        await containersClient.DeleteAsync(new DeleteContainerRequest { Id = containerId });
    }

    public async Task StartContainer(string name)
    {
        var containersClient = _containersClient.Value;
        var containerId = await GetContainerId(name, containersClient);
        var tasksClient = _tasksClient.Value;
        await tasksClient.CreateAsync(new CreateTaskRequest { ContainerId = containerId });
        await tasksClient.StartAsync(new StartRequest { ContainerId = containerId });
    }

    public async Task StopContainer(string name)
    {
        var containersClient = _containersClient.Value;
        var containerId = await GetContainerId(name, containersClient);
        var tasksClient = _tasksClient.Value;
        await tasksClient.KillAsync(new KillRequest { ContainerId = containerId });
        await tasksClient.DeleteAsync(new DeleteTaskRequest { ContainerId = containerId });
    }

    private async Task<string> GetContainerId(string name, Containers.ContainersClient containersClient)
    {
        var containers = await containersClient.ListAsync(new ListContainersRequest());

        return containers.Containers.First(
            x => string.Equals(x.Id, name, StringComparison.InvariantCultureIgnoreCase)).Id;
    }
}
