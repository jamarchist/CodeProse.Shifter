using System;
using System.Collections.Generic;
using CodeProse.Shifter.utility;
using System.Linq;

namespace CodeProse.Shifter.models
{
    public class ShiftsModel : MasterModel
    {
        public virtual IList<ShiftTimeModel> Shifts { get; set; }
    }

    public class ShiftTimeModel
    {
        public virtual SimpleTime BeginTime { get; set; }
        public virtual SimpleTime EndTime { get; set; }
        public virtual IList<Day> Days { get; set; }

        public override string ToString()
        {
            var daysPart = String.Join("", Days.Select(d => d.Abbreviation));

            return String.Format("{0} - {1} {2}", BeginTime, EndTime, daysPart);
        }
    }

    public class SimpleTime
    {
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual bool IsPM { get; set; }

        public override string ToString()
        {
            var minutePart = String.Empty;
            if (Minute > 0)
            {
                minutePart = String.Format(":{0}", Minute.ToString().PadLeft(2, '0'));
            }

            var amPmPart = IsPM ? "PM" : "AM";

            return String.Format("{0}{1} {2}", Hour, minutePart, amPmPart);
        }
    }
}