using System;
using CodeProse.Shifter.authentication;
using CodeProse.Shifter.data;
using Nancy.Responses;
using Nancy.Testing;

namespace CodeProse.Shifter.Tests
{
    public abstract class RestTests
    {
        private readonly Browser browser = new Browser(new BootStrapper());

        protected virtual TEntity Get<TEntity>(string resource)
        {
            var response = Login().Then.Get(resource, with => with.HttpRequest());
            return response.Body.AsJson<TEntity>();
        }

        protected virtual BrowserResponse Post<TEntity>(string resource, TEntity value)
        {
            return Login().Then.Post(resource, with =>
            {
                with.HttpRequest();
                with.JsonBody(value, new DefaultJsonSerializer());
            });
        }

        protected virtual BrowserResponse Delete(string resource)
        {
            return Login().Then.Delete(resource, with => with.HttpRequest());
        }

        protected virtual TEntity Query<TEntity>(Func<IDatabase, TEntity> query)
        {
            using (var database = new Database())
            {
                return query(database);
            }
        }

        private BrowserResponse Login()
        {
            return browser.Post("/login", with =>
                                {
                                    with.HttpRequest();
                                    with.FormValue("Username", "demo");
                                    with.FormValue("Password", "demo");
                                });
        }
    }
}