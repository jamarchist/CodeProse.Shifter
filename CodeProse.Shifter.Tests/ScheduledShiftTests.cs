using System.Collections.Generic;
using CodeProse.Shifter.domain;
using Xunit;

namespace CodeProse.Shifter.Tests
{
    public class ScheduledShiftTests : RestTests
    {
        [Fact]
        public void CanGetAllShifts()
        {
            var shifts = Get<IEnumerable<ScheduledShift>>("/scheduled-shifts");

        }

        [Fact]
        public void CanGetSpecificShift()
        {
            
        }

        [Fact]
        public void CanDeleteShift()
        {
            
        }

        [Fact]
        public void CanAddShift()
        {
            
        }
    }
}
