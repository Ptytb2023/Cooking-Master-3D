using Infrastructure.Factorys;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Pools
{

    public class ObjectPool<T> : IObjectPool<T> where T : Component, IPoolable
    {
        private T _prefab;
        private IFactoryObject _factoryObject;

        public ObjectPool(T prefab, IFactoryObject factoryObject)
        {
            _factoryObject = factoryObject;
            _prefab = prefab;
        }

        private Queue<T> _components = new Queue<T>();

        public T Get()
        {
            T component = null;

            if (_components.Count <= 0)
                component = _factoryObject.Creat(_prefab);
            else
                component = _components.Dequeue();

            component.Spawn();
            component.gameObject.SetActive(true);

            return component;
        }

        public void Return(T component)
        {
            component.Despawn();
            component.gameObject.SetActive(false);

            _components.Enqueue(component);
        }

        public void Clear()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                var component = _components.Dequeue();
                GameObject.Destroy(component.gameObject);
            }
        }
    }
}


