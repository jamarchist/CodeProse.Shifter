using System.Collections.Generic;
using System.Linq;
using CodeProse.Shifter.domain;
using DapperExtensions;

namespace CodeProse.Shifter.data
{
    public static class UserQueryExtensions
    {
        public static User GetUserByNameAndPassword(this IDatabase db, string name, string password)
        {
            var byUserNameAndPassword = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            byUserNameAndPassword.Predicates.Add(Predicates.Field<User>(u => u.UserName, Operator.Eq, name));
            byUserNameAndPassword.Predicates.Add(Predicates.Field<User>(u => u.Password, Operator.Eq, password));

            return db.Connection.GetList<User>(byUserNameAndPassword).ToList().FirstOrDefault();
        }
    }
}