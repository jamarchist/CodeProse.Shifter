using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeProse.Shifter.domain;

namespace CodeProse.Shifter.resources
{
    public class ScheduledShiftsModule : RestModule<ScheduledShift>
    {
        public ScheduledShiftsModule() : base("/scheduled-shifts")
        {
        }
    }
}