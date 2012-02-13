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

            response.Body["form"].ShouldExist();
        }
    }
}
