using EventScheduler.TestInfrastructure.Interfaces;

namespace EventScheduler.TestInfrastructure
{
    public abstract class BaseFactory<TBuilder, TEntity> : BaseBuilder<TBuilder, TEntity>, IFactory<TEntity>
        where TEntity : class
        where TBuilder : BaseFactory<TBuilder, TEntity>, new()
    {
        public List<TEntity> Build(int amount)
        {
            return [.. Enumerable.Range(0, amount).Select(_ => Build())];
        }
    }
}
