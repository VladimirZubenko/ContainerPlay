namespace ContainerPlay.LocalRuntime.ContainerdRuntimeClient;

public class Spec
{
    public string? Version { get; set; }
    public Process? Process { get; set; }
    public Root? Root { get; set; }
}

public class Process
{
    public List<string>? Args { get; set; }
    public string? Cwd { get; set; }
}

public class Root
{
    public string? Path { get; set; }
}
