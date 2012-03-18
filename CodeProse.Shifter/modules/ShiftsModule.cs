using System.Collections.Generic;
using CodeProse.Shifter.domain;
using CodeProse.Shifter.models;
using CodeProse.Shifter.utility;
using CodeProse.Shifter.data.queries;
using System.Linq;

namespace CodeProse.Shifter.modules
{
    public class ShiftsModule : SecureModule
    {
        public ShiftsModule() : base("/views")
        {
            Get["/shifts"] = x =>
            {
                var shiftsModel = new ShiftsModel { Shifts = new List<ShiftTimeModel>() };
                var scheduledShifts = Query(db => db.GetAll<ScheduledShift>().OrderBy(s => s.StartHour));
                foreach (var shift in scheduledShifts)
                {
                    shiftsModel.Shifts.Add(new ShiftTimeModel
                    {
                        BeginTime = new SimpleTime { Hour = shift.StartHour.AsShortHour(), Minute = shift.StartMinute.AsInt(), IsPM = shift.StartHour.IsPm() },
                        EndTime = new SimpleTime { Hour = shift.EndHour.AsShortHour(), Minute = shift.EndMinute.AsInt(), IsPM = shift.EndHour.IsPm()},
                        Days = Days.All.Where(d => shift.RepeatsOn(d.Name)).ToList()
                    });
                }

                return View["shifts", shiftsModel];
            };
        }
    }
}