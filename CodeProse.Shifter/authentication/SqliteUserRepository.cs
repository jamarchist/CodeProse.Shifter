using System;
using CodeProse.Shifter.data;

namespace CodeProse.Shifter.authentication
{
    public class SqliteUserRepository : IUserRepository
    {
        public Guid Authenticate(string username, string password)
        {
            using (var database = new Database())
            {
                var user = database.Users.GetUserByUsernameAndPassword(username, password);
                return Guid.Parse(user.Id);
            }
        }
    }
}