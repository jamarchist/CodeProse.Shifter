using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using CodeProse.Shifter.models;

namespace CodeProse.Shifter.modules
{
    public class HomeModule : SecureModule
    {
        public HomeModule()
        {
            Get["/"] = x => Index();
            Get["/home"] = x => Index();
        }

        private Response Index()
        {
            var model = new HomeModel();
            model.UserName = Context.CurrentUser.UserName;
            return View["home", model];            
        }
    }
}