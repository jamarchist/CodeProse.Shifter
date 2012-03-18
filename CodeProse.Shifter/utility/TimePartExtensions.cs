namespace CodeProse.Shifter.utility
{
    public static class TimePartExtensions
    {
        public static int AsShortHour(this long hour)
        {
            if (hour.IsPm())
            {
                return (hour - 12).AsInt();
            }

            return hour.AsInt();
        }

        public static bool IsPm(this long hour)
        {
            return hour > 12;
        }
    }
}