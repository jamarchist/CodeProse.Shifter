using CodeProse.Shifter.data.mapping;

namespace CodeProse.Shifter.data.initialization
{
    public static class DapperBootStrapper
    {
        public static void ConfigureDapper()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(ShifterClassMapper<>);
            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();            
        }
    }
}