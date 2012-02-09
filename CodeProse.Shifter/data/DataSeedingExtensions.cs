using System;
using System.Data;
using CodeProse.Shifter.domain;
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
                new User { Id = Guid.NewGuid().ToString(), UserName = "rgray", Password = "letsgoblues!", FirstName = "Ryan", LastName = "Gray", Email = "ryan.gray@codeprosetestemail.com" });
            connection.Execute("INSERT INTO Users VALUES (@Id, @Username, @Password, @FirstName, @LastName, @Email);", 
                new User { Id = Guid.NewGuid().ToString(), UserName = "demo", Password = "demo", FirstName = "Demo", LastName = "McTest", Email = "demo.mctest@codeprosetestemail.com" });
        }
    }
}