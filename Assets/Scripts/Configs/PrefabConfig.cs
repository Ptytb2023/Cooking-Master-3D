using Customers;
using Items;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(PrefabConfig), menuName = nameof(ScriptableObject) + "/" + nameof(PrefabConfig), order = 51)]
    public class PrefabConfig : ScriptableObject
    {
        [SerializeField] private List<Item> _items;
        [SerializeField] private Customer _customerPrefab;

        public IEnumerable<Item> Items => _items;

        public Customer CustomerPrefab => _customerPrefab;
    }
}
