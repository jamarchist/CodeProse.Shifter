using System.Collections.Generic;

namespace CodeProse.Shifter.utility
{
    public static class Days
    {
        public static IList<Day> All
        {
            get
            {
                return new List<Day>
                {
                    Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
                };
            }
        }

        public static Day Monday { get { return new Day { Abbreviation = "M", Name = "Monday" }; } }
        public static Day Tuesday { get { return new Day { Abbreviation = "Tu", Name = "Tuesday" }; } }
        public static Day Wednesday { get { return new Day { Abbreviation = "W", Name = "Wednesday" }; } }
        public static Day Thursday { get { return new Day { Abbreviation = "Th", Name = "Thursday" }; } }
        public static Day Friday { get { return new Day { Abbreviation = "F", Name = "Friday" }; } }
        public static Day Saturday { get { return new Day { Abbreviation = "Sa", Name = "Saturday" }; } }
        public static Day Sunday { get { return new Day { Abbreviation = "Su", Name = "Sunday" }; } }
    }
}