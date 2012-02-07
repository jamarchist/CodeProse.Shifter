using System;
using System.Data.SQLite;
using System.Linq;
using CodeProse.Shifter.domain;
using Dapper;
using Nancy.Authentication.Forms;
using Nancy.Security;
using CodeProse.Shifter.data;

namespace CodeProse.Shifter.authentication
{
    public class SqliteUserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier)
        {
            using (var connection = new SQLiteConnection("Data Source=testdb.db"))
            {
                connection.Open();
                var user = connection.GetUserById(identifier);
                connection.Close();

                return user;
            }
        }
    }
}