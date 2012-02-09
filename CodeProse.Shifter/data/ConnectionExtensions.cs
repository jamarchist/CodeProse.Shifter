using System.Data;

namespace CodeProse.Shifter.data
{
    public static class ConnectionExtensions
    {
        public static IDatabase AsDatabase(this IDbConnection connection)
        {
            return new Database(connection);
        }
    }
}