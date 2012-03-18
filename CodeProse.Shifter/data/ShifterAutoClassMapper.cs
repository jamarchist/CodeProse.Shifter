using CodeProse.Shifter.authentication;
using CodeProse.Shifter.domain;
using DapperExtensions.Mapper;

namespace CodeProse.Shifter.data
{
    public class ShifterAutoClassMapper<T> : PluralizedAutoClassMapper<T> where T: class
    {
        protected override void AutoMap()
        {
            if (typeof(T) == typeof(User))
            {
                var autoMapper = new UserMapper();
                autoMapper.AutoMapPublic();
            }
            else
            {
                base.AutoMap();
            }
        }

        public override void Table(string tableName)
        {
            if (tableName == "ScheduledShift")
            {
                TableName = "ScheduledShifts";
            }
            else
            {
                base.Table(tableName);   
            }
        }        
    }
}