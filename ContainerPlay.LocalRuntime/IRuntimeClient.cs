using ContainerPlay.Abstract.Models;

namespace ContainerPlay.LocalRuntime;

public interface IRuntimeClient
{
    RuntimeType RuntimeType { get; }

    Task<IEnumerable<ContainerModel>> GetAll();

    Task CreateContainer(string name, string image, int[] ports);

    Task DeleteContainer(string name);

    Task StartContainer(string name);

    Task StopContainer(string name);
}
