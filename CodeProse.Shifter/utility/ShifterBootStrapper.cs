using System.Data.SQLite;
using CodeProse.Shifter.authentication;
using CodeProse.Shifter.data.initialization;
using Nancy;
using Nancy.Authentication.Forms;

namespace CodeProse.Shifter.utility
{
    public class ShifterBootStrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(TinyIoC.TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<IUserMapper, SqliteUserMapper>();
        }

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


        protected override void RequestStartup(TinyIoC.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines, NancyContext context)
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