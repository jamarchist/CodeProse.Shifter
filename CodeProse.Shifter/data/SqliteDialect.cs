using System.Collections.Generic;
using DapperExtensions.Sql;

namespace CodeProse.Shifter.data
{
    public class SqliteDialect : SqlDialectBase
    {
        public override string GetIdentitySql(string tableName)
        {
            return new SqlServerDialect().GetIdentitySql(tableName);
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            return new SqlServerDialect().GetPagingSql(sql, page, resultsPerPage, parameters);
        }

        public override string GetColumnName(string prefix, string columnName, string alias)
        {
            return columnName;
        }
    }
}