using System;
using System.Collections.Generic;
using CodeProse.Shifter.domain;
using Nancy;
using Xunit;
using System.Linq;
using DapperExtensions;

namespace CodeProse.Shifter.Tests
{
    public class ScheduledShiftTests : RestTests
    {
        [Fact]
        public void CanGetAllShifts()
        {
            var shifts = Get<IEnumerable<ScheduledShift>>("/scheduled-shifts");
            Assert.Equal(2, shifts.Count());
        }

        [Fact]
        public void CanGetSpecificShift()
        {
            var anyShift = Query(db => db.Connection.GetList<ScheduledShift>().First());
            var shift = Get<ScheduledShift>(String.Format("/scheduled-shifts/{0}", anyShift.Id));

            Assert.Equal(anyShift.StartHour, shift.StartHour);
            Assert.Equal(anyShift.StartMinute, shift.StartMinute);
            Assert.Equal(anyShift.EndHour, shift.EndHour);
            Assert.Equal(anyShift.EndMinute, shift.EndMinute);
        }

        [Fact]
        public void CanDeleteShift()
        {
            var anyShift = Query(db => db.Connection.GetList<ScheduledShift>().First());
            var response = Delete(String.Format("/scheduled-shifts/{0}", anyShift.Id));

            var deletedShift = Query(db => db.Connection.Get<ScheduledShift>(anyShift.Id));

            Assert.Equal(HttpStatusCode.ResetContent, response.StatusCode);
            Assert.Null(deletedShift);
        }

        [Fact]
        public void CanAddShift()
        {
            var newShift = new ScheduledShift { StartHour = 12, StartMinute = 30, EndHour = 4, EndMinute = 30, RepeatsOnSaturday = true };
            var response = Post("/scheduled-shifts", newShift);

            var allShifts = Query(db => db.Connection.GetList<ScheduledShift>().ToList());
            Assert.Equal(3, allShifts.Count());

            var newestShift = allShifts.Where(s => s.StartHour == 12 && s.StartMinute == 30 && s.EndHour == 4 && s.EndMinute == 30 && s.RepeatsOnSaturday).First();
            Assert.Equal(response.Headers["Location"], String.Format("//scheduled-shifts/{0}", newestShift.Id));
        }
    }
}
