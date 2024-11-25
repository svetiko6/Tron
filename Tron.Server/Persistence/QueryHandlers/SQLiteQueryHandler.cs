namespace Tron.Server.Persistence.QueryHandlers
{
    internal class SQLiteQueryHandler : IDbQueryHandler
    {
        private string _connectionString;

        internal SQLiteQueryHandler(string path)
        {
            _connectionString = "Data Source=" + path + ";Version=3";
        }
    }
}
