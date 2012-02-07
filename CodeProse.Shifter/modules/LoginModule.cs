﻿using System;
using CodeProse.Shifter.authentication;
using CodeProse.Shifter.models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Authentication.Forms;

namespace CodeProse.Shifter.modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(IUserRepository users)
        {
            Get["/login"] = x => View["login"];
            Post["/login"] = x =>
            {
                var model = this.Bind<LoginModel>();
                var userId = users.Authenticate(model.Username, model.Password);

                return this.LoginAndRedirect(userId, DateTime.Now.AddDays(7), "~/");
            };
        }
    }
}