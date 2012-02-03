using Nancy;

namespace CodeProse.Shifter.modules
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = x => View["index.htm"];
        }
    }
}