using UnityEngine;
using System;

namespace Shops
{
    [Serializable]
    public class LevelUpgradeData
    {
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public float Value { get; private set; }
    }

}