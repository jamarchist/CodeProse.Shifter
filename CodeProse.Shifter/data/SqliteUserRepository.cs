using System;

namespace CodeProse.Shifter.data
{
    public class SqliteUserRepository : IUserRepository
    {
        public Guid Authenticate(string username, string password)
        {
            using (var database = new Database())
            {
                var user = database.GetUserByNameAndPassword(username, password);
                if (user == null)
                {
                    return Guid.Empty;
                }

                return user.Id;
            }
        }
    }
}