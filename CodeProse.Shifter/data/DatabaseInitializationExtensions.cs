using System.Data;
using System.IO;
using Dapper;

namespace CodeProse.Shifter.data
{
    public static class DatabaseInitializationExtensions
    {
        public static void CreateTables(this IDbConnection connection)
        {
            connection.Execute(@"
CREATE TABLE IF NOT EXISTS Users 
(
    Id NVARCHAR(20) PRIMARY KEY, 
    UserName NVARCHAR(100), 
    Password NVARCHAR(100),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Email NVARCHAR(100)
);");
        }

        public static void DropAndRecreateDatabase(string databaseName)
        {
            if (File.Exists(databaseName))
            {
                File.Delete(databaseName);
            }
        }
    }
}