using System;
using System.Data;
using Dapper;

namespace CodeProse.Shifter.data
{
    public static class DataSeedingExtensions
    {
        public static void InsertSeedData(this IDbConnection connection)
        {
            // Users
            connection.Execute("DELETE FROM Users;");
            connection.Execute("INSERT INTO Users VALUES (@Id, @Username, @Password);", new { Id = Guid.NewGuid().ToString(), Username = "rgray", Password = "letsgoblues!" });
            connection.Execute("INSERT INTO Users VALUES (@Id, @Username, @Password);", new { Id = Guid.NewGuid().ToString(), Username = "demo", Password = "demo" });
        
            // Members
        }
    }
}