using System;
using System.Dynamic;
using CodeProse.Shifter.data;
using CodeProse.Shifter.models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Authentication.Forms;
using Nancy.Extensions;
using CodeProse.Shifter.data.queries;

namespace CodeProse.Shifter.modules
{
    public class LoginModule : ShifterModule
    {
        public LoginModule()
        {
            Get["/login"] = x =>
            {
                dynamic model = new ExpandoObject();
                model.LoginAttemptFailed = this.Request.Query.error.HasValue;

                return View["login", model];
            };

            Post["/login"] = x =>
            {
                var model = this.Bind<LoginModel>();
                var userId = Query(db => db.GetUserId(model.Username, model.Password));

                if (userId == Guid.Empty)
                {
                    return Context.GetRedirect("~/login?error=true");
                }

                return this.LoginAndRedirect(userId, DateTime.Now.AddDays(7), "~/home");
            };

            Get["/logout"] = x =>
            {
                return this.LogoutAndRedirect("~/index");
            };
        }
    }
}