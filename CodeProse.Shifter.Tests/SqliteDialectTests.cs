using System;
using CodeProse.Shifter.data;
using CodeProse.Shifter.domain;
using DapperExtensions.Sql;
using Xunit;
using DapperExtensions;

namespace CodeProse.Shifter.Tests
{
    public class SqliteDialectTests
    {
        [Fact]
        public void CanGenerateInsertSql()
        {
            DapperBootStrapper.ConfigureDapper();

            var classMapper = new ShifterClassMapper<ScheduledShift>();
            var generator = new SqlGeneratorImpl(new SqliteDialect());
            
            Console.WriteLine(generator.Insert(classMapper));

            using(var database = new Database())
            {
                database.Connection.CreateTables();
                database.Connection.Insert(new ScheduledShift
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
            }
        }
    }
}
