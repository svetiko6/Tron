using System.Net;
using System.Net.Sockets;

namespace Tron.Server.Networking.P2MP
{
    internal class UdpMulticaster
    {
        public UdpClient Local { get; private set; }

        public List<IPEndPoint> Remotes { get; private set; }

        internal UdpMulticaster(UdpClient local, params IPEndPoint[] remotes)
        {
            Local = local;
            Remotes = [.. remotes];
        }
    }
}
