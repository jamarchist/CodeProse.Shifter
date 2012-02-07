using System.Data;
using System.Data.SQLite;

namespace CodeProse.Shifter.data
{
    public interface IDatabase
    {
        IDbConnection Connection { get; }
    }

    public class Database : IDatabase
    {
        private readonly IDbConnection connection = new SQLiteConnection("Data Source=testdb.db");

        public Database()
        {
            connection.Open();
        }

        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}