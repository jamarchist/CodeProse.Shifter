using CodeProse.Shifter.models;

namespace CodeProse.Shifter.modules
{
    public class ViewModule : SecureModule
    {
        public ViewModule() : base("/views")
        {
            Get["/{view}"] = x =>
            {
                var model = new MasterModel();
                BindMasterModel(model);
                return View[x.view.ToString(), model];
            };
        }
    }
}