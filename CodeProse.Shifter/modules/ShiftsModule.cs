using System.Collections.Generic;
using CodeProse.Shifter.models;
using CodeProse.Shifter.utility;

namespace CodeProse.Shifter.modules
{
    public class ShiftsModule : SecureModule
    {
        public ShiftsModule() : base("/views")
        {
            Get["/shifts"] = x =>
            {
                var model = new ShiftsModel();
                model.Shifts = new List<ShiftTimeModel>();
                model.Shifts.Add(new ShiftTimeModel
                                     {
                                         BeginTime = new SimpleTime { Hour = 9 },
                                         EndTime = new SimpleTime { Hour = 2, IsPM = true},
                                         Days = new List<Day> { Days.Monday, Days.Wednesday, Days.Friday }
                                     });
                model.Shifts.Add(new ShiftTimeModel
                {
                    BeginTime = new SimpleTime { Hour = 2, IsPM = true},
                    EndTime = new SimpleTime { Hour = 5, IsPM = true },
                    Days = new List<Day> { Days.Monday, Days.Wednesday, Days.Friday }
                });

                return View["shifts", model];
            };
        }
    }
}