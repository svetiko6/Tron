using System.Net;
using System.Net.Sockets;
using Tron.Common.Networking.P2P;

namespace Tron.Server.Networking
{
    internal class UdpMulticaster
    {
        public UdpClient Local { get; private set; }

        public List<IPEndPoint> Remotes { get; private set; }

        internal UdpMulticaster(UdpConnection connection)
        {
            Local = connection.Local;
            Remotes = new List<IPEndPoint>();
            Remotes.Add(connection.Remote);
        }
    }
}
