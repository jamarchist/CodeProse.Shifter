using System;
using System.Data.SQLite;
using System.Linq;
using CodeProse.Shifter.domain;
using Dapper;

namespace CodeProse.Shifter.authentication
{
    public class SqliteUserRepository : IUserRepository
    {
        public Guid Authenticate(string username, string password)
        {
            using(var connection = new SQLiteConnection("Data Source=testdb.db"))
            {
                connection.Open();
                var user = connection.Query<User>("SELECT * FROM Users WHERE Username = @Username AND Password = @Password LIMIT 1", new { Username = username, Password = password }).FirstOrDefault();
                connection.Close();

                return Guid.Parse(user.Id);
            }
        }
    }
}