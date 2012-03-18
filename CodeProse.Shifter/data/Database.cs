using System.Data;
using System.Data.SQLite;

namespace CodeProse.Shifter.data
{
    public class Database : IDatabase
    {
        private IDbConnection connection;

        public Database()
        {
            connection = new SQLiteConnection("Data Source=testdb.db");
            connection.Open();
        }

        public Database(IDbConnection connection)
        {
            this.connection = connection;
            connection.Open();
        }

        public IDbConnection Connection
        {
            get { return connection; }
        }

        public void Dispose()
        {
            try
            {
                connection.Close();
            }
            finally 
            {
                connection.Dispose();
            }
        }
    }
}