using System;
using Player;
using Unity.Android.Types;
using UnityEngine;

namespace Interactions
{
    [RequireComponent(typeof(Collider))]
    public class InteractionZone : MonoBehaviour
    {
        [SerializeField] private Color _colorInteract;
        [SerializeField] private Sprite _spriteZone;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Color _startColorSprite;

        public event Action<PlayerInteractor> PlayerStartInteract;
        public event Action<PlayerInteractor> PlayerStopInteract;

        public void StartInteract(PlayerInteractor playerInteractor)
        {
            _startColorSprite = _spriteRenderer.color;

            if (playerInteractor == null)
                throw new ArgumentNullException();

            PlayerStartInteract?.Invoke(playerInteractor);

            _spriteRenderer.color = _colorInteract;
        }

        public void StopInteract(PlayerInteractor playerInteractor)
        {
            if (playerInteractor == null)
                throw new ArgumentNullException();

            PlayerStopInteract?.Invoke(playerInteractor);

            _spriteRenderer.color = _startColorSprite;
        }

        private void OnValidate()
        {
            GetComponent<Collider>().isTrigger = true;

            if (_spriteRenderer != null && _spriteZone != null)
                _spriteRenderer.sprite = _spriteZone;
        }
    }
}
