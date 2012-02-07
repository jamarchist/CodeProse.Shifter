﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CodeProse.Shifter.domain;
using Dapper;

namespace CodeProse.Shifter.data
{
    public static class QueryExtensions
    {
        public static User GetUserByUsernameAndPassword(this IDbConnection connection, string username, string password)
        {
            return connection.Query<User>("SELECT * FROM Users WHERE Username = @Username AND Password = @Password LIMIT 1", new { Username = username, Password = password }).FirstOrDefault();
        }

        public static User GetUserById(this IDbConnection connection, Guid identifier)
        {
            return connection.Query<User>("SELECT * FROM Users WHERE Id = @Id LIMIT 1", new { Id = identifier.ToString() }).First();
        }

        public static void AddUser(this IDatabase database, User newUser)
        {
            database.Connection.Execute(
                "INSERT INTO Users VALUES (@Id, @UserName, @Password, @FirstName, @LastName, @Email)", newUser);
        }

        public static IList<User> ListAllUsers(this IDatabase database)
        {
            return database.Connection.Query<User>("SELECT * FROM Users").ToList();
        }
    }
}