using System;
using CodeProse.Shifter.domain;
using CodeProse.Shifter.modules;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;
using CodeProse.Shifter.data;

namespace CodeProse.Shifter.resources
{
    public class MembersModule : SecureModule
    {
        public MembersModule() : base("/members")
        {
            Post["/"] = x =>
            {
                var newMember = this.Bind<User>();
                ExecuteCommand(db => db.Insert(newMember));

                var response = Response.AsJson(newMember);
                response.StatusCode = HttpStatusCode.Created;

                return response;   
            };

            Get["/"] = x =>
            {
                var members = Query(db => db.GetAll<User>());
                return Response.AsJson(members);                       
            };

            Get[@"/(?<firstname>[\w]{1,20})(?<dash>[\-]{1})(?<lastname>[\w]{1,20})"] = x =>
            {
                var member =
                    Query(db => db.GetAll<User>().FirstOrDefault(m => m.FirstName == x.firstname && m.LastName == x.lastname));

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
                    var member = db.GetAll<User>().FirstOrDefault(m => m.FirstName == x.firstname && m.LastName == x.lastname);

                    if (member != null)
                    {
                        db.Delete(member);
                    }
                });

                return HttpStatusCode.ResetContent;                
            };
        }
    }
}