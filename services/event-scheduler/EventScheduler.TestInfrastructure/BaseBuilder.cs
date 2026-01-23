namespace EventScheduler.TestInfrastructure
{
    public abstract class BaseBuilder<TBuilder, TEntity> : AbstractBaseBuilder<TBuilder, TEntity>
        where TEntity : class
        where TBuilder : BaseBuilder<TBuilder, TEntity>, new()
    {
        public static TBuilder Create()
        {
            return new TBuilder();
        }
    }
}
