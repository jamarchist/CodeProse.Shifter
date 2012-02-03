using CodeProse.Shifter.models;
using Nancy;

namespace CodeProse.Shifter.modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = x => Index();
            Get["/index.cshtml"] = x => Index();
        }

        private Response Index()
        {
            var model = new IndexModel();
            return View["index.cshtml", model];            
        }
    }
}