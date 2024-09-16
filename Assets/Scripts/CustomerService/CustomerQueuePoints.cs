using UnityEngine;

namespace CustomerService
{
    public class CustomerQueuePoints : MonoBehaviour
    {
        [SerializeField][Min(1)] private int _maxClients = 3;
        [SerializeField] private float _offsetBetweenClients = 0.5f;
        [SerializeField] private Vector3 _directionCustomersQueue = Vector3.forward;

        private Vector3[] _points;

        public Vector3[] Points => _points;
        public int MaxClients => _maxClients;

        private void GenerateQueuePoints()
        {
            _points = new Vector3[_maxClients];

            for (int i = 0; i < _maxClients; i++)
                _points[i] = transform.position + _directionCustomersQueue.normalized * i * _offsetBetweenClients;
        }

        private void OnDrawGizmosSelected()
        {
            if (_points != null)
                for (int i = 0; i < _points.Length; i++)
                    Gizmos.DrawSphere(_points[i], 1f);
        }

        private void OnValidate() =>
            GenerateQueuePoints();
    }

}
