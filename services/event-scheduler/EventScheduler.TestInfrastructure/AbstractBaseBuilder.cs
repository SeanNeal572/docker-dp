using EventScheduler.TestInfrastructure.Interfaces;

namespace EventScheduler.TestInfrastructure
{
    public abstract class AbstractBaseBuilder<TBuilder, TEntity> : IBuilder<TEntity>
        where TEntity : class
        where TBuilder : AbstractBaseBuilder<TBuilder, TEntity>
    {
        private readonly List<Action<TEntity>> _mutations = [];
        private readonly TBuilder _inst;

        protected AbstractBaseBuilder()
        {
            _inst = (this as TBuilder)!;
        }

        protected TBuilder With(Action<TEntity> mutation)
        {
            _mutations.Add(mutation);
            return _inst;
        }

        public TEntity Build()
        {
            var baseEntity = CreateBaseEntity();
            foreach (var mutation in _mutations)
            {
                mutation(baseEntity);
            }
            return baseEntity;
        }

        protected abstract TEntity CreateBaseEntity();
    }
}
