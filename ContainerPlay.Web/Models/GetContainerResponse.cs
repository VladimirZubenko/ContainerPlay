namespace ContainerPlay.Web.Models;

public class GetContainerResponse
{
    public string? Name { get; set; }

    public string? Image { get; set; }

    public bool? IsRunning { get; set; }

    public string? RuntimeType { get; set; }
}
