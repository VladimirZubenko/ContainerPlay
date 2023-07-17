namespace ContainerPlay.Abstract.Models;

public class ContainerModel
{
    public string? Name { get; set; }

    public string? Image { get; set; }

    public bool? IsRunning { get; set; }

    public RuntimeType RuntimeType { get; set; }
}
