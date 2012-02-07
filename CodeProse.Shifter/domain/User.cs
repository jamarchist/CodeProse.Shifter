using System.Collections.Generic;
using Nancy.Security;

namespace CodeProse.Shifter.domain
{
    public class User : IUserIdentity
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public IEnumerable<string> Claims { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}