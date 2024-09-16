using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class GameData
    {
        [field: SerializeField] public int MaxCustomer { get; set; }
        [field: SerializeField] public float TimeServeCustomerCashRegister { get; set; }
        [field: SerializeField] public float TimeServePickupCounter { get; set; }
        [field: SerializeField] public float TimeCookForGrill { get; set; }
        [field: SerializeField] public float  PlayerMoveSpeed { get; set; }
        [field: SerializeField] public Range TimeBeetwenSpawn { get; set; }
    }
}
