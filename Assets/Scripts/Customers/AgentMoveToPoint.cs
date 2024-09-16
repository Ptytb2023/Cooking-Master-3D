using People.Animations;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Customers
{
    public class AgentMoveToPoint : MonoBehaviour
    {
        [SerializeField] private PersonAnimation _personAnimation;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _speed;
        [SerializeField] private float _minDistance;
        [SerializeField] private float _rotationSpeed;

        private Coroutine _moveCoroutine;

        private float _minDistanceSqr;

        public float Radius => _agent.radius;

        private void Awake()
        {
            _minDistanceSqr = _minDistance * _minDistance;
            _agent.stoppingDistance = _minDistance;
        }

        public void Move(Vector3 point)
        {
            if (_moveCoroutine != null)
                StopCoroutine(_moveCoroutine);

            _moveCoroutine = StartCoroutine(MoveCoroutine(point));
        }

        private IEnumerator MoveCoroutine(Vector3 point)
        {
            _agent.destination = point;
            _personAnimation.PlayMove(true);

            while (gameObject.activeSelf && enabled)
            {
                if (Vector3.SqrMagnitude(_agent.transform.position - point) <= _minDistanceSqr)
                {
                    _personAnimation.PlayMove(false);
                    yield break;
                }

                RotateTowards(point);

                yield return null;
            }
        }

        private void RotateTowards(Vector3 targetPosition)
        {
            Vector3 direction = (targetPosition - _agent.transform.position).normalized;


            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _agent.transform.rotation = Quaternion.Slerp(_agent.transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}
