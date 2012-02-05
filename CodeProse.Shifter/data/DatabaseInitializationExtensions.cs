using System.Data;
using Dapper;

namespace CodeProse.Shifter.data
{
    public static class DatabaseInitializationExtensions
    {
        public static void CreateTables(this IDbConnection connection)
        {
            connection.Execute("CREATE TABLE IF NOT EXISTS Users (Id NVARCHAR(20) PRIMARY KEY, Username NVARCHAR(100), Password NVARCHAR(100));");
            //connection.Execute("CREATE TABLE IF NOT EXISTS Members (Id NVARCHAR(2) PRIMARY KEY, UserId NVARCHAR(20));");
        }
    }
}