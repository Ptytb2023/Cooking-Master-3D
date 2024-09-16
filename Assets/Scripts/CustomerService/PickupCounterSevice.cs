using Items;
using Player;
using System.Collections;
using UnityEngine;

namespace CustomerService
{
    public class PickupCounterSevice : CustomerServiceBase
    {
        [SerializeField] private float _timeToServeCustomer = 0.5f;
        [SerializeField] private Transform _itemPickupPoint;

        protected override void OnPlayerStartInteract(PlayerInteractor playerInteractor)
        {
            if (!IsService)
                return;

            InvenorySlotArm inventory = playerInteractor.InvenorySlotArm;

            if (inventory.IsEmpty)
                return;

            StartCoroutine(ServeCustomer(inventory.TakeItem()));
        }

        private IEnumerator ServeCustomer(Item item)
        {
            item.transform.position = _itemPickupPoint.position;

            yield return new WaitForSeconds(_timeToServeCustomer);

            CurrentCustomer.Serve(item);
            NextCustomer();
        }
    }
}
