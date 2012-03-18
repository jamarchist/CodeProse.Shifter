namespace CodeProse.Shifter.data
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