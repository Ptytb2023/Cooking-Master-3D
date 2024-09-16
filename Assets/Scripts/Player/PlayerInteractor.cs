using Interactions;
using UnityEngine;

namespace Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private InvenorySlotArm _invenorySlot;
        [SerializeField] private TriggerObserver _triggerObserver;

        public InvenorySlotArm InvenorySlotArm => _invenorySlot;

        private void OnEnable()
        {
            _triggerObserver.Enter += OnTriggerEnterInteractionZone;
            _triggerObserver.Exit += OnTriggerExitInteractionZone;
        }

        private void OnDisable()
        {
            _triggerObserver.Enter -= OnTriggerEnterInteractionZone;
            _triggerObserver.Exit -= OnTriggerExitInteractionZone;
        }

        private void OnTriggerEnterInteractionZone(Collider other)
        {
            if (!other.TryGetComponent(out InteractionZone interactionZone))
                return;

            interactionZone.StartInteract(this);
        }

        private void OnTriggerExitInteractionZone(Collider other)
        {
            if (!other.TryGetComponent(out InteractionZone interactionZone))
                return;

            interactionZone.StopInteract(this);
        }
    }
}
