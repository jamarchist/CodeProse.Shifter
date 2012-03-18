using System;

namespace CodeProse.Shifter.data
{
    public interface IUserRepository
    {
        Guid Authenticate(string username, string password);
    }
}