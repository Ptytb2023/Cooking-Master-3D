using System.Collections;
using UnityEngine;

namespace Customers
{
    public class AgentPositionChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPoint _agent;
        [SerializeField] private LayerMask _obstacleMask;

        private Coroutine _checkFreePointCoroutine;

        public void MoveAfterCheck(Vector3 point)
        {
            if (_checkFreePointCoroutine != null)
                StopCoroutine(_checkFreePointCoroutine);

            _checkFreePointCoroutine = StartCoroutine(CheckFreePointCoroutine(point));
        }

        private IEnumerator CheckFreePointCoroutine(Vector3 point)
        {
            while (gameObject.activeSelf && enabled)
            {
                if (IsPointFree(point))
                {
                    _agent.Move(point);
                    yield break;
                }

                yield return new WaitForFixedUpdate();
            }
        }

        private bool IsPointFree(Vector3 targetPosition)
        {
            float checkRadius = _agent.Radius;
            return !Physics.CheckSphere(targetPosition, checkRadius, _obstacleMask);
        }
    }
}
