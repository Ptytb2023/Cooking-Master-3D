using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Shops
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _priceText;

        [SerializeField] private Button _purchaseButton;

        private IUpgrade _upgrade;

        public event Action<string> ClickUpgrade;
        public void Init(IUpgrade upgrade)
        {
            _upgrade = upgrade;

            _upgrade.MaxLevel += OnMaxLevel;

            _upgrade.Level.SubscribeAndUpdate(OnUpdateLevel);
            _upgrade.NextPrice.SubscribeAndUpdate(OnUpdateNextPrice);
        }

        private void OnDisable()
        {
            if (_upgrade == null)
                return;

            _upgrade.MaxLevel -= OnMaxLevel;

            _upgrade.Level.Unsubscribe(OnUpdateLevel);
            _upgrade.NextPrice.Unsubscribe(OnUpdateNextPrice);
        }

        private void OnMaxLevel()
        {
            _purchaseButton.enabled = false;
        }

        private void OnUpdateLevel(int level) =>
            _levelText.text = level.ToString();

        private void OnUpdateNextPrice(int price) =>
         _priceText.text = price.ToString();
    }

}