using CodeProse.Shifter.models;
using Nancy;

namespace CodeProse.Shifter.modules
{
    public class ShifterModule : NancyModule
    {
        public ShifterModule()
        {   
        }

        public ShifterModule(string path) : base(path)
        {
        }

        protected void BindMasterModel(MasterModel model)
        {
            model.UserName = Context.CurrentUser.UserName;
        }
    }
}