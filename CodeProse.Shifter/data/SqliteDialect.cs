using System.Collections.Generic;
using DapperExtensions.Sql;

namespace CodeProse.Shifter.data
{
    public class SqliteDialect : SqlDialectBase
    {
        public override string GetIdentitySql(string tableName)
        {
            var sqlServerDialect = new SqlServerDialect();
            var idSql = sqlServerDialect.GetIdentitySql(tableName);
            return idSql;
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            var sqlServerDialect = new SqlServerDialect();
            return sqlServerDialect.GetPagingSql(sql, page, resultsPerPage, parameters);
        }

        public override string GetColumnName(string prefix, string columnName, string alias)
        {
            //return base.GetColumnName(prefix, columnName, alias);
            return columnName;
        }

        public override string GetTableName(string schemaName, string tableName, string alias)
        {
            return base.GetTableName(schemaName, tableName, alias);
        }
    }
}