using Nancy.Security;

namespace CodeProse.Shifter.modules
{
    public class SecureModule : ShifterModule
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