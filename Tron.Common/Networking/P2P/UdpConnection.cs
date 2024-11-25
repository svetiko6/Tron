using System.Net;
using System.Net.Sockets;

namespace Tron.Common.Networking.P2P
{
    public class UdpConnection
    {
        public UdpClient Local { get; private set; }

        private IPEndPoint _remote;

        public ref IPEndPoint Remote
        {
            get
            {
                return ref _remote;
            }
        }

        public UdpConnection(UdpClient local, ref IPEndPoint remote)
        {
            Local = local;
            _remote = remote;
            Remote = _remote;
        }
    }
}
