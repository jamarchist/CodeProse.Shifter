using System;
using System.Collections.Generic;
using System.Data;
using CodeProse.Shifter.domain;
using Dapper;
using DapperExtensions;
using System.Linq;

namespace CodeProse.Shifter.data
{
    public static class DataSeedingExtensions
    {
        public static void InsertSeedData(this IDbConnection connection)
        {
            const string insertIntoScheduledShifts = "INSERT INTO ScheduledShifts (Id, EndDate, EndHour, EndMinute, RepeatsOnSunday, StartDate, StartHour, StartMinute, RepeatsOnMonday, RepeatsOnTuesday, RepeatsOnWednesday, RepeatsOnThursday, RepeatsOnFriday, RepeatsOnSaturday) VALUES (@Id, @EndDate, @EndHour, @EndMinute, @RepeatsOnSunday, @StartDate, @StartHour, @StartMinute, 0, 0, 0, 0, 0, 0)";

            // Users
            connection.Execute("DELETE FROM Users;");
            connection.Insert(new List<User> {
                new User { Id = Guid.NewGuid(), UserName = "rgray", Password = "letsgoblues!", FirstName = "Ryan", LastName = "Gray", Email = "ryan.gray@codeprosetestemail.com" }, 
                new User { Id = Guid.NewGuid(), UserName = "demo", Password = "demo", FirstName = "Demo", LastName = "McTest", Email = "demo.mctest@codeprosetestemail.com" }}.AsEnumerable());

            connection.Execute("DELETE FROM ScheduledShifts;");
            connection.Insert(new ScheduledShift
            {
                Id = Guid.NewGuid(),
                EndDate = new DateTime(2012, 12, 31),
                EndHour = 20,
                EndMinute = 20,
                RepeatsOnSunday = true,
                StartDate = new DateTime(2012, 01, 01),
                StartHour = 19,
                StartMinute = 10
            });
            connection.Insert(new ScheduledShift
            {
                Id = Guid.NewGuid(),
                EndDate = new DateTime(2012, 12, 31),
                EndHour = 19,
                EndMinute = 10,
                RepeatsOnSunday = true,
                StartDate = new DateTime(2012, 01, 01),
                StartHour = 18,
                StartMinute = 0
            });
        }
    }
}