using EventScheduler.Core;
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Db.Postgres
{
    public class PostgresDbContext : AppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            base.OnConfiguring(optionsBuilder.UseNpgsql($"Server={EnvironmentConfig.DbHost};port={EnvironmentConfig.DbPort};Database={EnvironmentConfig.DbDatabase};User Id={EnvironmentConfig.DbUser};Password={EnvironmentConfig.DbPassword}"));
    }
}
