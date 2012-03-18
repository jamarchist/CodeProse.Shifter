using System.Collections.Generic;
using System.Linq;
using CodeProse.Shifter.domain;
using Nancy;
using Xunit;

namespace CodeProse.Shifter.Tests
{
    public class MemberTests : RestTests
    {
        [Fact]
        public void CanGetAllMembers()
        {
            var users = Get<IEnumerable<User>>("/members");
            Assert.Equal(2, users.Count());
        }

        [Fact]
        public void CanGetSpecificMember()
        {
            var user = Get<User>("/members/Ryan-Gray");
            Assert.Equal("Ryan", user.FirstName);
        }

        [Fact]
        public void CanAddMember()
        {
            var newMember = new User
            {
                FirstName = "testfirstname",
                LastName = "testlastname",
                Email = "testemail@email.com",
                UserName = "testuser"
            };

            var response = Post("/members", newMember);
            var allUsers = Query(db => db.Users.ListAllUsers());

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(3, allUsers.Count);
        }

        [Fact]
        public void CanDeleteMember()
        {
            var response = Delete("/members/Ryan-Gray");
            var allUsers = Query(db => db.Users.ListAllUsers());

            Assert.Equal(HttpStatusCode.ResetContent, response.StatusCode);
            Assert.Equal(1, allUsers.Count);
        }

    }
}
