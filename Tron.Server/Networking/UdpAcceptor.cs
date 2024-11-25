using System.Net;
using System.Net.Sockets;
using Tron.Common.Networking.P2P;

namespace Tron.Server.Networking
{
    internal class UdpAcceptor
    {
        private readonly UdpClient _acceptor;
        private readonly IPAddress _address;
        private int _availablePort;
        
        internal UdpAcceptor(IPEndPoint point)
        {
            _acceptor = new UdpClient(point);
            _address = point.Address;
            _availablePort = point.Port + 1;
        }

        internal UdpConnection Accept()
        {
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            _ = _acceptor.Receive(ref client);

            UdpClient server = ProvideUdpClient();

            return new UdpConnection(server, ref client);
        }

        private UdpClient ProvideUdpClient()
        {
            UdpClient? server = null;
            bool portAvailable = false;

            while (!portAvailable)
            {
                try
                {
                    server = new UdpClient(_availablePort);
                    portAvailable = true;
                }
                catch (SocketException)
                {
                    ++_availablePort;
                }

                ++_availablePort;
            }

            return server!;
        }
    }
}
