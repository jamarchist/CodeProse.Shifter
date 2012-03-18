using System;
using CodeProse.Shifter.data.queries;
using CodeProse.Shifter.domain;
using CodeProse.Shifter.utility;
using Nancy;
using System.Linq;
using CodeProse.Shifter.data;

namespace CodeProse.Shifter.resources
{
    public class MembersModule : RestModule<User>
    {
        public MembersModule() : base("/members")
        {
            Get[RoutingExpressions.FirstNameLastName] = x =>
            {
                var member =
                    Query(db => db.GetAll<User>().FirstOrDefault(m => m.FirstName == x.firstname && m.LastName == x.lastname));

                if (member != null)
                {
                    return Response.AsJson(member);
                }

                return HttpStatusCode.NotFound;                    
            };

            Delete[RoutingExpressions.FirstNameLastName] = x =>
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