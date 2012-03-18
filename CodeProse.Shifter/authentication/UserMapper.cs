using CodeProse.Shifter.domain;
using DapperExtensions.Mapper;

namespace CodeProse.Shifter.authentication
{
    public class UserMapper : PluralizedAutoClassMapper<User>
    {
        protected override void AutoMap()
        {
            Map(x => x.Id).Column("Id").Key(KeyType.Guid);
            Map(x => x.FirstName).Column("FirstName");
            Map(x => x.LastName).Column("LastName");
            Map(x => x.Email).Column("Email");
            Map(x => x.Password).Column("Password");
            Map(x => x.UserName).Column("UserName");
        }   

        public void AutoMapPublic()
        {
            AutoMap();
        }
    }
}