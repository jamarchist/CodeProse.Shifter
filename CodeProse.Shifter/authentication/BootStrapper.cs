using System.Collections.Generic;
using System.Data.SQLite;
using CodeProse.Shifter.domain;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Nancy;
using Nancy.Authentication.Forms;
using CodeProse.Shifter.data;

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

    public class ShifterAutoClassMapper<T> : PluralizedAutoClassMapper<T> where T: class
    {
        protected override void AutoMap()
        {
            if (typeof(T) == typeof(User))
            {
                var autoMapper = new UserMapper();
                autoMapper.AutoMapPublic();
            }
            else
            {
                base.AutoMap();
            }
        }

        public override void Table(string tableName)
        {
            if (tableName == "ScheduledShift")
            {
                TableName = "ScheduledShifts";
            }
            else
            {
                base.Table(tableName);   
            }
        }        
    }

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
    
    public static class DapperBootStrapper
    {
        public static void ConfigureDapper()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(ShifterAutoClassMapper<>);
            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();            
        }
    }

    public class BootStrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            DapperBootStrapper.ConfigureDapper();
            
            DatabaseInitializationExtensions.DropAndRecreateDatabase("testdb.db");
            using (var connection = new SQLiteConnection("Data Source=testdb.db"))
            {
                connection.Open();

                connection.CreateTables();
                connection.InsertSeedData();

                connection.Close();
            }

        }

        protected override void ConfigureRequestContainer(TinyIoC.TinyIoCContainer container)
        {
            base.ConfigureRequestContainer(container);
            container.Register<IUserMapper, SqliteUserMapper>();
            container.Register<IUserRepository, SqliteUserRepository>();
            container.Register<IDatabase, Database>();
        }

        protected override void RequestStartup(TinyIoC.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/login",
                    UserMapper = container.Resolve<IUserMapper>(),
                };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }
    }
}