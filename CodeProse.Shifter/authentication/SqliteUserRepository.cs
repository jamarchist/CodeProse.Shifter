using System;
using System.Data.SQLite;
using System.Linq;
using CodeProse.Shifter.domain;
using Dapper;
using CodeProse.Shifter.data;

namespace CodeProse.Shifter.authentication
{
    public class SqliteUserRepository : IUserRepository
    {
        public Guid Authenticate(string username, string password)
        {
            using(var connection = new SQLiteConnection("Data Source=testdb.db"))
            {
                connection.Open();
                var user = connection.GetUserByUsernameAndPassword(username, password);
                connection.Close();

                return Guid.Parse(user.Id);
            }
        }
    }
}