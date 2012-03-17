using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CodeProse.Shifter.domain;
using Dapper;

namespace CodeProse.Shifter.data
{
    public class ShiftQueries
    {
        
    }

    public class UserQueries
    {
        private readonly IDbConnection connection;

        public UserQueries(IDbConnection connection)
        {
            this.connection = connection;
        }

        public virtual User GetUserByUsernameAndPassword(string username, string password)
        {
            return connection.Query<User>("SELECT * FROM Users WHERE Username = @Username AND Password = @Password LIMIT 1", new { Username = username, Password = password }).FirstOrDefault();
        }

        public virtual User GetUserById(Guid identifier)
        {
            return connection.Query<User>("SELECT * FROM Users WHERE Id = @Id LIMIT 1", new { Id = identifier }).First();
        }

        public virtual void AddNewUser(User newUser)
        {
            connection.Execute(
                "INSERT INTO Users VALUES (@Id, @UserName, @Password, @FirstName, @LastName, @Email)", newUser);
        }

        public virtual IList<User> ListAllUsers()
        {
            return connection.Query<User>("SELECT * FROM Users").ToList();
        }

        public virtual void DeleteUser(Guid identifier)
        {
            connection.Execute("DELETE FROM Users WHERE Id = @Id", new {Id = identifier});
        }
    }
}