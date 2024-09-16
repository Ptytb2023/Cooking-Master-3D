using CookingMaster;
using Items;
using Player;
using UnityEngine;

namespace Customers
{
    public class Customer : MonoBehaviour, IPoolable
    {
        [SerializeField] private string _idItemOrder;
        [SerializeField] private InvenorySlotArm _invenorySlot;
        [SerializeField] private AgentMoveToPoint _agentMovement;
        [SerializeField] private AgentPositionChecker _agentChecker;

        private bool _isServe;
        private ExitZone _exitZone;

        public void Init(ExitZone exitZone) =>
            _exitZone = exitZone;

        public InvenorySlotArm InvenorySlotArm => _invenorySlot;
        public string IdItemOrder => _idItemOrder;

        public void MoveUpInLine(Vector3 position) =>
            _agentChecker.MoveAfterCheck(position);

        public void Serve(Item item)
        {
            _invenorySlot.GetItem(item);
            _agentMovement.Move(_exitZone.Position);
        }

        public void Spawn()
        {
        }

        public void Despawn()
        {
        }
    }
}
