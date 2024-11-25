namespace Tron.Server.Persistence.QueryHandlers
{
    public interface IDbQueryHandler
    {
        public void CreateLobby();

        public string[] ReadLobbies();

        public void UpdateLobby(/*Lobby lobby*/);

        public void DeleteLobby(/*Lobby.Id*/);

        public string[] ReadTopTen();

        public void UpdateTopTen(/*Player*/);
    }
}
