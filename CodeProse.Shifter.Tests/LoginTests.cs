using CodeProse.Shifter.authentication;
using Xunit;
using Nancy.Testing;

namespace CodeProse.Shifter.Tests
{
    public class LoginTests
    {
        [Fact]
        public void CanGetLoginPage()
        {
            var browser = new Browser(new BootStrapper());
            var response = browser.Get("/login", with => with.HttpRequest());

            response.Body["form[action='login']"].ShouldExist();
        }

        [Fact]
        public void CanLogin()
        {
            var browser = new Browser(new BootStrapper());
            var response = browser.Post("/login", with =>
                                       {
                                           with.HttpRequest();
                                           with.FormValue("Username", "demo");
                                           with.FormValue("Password", "demo");
                                       });

            response.ShouldHaveRedirectedTo("/");
            response.Body["h1"].ShouldContain("Welcome to Shifter");
        }
    }
}
