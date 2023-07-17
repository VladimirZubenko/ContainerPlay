namespace ContainerPlay.LocalRuntime.ContainerdRuntimeClient;

public class ContainerdRuntimeSettings
{
    public string? ContainerdUrl { get; set; }

    public string? RuntimeName { get; set; }

    public string? RuntimeOptionsTypeUrl { get; set; }

    public string? SpecTypeUrl { get; set; }

    public string? SpecVersion { get; set; }

    public string? SpecProcessArgs { get; set; }

    public string? SpecProcessCwd { get; set; }

    public string? SpecRootPath { get; set; }
}
