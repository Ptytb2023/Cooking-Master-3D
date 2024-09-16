using Upgradeable;
using Player;
using ReactivePropertes;
using UnityEngine;
using System;
using System.Collections.Generic;
using Zenject;
using CustomerService;
using Kitchen;

namespace Shops
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _grillBurgers;
        [SerializeField] private CashRegister _cashRegister;
        [SerializeField] private GrillBurgers _playerMovement;

        private IWalet _waletPlayer;

        private Dictionary<string, Upgrade> _upgrades;

        [Inject]
        public void Construct(IWalet walet)
        {
            _waletPlayer = walet;
        }

        private void Start()
        {
            _upgrades = new Dictionary<string, Upgrade>();

        }

    }

    public class Upgrade : IUpgrade
    {
        private List<LevelUpgradeData> _levelsUpgrade;
        private IUpgradeableAttribute _upgradeableAttribute;

        private ReactiveProperty<int> _level;
        private ReactiveProperty<int> _nextPrice;

        private int _currentIndexLevel;

        public string Name { get; private set; }
        public IReactiveProperty<int> Level => _level;
        public IReactiveProperty<int> NextPrice => _nextPrice;
        public event Action MaxLevel;

        public Upgrade(List<LevelUpgradeData> levelsUpgrade, IUpgradeableAttribute upgradeableAttribute, string name)
        {
            Name = name;

            _levelsUpgrade = levelsUpgrade;
            _upgradeableAttribute = upgradeableAttribute;

            _level = new ReactiveProperty<int>();
            _nextPrice = new ReactiveProperty<int>();

            _level.Value = _currentIndexLevel + 1;

            if (_level.Value < levelsUpgrade.Count)
                _nextPrice.Value = _levelsUpgrade[_level.Value].Price;
        }

        public void NextLevel()
        {
            _upgradeableAttribute.IncreaseAttribute(_levelsUpgrade[_currentIndexLevel].Value);

            _currentIndexLevel++;

            if (_currentIndexLevel >= _levelsUpgrade.Count)
            {
                MaxLevel?.Invoke();
                return;
            }

            _level.Value++;
            _nextPrice.Value = _levelsUpgrade[_level.Value].Price;
        }
    }

}