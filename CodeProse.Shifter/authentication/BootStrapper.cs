using System.Data.SQLite;
using DapperExtensions.Mapper;
using Nancy;
using Nancy.Authentication.Forms;
using CodeProse.Shifter.data;

namespace CodeProse.Shifter.authentication
{
    public class BootStrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof (PluralizedAutoClassMapper<>);
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