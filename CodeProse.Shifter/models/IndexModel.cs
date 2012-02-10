using System.Collections.Generic;

namespace CodeProse.Shifter.models
{
    public class IndexModel
    {
        public IList<string> WireframePages
        {
            get 
            { 
                return new List<string> 
                {
                    "wireframes/default", 
                    "wireframes/assign-shifts",
                    "wireframes/view-calendar"
                }; 
            }
        }

        public string UserName { get; set; }
    }
}