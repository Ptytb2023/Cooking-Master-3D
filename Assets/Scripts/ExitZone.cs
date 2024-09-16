using Customers;
using Infrastructure.Pools;
using Interactions;
using Items;
using System;
using UnityEngine;
using Zenject;

namespace CookingMaster
{
    public class ExitZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private IItemPool _itemPool;
        private ICustomerPool _customerPool;

        public Vector3 Position => transform.position;

        public Action CustomerExit;

        [Inject]
        public void Construct(IItemPool itemPool, ICustomerPool customerPool)
        {
            _customerPool = customerPool;
            _itemPool = itemPool;
        }

        private void OnEnable() => 
            _triggerObserver.Enter += OnEnter;

        private void OnDisable() => 
            _triggerObserver.Enter -= OnEnter;

        private void OnEnter(Collider other)
        {
            if (!other.TryGetComponent(out Customer customer))
                return;

            var item = customer.InvenorySlotArm.TakeItem();

            _itemPool.Return(item);
            _customerPool.Return(customer);

            CustomerExit?.Invoke();
        }
    }
}
