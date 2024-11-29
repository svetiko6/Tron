using System.Net;
using System.Net.Sockets;
using Tron.Common.Messages.General;
using Tron.Common.Networking.Extensions;

namespace Tron.Common.Networking.P2P
{
    public class UdpUnicaster
    {
        public UdpClient Local { get; private set; }

        public IPEndPoint Remote { get; private set; }

        public UdpUnicaster(UdpClient local, IPEndPoint remote)
        {
            Local = local;
            Remote = remote;
        }

        public void Send(Message message)
        {
            Local.SendString(Remote, message.ToString());
        }

        public Message Receive()
        {
            string message = Local.ReceiveString(Remote);
            return new Message(message);
        }
    }
}
