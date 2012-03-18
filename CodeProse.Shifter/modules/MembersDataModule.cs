using System;
using CodeProse.Shifter.data;
using CodeProse.Shifter.domain;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;

namespace CodeProse.Shifter.modules
{
    public class MembersDataModule : NancyModule
    {
        public MembersDataModule(IDatabase database) : base("/members")
        {
            Post["/"] = x =>
            {
                using (database)
                {
                    var newMember = this.Bind<User>();
                    // TODO: Find somewhere else to put this
                    // ID creation logic for users
                    newMember.Id = Guid.NewGuid();
                    database.Users.AddNewUser(newMember);
                    return HttpStatusCode.Created;                    
                }
            };

            Get["/"] = x =>
            {
                using (database)
                {
                    var members = database.Users.ListAllUsers();
                    return Response.AsJson(members);                    
                }
            };

            Get[@"/(?<firstname>[\w]{1,20})(?<dash>[\-]{1})(?<lastname>[\w]{1,20})"] = x =>
            {
                using (database)
                {
                    var member =
                        database.Users.ListAllUsers().Where(
                            m => m.FirstName == x.firstname && m.LastName == x.lastname).FirstOrDefault();

                    if (member != null)
                    {
                        return Response.AsJson(member);
                    }

                    return HttpStatusCode.NotFound;                    
                }
            };

            Delete[@"/(?<firstname>[\w]{1,20})(?<dash>[\-]{1})(?<lastname>[\w]{1,20})"] = x =>
            {
                using (database)
                {
                    var member =
                        database.Users.ListAllUsers().Where(
                            m => m.FirstName == x.firstname && m.LastName == x.lastname).FirstOrDefault();

                    if (member != null)
                    {
                        database.Users.DeleteUser(member.Id);
                    }

                    return HttpStatusCode.OK;                    
                }
            };
        }
    }
}