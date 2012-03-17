using System;
using System.Dynamic;
using CodeProse.Shifter.authentication;
using CodeProse.Shifter.models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Authentication.Forms;
using Nancy.Extensions;

namespace CodeProse.Shifter.modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(IUserRepository users)
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
                var userId = users.Authenticate(model.Username, model.Password);

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