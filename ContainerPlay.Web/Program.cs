using ContainerPlay.Abstract;
using ContainerPlay.Gke;
using ContainerPlay.LocalRuntime;
using ContainerPlay.LocalRuntime.ContainerdRuntimeClient;
using ContainerPlay.LocalRuntime.DockerRuntimeClient;
using ContainerPlay.Web.Infrastructure;

var gcloudPath = GetValue("google-cloud-sdk-path");
var path = Environment.GetEnvironmentVariable("PATH");
if (path != null && !path.Split(Path.PathSeparator).Contains(gcloudPath))
{
    var newPath = string.Join(Path.PathSeparator.ToString(), path, gcloudPath);
    Environment.SetEnvironmentVariable("PATH", newPath);
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<IContainerRuntime, LocalContainerRuntime>();
builder.Services.AddSingleton<LocalContainersSynchronizer>();
builder.Services.AddTransient<IRuntimeClient, ContainerdRuntimeClient>();
builder.Services.AddTransient<IRuntimeClient, DockerRuntimeClient>();

builder.Services.AddSingleton(
            x => new ApplicationSettings
            {
                AccessSecretToken = GetValue(nameof(ApplicationSettings.AccessSecretToken)) ?? "token_value"
            });

builder.Services.AddSingleton(
    x => new GkeSettings
    {
        DefaultNamespace = GetValue(nameof(GkeSettings.DefaultNamespace)),
        ContainerdPool = GetValue(nameof(GkeSettings.ContainerdPool)),
        DockerPool = GetValue(nameof(GkeSettings.DockerPool)),
    });

builder.Services.AddSingleton(
    x => new ContainerdRuntimeSettings
    {
        ContainerdUrl = GetValue(nameof(ContainerdRuntimeSettings.ContainerdUrl)) ?? "http://192.168.64.4:5001",
        RuntimeName = GetValue(nameof(ContainerdRuntimeSettings.RuntimeName)) ?? "io.containerd.runc.v2",
        RuntimeOptionsTypeUrl = GetValue(nameof(ContainerdRuntimeSettings.RuntimeOptionsTypeUrl)) ?? "containerd.runc.v1.Options",
        SpecTypeUrl = GetValue(nameof(ContainerdRuntimeSettings.SpecTypeUrl)) ?? "types.containerd.io/opencontainers/runtime-spec/1/Spec",
        SpecVersion = GetValue(nameof(ContainerdRuntimeSettings.SpecVersion)) ?? "1.0.1",
        SpecProcessArgs = GetValue(nameof(ContainerdRuntimeSettings.SpecProcessArgs)) ?? "/docker-entrypoint.sh",
        SpecProcessCwd = GetValue(nameof(ContainerdRuntimeSettings.SpecProcessCwd)) ?? "/",
        SpecRootPath = GetValue(nameof(ContainerdRuntimeSettings.SpecRootPath)) ?? "rootfs"
    });

builder.Services.AddSingleton(
    x => new DockerRuntimeSettings
    {
        DockerUrl = GetValue(nameof(DockerRuntimeSettings.DockerUrl)) ?? "unix:///var/run/docker.sock",
        RunningState = GetValue(nameof(DockerRuntimeSettings.RunningState)) ?? "running"
    });

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static string? GetValue(string key) => Environment.GetEnvironmentVariable(key);
