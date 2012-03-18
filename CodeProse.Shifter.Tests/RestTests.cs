using CodeProse.Shifter.authentication;
using Nancy.Responses;
using Nancy.Testing;

namespace CodeProse.Shifter.Tests
{
    public abstract class RestTests
    {
        private readonly Browser browser = new Browser(new BootStrapper());

        protected virtual TEntity Get<TEntity>(string resource)
        {
            var response = browser.Get(resource, with => with.HttpRequest());
            return response.Body.AsJson<TEntity>();
        }

        protected virtual BrowserResponse Post<TEntity>(string resource, TEntity value)
        {
            return browser.Post(resource, with =>
            {
                with.HttpRequest();
                with.JsonBody(value, new DefaultJsonSerializer());
            });
        }
    }
}