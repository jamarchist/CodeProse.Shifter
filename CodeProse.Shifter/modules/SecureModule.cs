using Nancy;
using Nancy.Security;

namespace CodeProse.Shifter.modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
        {
            this.RequiresAuthentication();
        }

        public SecureModule(string path) : base(path)
        {
            this.RequiresAuthentication();
        }
    }
}