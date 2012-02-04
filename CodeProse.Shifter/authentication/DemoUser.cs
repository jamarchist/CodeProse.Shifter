using System.Collections.Generic;
using Nancy.Security;

namespace CodeProse.Shifter.authentication
{
    public class DemoUser : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}