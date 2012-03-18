using Nancy.Json;
using Nancy.Testing;

namespace CodeProse.Shifter.Tests
{
    public static class TestResponseExtensions
    {
        public static T AsJson<T>(this BrowserResponseBodyWrapper body)
        {
            return new JavaScriptSerializer().Deserialize<T>(body.AsString());
        }
    }
}