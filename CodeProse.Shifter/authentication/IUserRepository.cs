using System;

namespace CodeProse.Shifter.authentication
{
    public interface IUserRepository
    {
        Guid Authenticate(string username, string password);
    }
}