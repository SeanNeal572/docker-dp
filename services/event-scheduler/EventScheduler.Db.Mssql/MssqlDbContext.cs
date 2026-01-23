using EventScheduler.Core;
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Db.Mssql
{
    public class MssqlDbContext : AppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            base.OnConfiguring(optionsBuilder.UseSqlServer($"Server={EnvironmentConfig.DbHost},{EnvironmentConfig.DbPort};Database={EnvironmentConfig.DbDatabase};User Id={EnvironmentConfig.DbUser};Password={EnvironmentConfig.DbPassword};Encrypt=True;TrustServerCertificate=True;"));
    }
}
