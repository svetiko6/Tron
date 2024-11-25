using Tron.Common.Messages.General;
using Tron.Common.Networking.P2P;
using Tron.Server.Networking;
using Tron.Server.Persistence.QueryHandlers;

namespace Tron.Server.Core
{
    internal class Session
    {
        private IDbQueryHandler _queryHandler;
        private UdpUnicaster _unicaster;

        internal Session(IDbQueryHandler queryHandler, UdpUnicaster unicaster)
        {
            _queryHandler = queryHandler;
            _unicaster = unicaster;
        }

        internal void Run()
        {
            while (true)
            {
                Message message = _unicaster.Receive();

                message.Handle();

                switch (message.Header)
                {
                    case Header.CreateLobby:

                        CreateLobbyMessage createLobby = (CreateLobbyMessage)message;
                        int maxPlayers = createLobby.MaxPlayers;
                        bool @private = createLobby.Private;
                        string password = createLobby.Password;

                        UdpMulticaster multicaster = new UdpMulticaster(_unicaster.Connection);

                        Lobby lobby = new Lobby(maxPlayers, @private, password);
                        _queryHandler.CreateLobby(lobby);

                        break;

                    case Header.GetLobbies:

                        GetLobbiesMessage getLobbies = (GetLobbiesMessage)message;
                        int maxPlayers1 = getLobbies.MaxPlayers;
                        bool @private1 = getLobbies.Private;

                        List<string> lobbies = _queryHandler.ReadLobbies(maxPlayers1, @private1);
                        ReturnLobbiesMessage response = new ReturnLobbiesMessage(Header.ReturnLobbies, lobbies);
                        _unicaster.Send(response);

                        break;

                    case Header.JoinLobby:

                        JoinLobbyMessage concreteMessage = (JoinLobbyMessage)message;

                        break;

                }
            }
        }
    }
}
