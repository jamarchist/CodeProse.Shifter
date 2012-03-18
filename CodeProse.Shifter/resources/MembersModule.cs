using System;
using CodeProse.Shifter.domain;
using CodeProse.Shifter.modules;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;

namespace CodeProse.Shifter.resources
{
    public class MembersModule : SecureModule
    {
        public MembersModule() : base("/members")
        {
            Post["/"] = x =>
            {
                var newMember = this.Bind<User>();
                // TODO: Find somewhere else to put this
                // ID creation logic for users
                newMember.Id = Guid.NewGuid();
                ExecuteCommand(db => db.Users.AddNewUser(newMember));

                var response = Response.AsJson(newMember);
                response.StatusCode = HttpStatusCode.Created;

                return response;   
            };

            Get["/"] = x =>
            {
                var members = Query(db => db.Users.ListAllUsers());
                return Response.AsJson(members);                       
            };

            Get[@"/(?<firstname>[\w]{1,20})(?<dash>[\-]{1})(?<lastname>[\w]{1,20})"] = x =>
            {
                var member =
                    Query(db => db.Users.ListAllUsers().FirstOrDefault(m => m.FirstName == x.firstname && m.LastName == x.lastname));

                if (member != null)
                {
                    return Response.AsJson(member);
                }

                return HttpStatusCode.NotFound;                    
            };

            Delete[@"/(?<firstname>[\w]{1,20})(?<dash>[\-]{1})(?<lastname>[\w]{1,20})"] = x =>
            {
                ExecuteCommand(db =>
                {
                    var member = db.Users.ListAllUsers().FirstOrDefault(m => m.FirstName == x.firstname && m.LastName == x.lastname);

                    if (member != null)
                    {
                        db.Users.DeleteUser(member.Id);
                    }
                });

                return HttpStatusCode.ResetContent;                
            };
        }
    }
}