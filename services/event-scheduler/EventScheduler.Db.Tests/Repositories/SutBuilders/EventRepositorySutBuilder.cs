using EventScheduler.Core.Repositories;
using EventScheduler.Db.Repositories;
using EventScheduler.TestInfrastructure.Db;

namespace EventScheduler.Db.Tests.Repositories.SutBuilders
{
    public class EventRepositorySutBuilder : IDisposable
    {
        protected AppDbContextBuilder _dbContextBuilder = AppDbContextBuilder.Create();

        public IEventRepository Build()
        {
            return new EventRepository(_dbContextBuilder.Build());
        }

        public void Dispose() => _dbContextBuilder.Dispose();
    }
}
