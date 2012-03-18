using CodeProse.Shifter.authentication;
using CodeProse.Shifter.data;
using Xunit;

namespace CodeProse.Shifter.Tests
{
    public class DatabaseInitializationTests
    {
        public DatabaseInitializationTests()
        {
            DapperBootStrapper.ConfigureDapper();
        }

        [Fact]
        public void CanCreateDatabaseSchema()
        {
            using (var database = new Database())
            {
                database.Connection.CreateTables();
            }
        }

        [Fact]
        public void CanInsertSeedData()
        {
            using (var database = new Database())
            {
                database.Connection.CreateTables();
                database.Connection.InsertSeedData();
            }
        }
    }
}
