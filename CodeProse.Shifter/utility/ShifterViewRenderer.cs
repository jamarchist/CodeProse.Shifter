using Nancy;

namespace CodeProse.Shifter.utility
{
    public class ShifterViewRenderer
    {
        private readonly NancyModule module;

        public ShifterViewRenderer(NancyModule module)
        {
            this.module = module;
        }

        public Response this[string viewName, dynamic model]
        {
            get
            {
                var username = module.Context.CurrentUser.UserName;
                model.UserName = username;
                return module.View[viewName, model];
            }
        }
    }
}