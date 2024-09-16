using Items;
using UnityEngine;

namespace Player
{
    public class InvenorySlotArm : MonoBehaviour
    {
        [SerializeField] private Transform _handPoint;

        private Item _currentItem;

        public string CurrentItem => _currentItem.Id;
        public bool IsEmpty { get; private set; } = true;

        public void GetItem(Item item)
        {
            if (!IsEmpty)
                return;

            _currentItem = item;
            _currentItem.transform.SetParent(_handPoint);
            _currentItem.transform.position = _handPoint.position;

            IsEmpty = false;
        }

        public Item TakeItem()
        {
            _currentItem.transform.SetParent(null);
            IsEmpty = true;
            return _currentItem;
        }

        //private void Update()
        //{
        //    if (_currentItem != null)
        //        _currentItem.transform.position = _handPoint.position;
        //}
    }
}
