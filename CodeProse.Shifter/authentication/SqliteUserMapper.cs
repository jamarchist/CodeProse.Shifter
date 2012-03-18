using System;
using CodeProse.Shifter.domain;
using Nancy.Authentication.Forms;
using Nancy.Security;
using CodeProse.Shifter.data;

namespace CodeProse.Shifter.authentication
{
    public class SqliteUserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier)
        {
            using (var database = new Database())
            {
                var user = database.Get<User>(identifier);
                return user;
            }
        }
    }
}