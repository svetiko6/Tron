using Tron.Common.Messages.General;
using Tron.Common.Networking.Extensions;

namespace Tron.Common.Networking.P2P
{
    public class UdpUnicaster
    {
        public UdpConnection Connection { get; private set; }

        public UdpUnicaster(UdpConnection connection)
        {
            Connection = connection;
        }

        public void Send(Message message)
        {
            Connection.Local.SendString(Connection.Remote, message.ToString());
        }

        public Message Receive()
        {
            string message = Connection.Local.ReceiveString(ref Connection.Remote);
            return new Message(message);
        }
    }
}
