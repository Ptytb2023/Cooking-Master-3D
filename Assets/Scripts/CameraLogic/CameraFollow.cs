using UnityEngine;

namespace CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _offsetY;
        [SerializeField] private float _distance;
        [SerializeField] private Vector3 _rotationAngle;

        [Space]
        [SerializeField] private Transform _follower;
     
        public Transform Transform => transform;

        private void LateUpdate()
        {
            Quaternion rotation = Quaternion.Euler(_rotationAngle);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(Transform followerTransform) =>
         _follower = followerTransform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followPosition = _follower.position;
            followPosition.y += _offsetY;
            return followPosition;
        }
    }
}
