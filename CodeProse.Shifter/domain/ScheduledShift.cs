using System;

namespace CodeProse.Shifter.domain
{
    public class ScheduledShift
    {
        public virtual Guid Id { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }
        public virtual bool RepeatsOnMonday { get; set; }
        public virtual bool RepeatsOnTuesday { get; set; }
        public virtual bool RepeatsOnWednesday { get; set; }
        public virtual bool RepeatsOnThursday { get; set; }
        public virtual bool RepeatsOnFriday { get; set; }
        public virtual bool RepeatsOnSaturday { get; set; }
        public virtual bool RepeatsOnSunday { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}