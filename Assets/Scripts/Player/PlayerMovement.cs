using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float Elipsion = 0.001f;

        private CharacterController _characterController;
        private Camera _camera;

        private IInputService _inputService;
        private IMovementStats _movementStats;

        [Inject]
        private void Constructor(IInputService inputService, IMovementStats moventStat)
        {
            _inputService = inputService;
            _movementStats = moventStat;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector2 axis = _inputService.Axis;

            if (axis.sqrMagnitude < Elipsion)
                return;

            Vector3 direction = CalculateMovementDirection(axis);
            RotatePlayer(direction);

            Vector3 newPosition = direction * (_movementStats.Speed * Time.deltaTime);
            _characterController.Move(newPosition);
        }

        private void RotatePlayer(Vector3 direction) => 
            transform.forward = direction;

        private Vector3 CalculateMovementDirection(Vector2 axis)
        {
            Vector3 direction = _camera.transform.TransformDirection(axis);
            direction.y = 0;
            return direction.normalized;
        }
    }
}