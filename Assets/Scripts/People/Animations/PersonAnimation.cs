using UnityEngine;

namespace People.Animations
{
    [RequireComponent(typeof(Animator))]
    public class PersonAnimation : MonoBehaviour, IPersonAnimation
    {
        private readonly int _walkStateHash = Animator.StringToHash("Walk");
        private readonly int _idelStateHash = Animator.StringToHash("Idel");

        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayMove(bool isMove) =>
            _animator.SetBool(_walkStateHash, isMove);

        public void PlayIdel() =>
            _animator.SetTrigger(_idelStateHash);
    }
}