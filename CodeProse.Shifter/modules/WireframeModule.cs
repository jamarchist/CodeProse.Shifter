using Nancy;

namespace CodeProse.Shifter.modules
{
    /// <summary>
    /// So we can actually navigate to the wireframes through the web app
    /// </summary>
    public class WireframeModule : NancyModule
    {
        public WireframeModule() : base("/wireframes")
        {
            Get["/{page}"] = x => View["wireframes/" + x.page.ToString()];
        }
    }
}