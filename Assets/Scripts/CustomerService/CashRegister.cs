using Upgradeable;
using Data;
using Interactions;
using Player;
using UnityEngine;
using Zenject;

namespace CustomerService
{
    public class CashRegister : CustomerServiceBase, IUpgradeableAttribute
    {
        [SerializeField] private PickupCounterSevice _pickupCounter;

        private IInteractionLoader _interactionLoader;
        private float _timeServe;

        public float Value => _timeServe;

        [Inject]
        public void Construct(IInteractionLoader interactionLoader, GameData gameData)
        {
            _interactionLoader = interactionLoader;
            _timeServe = gameData.TimeServeCustomerCashRegister;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _interactionLoader.PlayerInteractСompleted += OnPlayerInteractСompleted;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _interactionLoader.PlayerInteractСompleted -= OnPlayerInteractСompleted;
        }

        protected override void OnPlayerStartInteract(PlayerInteractor playerInteractor)
        {
            if (!IsService)
                _interactionLoader.StartInteraction(playerInteractor, _timeServe);
        }

        protected override void OnPlayerStopInteract(PlayerInteractor playerInteractor) => 
            _interactionLoader.StopInteraction();

        private void OnPlayerInteractСompleted(PlayerInteractor playerInteractor)
        {
            _pickupCounter.GetInLine(CurrentCustomer);
            NextCustomer();
        }

        public void IncreaseAttribute(float amount) => 
            _timeServe = amount;
    }
}
