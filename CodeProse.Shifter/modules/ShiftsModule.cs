using System.Collections.Generic;
using CodeProse.Shifter.models;

namespace CodeProse.Shifter.modules
{
    public class ShiftsModule : SecureModule
    {
        public ShiftsModule() : base("/views")
        {
            Get["/shifts"] = x =>
            {
                var model = new ShiftsModel();
                model.Shifts = new List<string>();
                model.Shifts.Add("9AM - 2PM MWF");
                model.Shifts.Add("2PM - 5PM MWF");

                return View["shifts", model];
            };
        }
    }
}