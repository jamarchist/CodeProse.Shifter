using CodeProse.Shifter.models;
using Nancy;

namespace CodeProse.Shifter.modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = x => Index();
            Get["/index"] = x => Index();
        }

        private Response Index()
        {
            return View["index"];            
        }
    }
}