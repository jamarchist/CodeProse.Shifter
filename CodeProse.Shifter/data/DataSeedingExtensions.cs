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
            connection.Execute("INSERT INTO Users VALUES (@Id, @Username, @Password, @FirstName, @LastName, @Email);", 
                new { Id = Guid.NewGuid().ToString(), Username = "rgray", Password = "letsgoblues!", FirstName = "Ryan", LastName = "Gray", Email = "ryan.gray@codeprosetestemail.com" });
            connection.Execute("INSERT INTO Users VALUES (@Id, @Username, @Password, @FirstName, @LastName, @Email);", 
                new { Id = Guid.NewGuid().ToString(), Username = "demo", Password = "demo", FirstName = "Demo", LastName = "McTest", Email = "demo.mctest@codeprosetestemail.com" });
        }
    }
}