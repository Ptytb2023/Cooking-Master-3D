namespace Infrastructure.Pools
{

    public interface IObjectPool<T>
    {
        T Get();
        void Return(T obj);
        void Clear();
    }
}


