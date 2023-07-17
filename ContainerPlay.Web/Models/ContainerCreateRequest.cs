using ContainerPlay.Abstract.Models;

namespace ContainerPlay.Web.Models;

public class ContainerCreateRequest
{
    public string? Name { get; set; }

    public string? Image { get; set; }

    public int[]? Ports { get; set; }

    public RuntimeType RuntimeType { get; set; }
}
