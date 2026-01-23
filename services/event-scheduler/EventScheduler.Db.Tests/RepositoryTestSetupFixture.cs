using EventScheduler.Core;
using EventScheduler.Db.Interfaces;
using EventScheduler.Db.Mssql;
using EventScheduler.Db.Postgres;
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Db.Tests
{
    [SetUpFixture]
    public class RepositoryTestSetupFixture
    {
        [OneTimeSetUp]
        public void MigrateDatabase()
        {
            IAppDbContext dbContext = EnvironmentConfig.DbProvider switch
            {
                "postgres" => new PostgresDbContext(),
                "mssql" => new MssqlDbContext(),
                _ => throw new Exception("Invalid database provider")
            };
            dbContext.Database.Migrate();
        }
    }
}
