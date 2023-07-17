using ContainerPlay.Abstract.Models;

namespace ContainerPlay.Abstract;

public interface IContainerRuntime
{
    Task<IEnumerable<ContainerModel>> GetAll();

    Task CreateContainer(string name, string image, int[] ports, RuntimeType runtimeType);

    Task DeleteContainer(string name);

    Task StartContainer(string name);

    Task StopContainer(string name);
}
