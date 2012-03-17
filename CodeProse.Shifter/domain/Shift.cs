using System.Collections.Generic;

namespace CodeProse.Shifter.domain
{
    public class Shift
    {
        public virtual int Day { get; set; }
        public virtual int Month { get; set; }
        public virtual int Year { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }

        public IEnumerable<User> AssignedMembers { get; set; } 
    }
}