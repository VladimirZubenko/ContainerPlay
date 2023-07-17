using ContainerPlay.Abstract;
using ContainerPlay.Abstract.Models;

namespace ContainerPlay.LocalRuntime;

public class LocalContainerRuntime : IContainerRuntime
{
    private readonly IEnumerable<IRuntimeClient> _runtimeClients;
    private readonly LocalContainersSynchronizer _localContainersSynchronizer;

    public LocalContainerRuntime(
        IEnumerable<IRuntimeClient> runtimeClients,
        LocalContainersSynchronizer localContainersSynchronizer)
    {
        _runtimeClients = runtimeClients;
        _localContainersSynchronizer = localContainersSynchronizer;
    }

    public async Task<IEnumerable<ContainerModel>> GetAll()
        => (await Task.WhenAll(_runtimeClients.Select(x => x.GetAll()))).SelectMany(x => x);

    public async Task CreateContainer(string name, string image, int[] ports, RuntimeType runtimeType)
    {
        var existingClient = await GetClientByContainerName(name);
        if (existingClient != null)
            throw new Exception($"Container {name} is already exists.");

        var client = _runtimeClients.FirstOrDefault(x => x.RuntimeType == runtimeType);
        if (client == null)
            throw new Exception($"Can't find container runtime client {runtimeType}.");

        if (!_localContainersSynchronizer.Instance.TryAdd(name, client))
            throw new Exception($"Container {name} is already being created.");

        try
        {
            await client.CreateContainer(name, image, ports);
        }
        catch
        {
            _localContainersSynchronizer.Instance.Remove(name, out var _);
            throw;
        }
    }

    public async Task DeleteContainer(string name)
    {
        var client = await GetClientByContainerName(name) ?? throw new Exception($"Can't find container {name}.");
        await client.DeleteContainer(name);
        _localContainersSynchronizer.Instance.Remove(name, out var _);
    }        

    public async Task StartContainer(string name)
    {
        var client = await GetClientByContainerName(name) ?? throw new Exception($"Can't find container {name}.");
        await client.StartContainer(name);
    }

    public async Task StopContainer(string name)
    {
        var client = await GetClientByContainerName(name) ?? throw new Exception($"Can't find container {name}.");
        await client.StopContainer(name);
    }

    private async Task<IRuntimeClient?> GetClientByContainerName(string name, bool throwErrorIfMissing = true)
    {
        foreach (var runtimeClient in _runtimeClients)
        {
            var containers = await runtimeClient.GetAll();

            if (containers.Any(x => string.Equals(name, x.Name, StringComparison.InvariantCultureIgnoreCase)))
                return runtimeClient;
        }

        return null;
    }
}
