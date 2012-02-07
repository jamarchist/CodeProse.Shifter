using System.Collections.Generic;

namespace CodeProse.Shifter.models
{
    public class IndexModel
    {
        public string Introduction { get { return "This is a page to test out the Razor view engine for Nancy."; } }

        public IList<string> WireframePages
        {
            get 
            { 
                return new List<string> 
                {
                    "wireframes/default", 
                    "wireframes/manage",
                    "wireframes/view-calendar"
                }; 
            }
        }

        public string UserName { get; set; }
    }
}