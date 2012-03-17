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
        public void CanGetLoginPageWithError()
        {
            var browser = new Browser(new BootStrapper());
            var response = browser.Get("/login", with =>
                                        {
                                            with.HttpRequest();
                                            with.Query("error", "true");
                                        });

            response.Body["div[class='login-error']"].ShouldExist();
        }

        [Fact]
        public void CanLoginWithValidCredentials()
        {
            var browser = new Browser(new BootStrapper());
            var response = browser.Post("/login", with =>
                                       {
                                           with.HttpRequest();
                                           with.FormValue("Username", "demo");
                                           with.FormValue("Password", "demo");
                                       });

            response.ShouldHaveRedirectedTo("/home");
            response.Body["h1"].ShouldContain("Welcome to Shifter");
        }

        [Fact]
        public void CannotLoginWithInvalidCredentials()
        {
            var browser = new Browser(new BootStrapper());
            var response = browser.Post("/login", with =>
                                        {
                                            with.HttpRequest();
                                            with.FormValue("Username", "demo");
                                            with.FormValue("Password", "wrongpassword");
                                        });

            response.ShouldHaveRedirectedTo("/login?error=true");
        }
    }
}
