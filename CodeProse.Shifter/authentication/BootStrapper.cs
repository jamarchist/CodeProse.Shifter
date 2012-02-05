using System;
using System.Data.SQLite;
using CodeProse.Shifter.domain;
using Nancy;
using Nancy.Authentication.Forms;
using DapperExtensions;
using Dapper;

namespace CodeProse.Shifter.authentication
{
    public class BootStrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            using (var connection = new SQLiteConnection("Data Source=testdb.db"))
            {
                connection.Open();

                connection.Execute("CREATE TABLE IF NOT EXISTS Users (Id NVARCHAR(20) PRIMARY KEY, Username NVARCHAR(100), Password NVARCHAR(100));");
                connection.Execute("DELETE FROM Users;");
                connection.Execute("INSERT INTO Users VALUES (@Id, @Username, @Password);", new { Id = Guid.NewGuid().ToString(), Username = "rgray", Password = "letsgoblues!" });
                connection.Execute("INSERT INTO Users VALUES (@Id, @Username, @Password);", new { Id = Guid.NewGuid().ToString(), Username = "demo", Password = "demo" });

                connection.Close();
            }

        }

        protected override void ConfigureRequestContainer(TinyIoC.TinyIoCContainer container)
        {
            base.ConfigureRequestContainer(container);
            container.Register<IUserMapper, SqliteUserMapper>();
            container.Register<IUserRepository, SqliteUserRepository>();
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