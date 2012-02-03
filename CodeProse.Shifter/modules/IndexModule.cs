using CodeProse.Shifter.models;
using Nancy;

namespace CodeProse.Shifter.modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/index.cshtml"] = x =>
                                       {
                                           var model = new IndexModel();
                                           return View["index.cshtml", model];
                                       };
        }
    }
}