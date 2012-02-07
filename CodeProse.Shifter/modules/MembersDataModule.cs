using CodeProse.Shifter.data;
using CodeProse.Shifter.domain;
using Nancy;
using Nancy.ModelBinding;

namespace CodeProse.Shifter.modules
{
    public class MembersDataModule : NancyModule
    {
        public MembersDataModule(IDatabase database) : base("/members")
        {
            Post["/"] = x =>
            {
                var newMember = this.Bind<User>();
                database.AddUser(newMember);
                return HttpStatusCode.Accepted;
            };

            Get["/"] = x =>
            {
                var members = database.ListAllUsers();
                return Response.AsJson(members);
            };
        }
    }
}