using System;
using System.Data.SQLite;
using System.Linq;
using CodeProse.Shifter.domain;
using Dapper;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace CodeProse.Shifter.authentication
{
    public class SqliteUserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier)
        {
            using (var connection = new SQLiteConnection("Data Source=testdb.db"))
            {
                connection.Open();
                var user = connection.Query<User>("SELECT * FROM Users WHERE Id = @Id LIMIT 1", new {Id = identifier.ToString()}).First();
                connection.Close();

                return new DemoUser {Id = user.Id, UserName = user.Username};
            }
        }
    }
}