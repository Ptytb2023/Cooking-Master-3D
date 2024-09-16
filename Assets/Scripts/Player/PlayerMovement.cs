using Upgradeable;
using Data;
using Infrastructure.Services.Input;
using People.Animations;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour, IUpgradeableAttribute
    {
        private const float Epsilon = 0.001f;

        [SerializeField] private PersonAnimation _personAnimation;

        private CharacterController _characterController;
        private Camera _camera;

        private IInputService _inputService;
        private float _speedMove;

        public float Value => _speedMove;

        [Inject]
        private void Constructor(IInputService inputService, GameData gameData)
        {
            _inputService = inputService;
            _speedMove = gameData.PlayerMoveSpeed;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector2 axis = _inputService.Axis;

            if (axis.sqrMagnitude < Epsilon)
            {
                _personAnimation.PlayMove(false);
                return;
            }

            Vector3 direction = CalculateMovementDirection(axis);
            RotatePlayer(direction);

            Vector3 newPosition = direction * (_speedMove * Time.deltaTime);
            _characterController.Move(newPosition);

            _personAnimation.PlayMove(true);
        }

        public void IncreaseAttribute(float amount) => 
            _speedMove = amount;

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