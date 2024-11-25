using Tron.Common.Config.Utilities;
using Tron.Server.Core;
using Tron.Server.Persistence.QueryHandlers;

namespace Tron.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SocketReader reader = new SocketReader();
            (string address, int port) socket = reader.Read(@"../../../../Tron.Common/Config/Data/ServerSocket.txt");

            IDbQueryHandler dbQueryHandler = new SQLiteQueryHandler(@"../../../Persistence/Data/tron.db");            

            Application application = new Application(dbQueryHandler, socket);
            application.Run();
        }
    }
}
