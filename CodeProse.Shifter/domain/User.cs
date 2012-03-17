using System;
using System.Collections.Generic;
using Nancy.Security;

namespace CodeProse.Shifter.domain
{
    public class User : IUserIdentity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<string> Claims { get; set; }
        public IEnumerable<Shift> Shifts { get; set; }
    }
}