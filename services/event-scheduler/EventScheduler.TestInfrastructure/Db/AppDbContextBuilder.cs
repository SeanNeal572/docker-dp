using EventScheduler.Core;
using EventScheduler.Db.Interfaces;
using EventScheduler.Db.Mssql;
using EventScheduler.Db.Postgres;
using EventScheduler.TestInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace EventScheduler.TestInfrastructure.Db
{
    public class AppDbContextBuilder : IBuilder<IAppDbContext>, IDisposable
    {
        protected readonly IAppDbContext DbContext = EnvironmentConfig.DbProvider switch
        {
            "postgres" => new PostgresDbContext(),
            "mssql" => new MssqlDbContext(),
            _ => throw new Exception("Invalid database provider")
        };
        private readonly IDbContextTransaction Transaction;

        private AppDbContextBuilder()
        {
            Transaction = DbContext.Database.BeginTransaction();
        }
        public static AppDbContextBuilder Create()
        {
            return new AppDbContextBuilder();
        }

        public IAppDbContext Build()
        {
            return DbContext;
        }

        public void Dispose() => Transaction.Dispose();
    }
}
