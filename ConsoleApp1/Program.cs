using System.Net;
using System.Net.Sockets;
using System.Text;
using Tron.Common.Config.Utils;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(point);

            SocketReader reader = new SocketReader();
            (string address, int port) = reader.Read(@"../../../../Tron.Common/Config/ServerSocket.txt");
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(address), port);
            byte[] buffer = new byte[1024];
            udpClient.Send(buffer, server);
            
            buffer = udpClient.Receive(ref server);
            string message = Encoding.UTF8.GetString(buffer);
            string[] splt = message.Split('/');

            Console.WriteLine($"received new server point {splt[0]} {splt[1]}");

            IPAddress address1 = IPAddress.Parse(splt[0]);
            int port1 = int.Parse(splt[1]);
            IPEndPoint server1 = new IPEndPoint(address1, port1);
            udpClient.Connect(server1);
            buffer = Encoding.UTF8.GetBytes("HUI");
            udpClient.Send(buffer);
            Console.WriteLine("Sent HUI-message to a new server point");
        }
    }
}
