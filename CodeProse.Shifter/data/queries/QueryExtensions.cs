using System.Collections.Generic;
using System.Linq;
using DapperExtensions;

namespace CodeProse.Shifter.data.queries
{
    public static class QueryExtensions
    {
        public static TEntity Get<TEntity>(this IDatabase db, dynamic id) where TEntity : class
        {
            return DapperExtensions.DapperExtensions.Get<TEntity>(db.Connection, id);
        }

        public static IList<TEntity> GetAll<TEntity>(this IDatabase db) where TEntity : class
        {
            return db.Connection.GetList<TEntity>().ToList();
        }

        public static dynamic Insert<TEntity>(this IDatabase db, TEntity entity) where TEntity : class
        {
            return db.Connection.Insert(entity);
        }

        public static bool Delete<TEntity>(this IDatabase db, TEntity entity) where TEntity : class
        {
            return db.Connection.Delete(entity);
        }
    }
}