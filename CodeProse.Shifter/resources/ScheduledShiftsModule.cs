using System;
using System.Linq;
using CodeProse.Shifter.domain;
using CodeProse.Shifter.utility;
using CodeProse.Shifter.data.queries;
using Nancy;

namespace CodeProse.Shifter.resources
{
    public class ScheduledShiftsModule : RestModule<ScheduledShift>
    {
        public ScheduledShiftsModule() : base("/scheduled-shifts")
        {
            Get[RoutingExpressions.Date] = x =>
            {
                DateTime date = Convert.ToDateTime(String.Format("{0}-{1}-{2}", x.year, x.month, x.day));
                var shifts = Query(db => db.GetAll<ScheduledShift>().Where(s => s.RepeatsOn(date.DayOfWeek)));

                return Response.AsJson(shifts);
            };
        }
    }
}