using CodeProse.Shifter.models;
using Nancy;

namespace CodeProse.Shifter.modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule()
        {
            Get["/"] = x => Index();
            Get["/index"] = x => Index();
        }

        private Response Index()
        {
            var model = new IndexModel();
            model.UserName = Context.CurrentUser.UserName;
            return View["index", model];            
        }
    }
}