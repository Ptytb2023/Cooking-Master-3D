using Data;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = nameof(ScriptableObject) + "/" + nameof(GameConfig), order = 51)]
    public class GameConfig : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] public float _speedMovePlayer;

        [Header("Serve")]
        [SerializeField] private float _timeServeCashRegister;
        [SerializeField] private float _timeServePickupCounter;
        [SerializeField] private int _maxCustomers;

        [Header("Kitchen")]
        [SerializeField] private float _timeCookForGrill;

        [SerializeField] private Range _timeBeetwenSpawn;

        public Range TimeBeetwenSpawn => _timeBeetwenSpawn;
        public int MaxCustomers => _maxCustomers;
        public float SpeedMovePlayer => _speedMovePlayer;
        public float TimeServeCashRegister => _timeServeCashRegister;
        public float TimeServePickupCounter => _timeServePickupCounter;
        public float TimeCookForGrill => _timeCookForGrill;

    }
}
