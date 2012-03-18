using System;
using CodeProse.Shifter.authentication;
using CodeProse.Shifter.domain;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Xunit;

namespace CodeProse.Shifter.Tests
{
    public class SqliteDialectTests
    {
        [Fact]
        public void CanGenerateInsertSql()
        {
            var classMapper = new ShifterAutoClassMapper<ScheduledShift>();
            var generator = new SqlGeneratorImpl(new SqliteDialect());
            
            Console.WriteLine(generator.Insert(classMapper));
        }
    }
}
