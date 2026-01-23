namespace EventScheduler.TestInfrastructure.Interfaces
{
    public interface IFactory<T> : IBuilder<T>
    {
        List<T> Build(int amount);
    }
}
