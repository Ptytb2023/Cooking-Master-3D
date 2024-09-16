using Configs;
using Customers;
using Items;
using System.Collections.Generic;

namespace Infrastructure.Services.Assets
{
    public class AssetsProvider : IAssetProvider
    {
        private readonly PrefabConfig _itemConfig;
        private readonly Dictionary<string, Item> _prefabs = new Dictionary<string, Item>();

        public AssetsProvider(PrefabConfig itemConfig)
        {
            _itemConfig = itemConfig;
            WarmingUp();
        }

        public Customer GetCustomerPrefab() => 
            _itemConfig.CustomerPrefab;

        public Item GetPrefabItem(string id) =>
            _prefabs[id];

        private void WarmingUp()
        {
            foreach (var prefab in _itemConfig.Items)
                _prefabs.Add(prefab.Id, prefab);
        }
    }
}
