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
                    new Day{ Abbreviation = "M", Name = "Monday"},
                    new Day{ Abbreviation = "Tu", Name = "Tuesday"},
                    new Day{ Abbreviation = "W", Name = "Wednesday"},
                    new Day{ Abbreviation = "Th", Name = "Thursday"},
                    new Day{ Abbreviation = "F", Name = "Friday"},
                    new Day{ Abbreviation = "Sa", Name = "Saturday"},
                    new Day{ Abbreviation = "Su", Name = "Sunday"}
                };
            }
        } 
    }
}