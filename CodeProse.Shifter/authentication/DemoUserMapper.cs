using System;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace CodeProse.Shifter.authentication
{
    public interface IUserRepository
    {
        Guid Authenticate(string username, string password);
    }

    public class DemoUserMapper : IUserMapper, IUserRepository
    {
        public IUserIdentity GetUserFromIdentifier(Guid indentifier)
        {
            return new DemoUser{ UserName = "demo"};
        }

        public Guid Authenticate(string username, string password)
        {
            return Guid.NewGuid();
        }
    }
}