using System;
using System.Collections.Generic;
using Nancy.Authentication.Forms;
using Nancy.Security;
using System.Linq;

namespace CodeProse.Shifter.authentication
{
    public interface IUserRepository
    {
        Guid Authenticate(string username, string password);
    }

    public class DemoUserMapper : IUserMapper, IUserRepository
    {
        private static readonly IDictionary<string, DemoUser> users = new Dictionary<string, DemoUser>(); 

        public IUserIdentity GetUserFromIdentifier(Guid identifier)
        {
            return users.Values.First(v => v.Id == identifier.ToString());
        }

        public Guid Authenticate(string username, string password)
        {
            if (!users.ContainsKey(username))
            {
                users.Add(username, new DemoUser { Id = Guid.NewGuid().ToString(), UserName = username });
            }

            return Guid.Parse(users[username].Id);
        }
    }
}