using Infrastructure.Factorys;
using Infrastructure.Services.Assets;
using Items;
using System.Collections.Generic;

namespace Infrastructure.Pools
{
    public class ItemPool : IItemPool
    {
        private IFactoryObject _factoryObject;
        private IAssetProvider _assetProvider;
        private Dictionary<string, ObjectPool<Item>> _pools;

        public ItemPool(IFactoryObject factoryObject, IAssetProvider assetProvider)
        {
            _factoryObject = factoryObject;
            _assetProvider = assetProvider;

            _pools = new Dictionary<string, ObjectPool<Item>>();
        }

        public Item Get(string id)
        {
            if (_pools.TryGetValue(id, out var pool))
                return pool.Get();

            var prefab = _assetProvider.GetPrefabItem(id);

            var newPool = new ObjectPool<Item>(prefab, _factoryObject);

            _pools.Add(id, newPool);

            return newPool.Get();
        }

        public void Return(Item item)
        {
            if (_pools.TryGetValue(item.Id, out var pool))
            {
                pool.Return(item);
                return;
            }

            var prefab = _assetProvider.GetPrefabItem(item.Id);
            var newPool = new ObjectPool<Item>(prefab, _factoryObject);

            newPool.Return(item);
            _pools.Add(item.Id, newPool);
        }

    }
}


