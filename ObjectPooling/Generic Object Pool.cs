using System;
using System.Collections.Concurrent;

/*Reference: https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/how-to-create-an-object-pool */
namespace Creational.ObjectPool
{
    public interface IObjectPool<T>
    {
        T GetObject();
        void PutObject(T item);
    }

    public class SimpleObjectPool<T> : IObjectPool<T>
    {
        private ConcurrentBag<T> _objects;
        private Func<T> _objectGenerator;

        public SimpleObjectPool(Func<T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            _objects = new ConcurrentBag<T>();
            this._objectGenerator = objectGenerator;
        }

        public T GetObject()
        {
            T item;
            if(_objects.TryTake(out item))
            {
                return item;
            }

            return this._objectGenerator();
        }

        public void PutObject(T item)
        {
            this._objects.Add(item);
        }
    }

    /*Optional layer */
    public class PoolManager<T>
    {
        IObjectPool<T> objectPool;
        public PoolManager(IObjectPool<T> objectPool)
        {
            this.objectPool = objectPool;
        }

        public T GetObject()
        {
            return this.objectPool.GetObject();
        }

        public void PutObject(T item)
        {
            this.objectPool.PutObject(item);
        }
    }
}
