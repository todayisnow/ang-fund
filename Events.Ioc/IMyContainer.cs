namespace Events.Ioc
{
    public interface IMyContainer
    {
        void Register<TFrom, TTo>();
        T Resolve<T>();
    }
}