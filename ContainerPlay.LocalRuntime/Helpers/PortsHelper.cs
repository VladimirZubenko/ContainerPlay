using System.Net;
using System.Net.Sockets;

namespace ContainerPlay.LocalRuntime.Helpers;

public class PortsHelper
{
    public static int GetFreePort()
    {
        int freePort;
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        freePort = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();

        return freePort;
    }
}
