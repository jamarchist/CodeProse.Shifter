using CodeProse.Shifter.authentication;

namespace CodeProse.Shifter.data
{
    public static class DapperBootStrapper
    {
        public static void ConfigureDapper()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(ShifterAutoClassMapper<>);
            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();            
        }
    }
}