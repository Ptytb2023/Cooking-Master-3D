using Customers;
using Interactions;
using Player;
using UnityEngine;

namespace CustomerService
{
    public abstract class CustomerServiceBase : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _customerServicZone;
        [SerializeField] private CustomerQueuePoints _customerQueuePoints;
        [SerializeField] private InteractionZone _interactionZone;

        protected CustomerQueue СustomersQueue;
        protected Customer CurrentCustomer;

        protected bool IsService;

        public int CountCustomer => СustomersQueue.Count;

        private void Awake() => 
            СustomersQueue = new CustomerQueue(_customerQueuePoints);

        protected virtual void OnEnable()
        {
            _interactionZone.PlayerStartInteract += OnPlayerStartInteract;
            _interactionZone.PlayerStopInteract += OnPlayerStopInteract;

            _customerServicZone.Enter += OnEnterServicZone;
        }

        protected virtual void OnDisable()
        {
            _interactionZone.PlayerStartInteract -= OnPlayerStartInteract;
            _interactionZone.PlayerStopInteract -= OnPlayerStopInteract;

            _customerServicZone.Enter -= OnEnterServicZone;
        }

        protected virtual void OnPlayerStartInteract(PlayerInteractor playerInteractor) { }
        protected virtual void OnPlayerStopInteract(PlayerInteractor playerInteractor) { }

        public void GetInLine(Customer customer)
        {
            if (CurrentCustomer != null)
            {
                СustomersQueue.EnqueueCustomer(customer);
                return;
            }

                CurrentCustomer = customer;
        }

        protected void NextCustomer()
        {
            CurrentCustomer = СustomersQueue.DequeueCustomer();
            IsService = false;
        }

        private void OnEnterServicZone(Collider collider)
        {
            if (collider.TryGetComponent(out Customer customer))
                if (CurrentCustomer != customer)
                    return;

            IsService = true;
        }
    }
}
