using Upgradeable;
using Data;
using Infrastructure.Pools;
using Interactions;
using Items;
using Player;
using UnityEngine;
using Zenject;

namespace Kitchen
{
    public class GrillBurgers : MonoBehaviour, IUpgradeableAttribute
    {
        [SerializeField] private string _itemIdForCook;
        [SerializeField] private Transform _pointCook;
        [SerializeField] private InteractionZone _interactionZone;

        private float _timeCook;
        private IItemPool _itemPool;
        private IInteractionLoader _interactionLoader;

        private Item _itemCook;

        public float Value => _timeCook;

        [Inject]
        private void Construct(IInteractionLoader interactionLoader, IItemPool itemPool, GameData gameData)
        {
            _itemPool = itemPool;
            _interactionLoader = interactionLoader;
            _timeCook = gameData.TimeCookForGrill;
        }

        private void Awake()
        {
            _itemCook = _itemPool.Get(_itemIdForCook);
            _itemCook.transform.position = _pointCook.position;
            _itemCook.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _interactionZone.PlayerStartInteract += OnPlayerStartInteract;
            _interactionZone.PlayerStopInteract += OnPlayerStopInteract;

            _interactionLoader.PlayerInteract—ompleted += OnPlayerInteract—ompleted;
        }

        private void OnDisable()
        {
            _interactionZone.PlayerStartInteract -= OnPlayerStartInteract;
            _interactionZone.PlayerStopInteract -= OnPlayerStopInteract;

            _interactionLoader.PlayerInteract—ompleted -= OnPlayerInteract—ompleted;
        }

        public void IncreaseAttribute(float amount) =>
         _timeCook = amount;

        private void OnPlayerStartInteract(PlayerInteractor interactor)
        {
            if(!interactor.InvenorySlotArm.IsEmpty)
                return;

            StartCook(interactor);
        }
        private void OnPlayerStopInteract(PlayerInteractor interactor) =>
            StopCook(interactor);

        private void OnPlayerInteract—ompleted(PlayerInteractor interactor)
        {
            var inventory = interactor.InvenorySlotArm;

            var item = _itemPool.Get(_itemIdForCook);
            inventory.GetItem(item);

            StopCook(interactor);
        }

        private void StopCook(PlayerInteractor interactor)
        {
            _interactionLoader.StopInteraction();
            _itemCook.gameObject.SetActive(false);
        }

        private void StartCook(PlayerInteractor interactor)
        {
            _interactionLoader.StartInteraction(interactor, _timeCook);
            _itemCook.gameObject.SetActive(true);
        }
    }
}