using System.Collections.Generic;

namespace CodeProse.Shifter.models
{
    public class ShiftsModel : MasterModel
    {
        public virtual IList<string> Shifts { get; set; }
    }
}