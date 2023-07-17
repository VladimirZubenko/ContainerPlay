using System.Collections.Concurrent;

namespace ContainerPlay.LocalRuntime;

public sealed class LocalContainersSynchronizer
{
    public ConcurrentDictionary<string, IRuntimeClient> Instance { get; } =
        new ConcurrentDictionary<string, IRuntimeClient>(StringComparer.InvariantCultureIgnoreCase);
}
