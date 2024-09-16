using System;
using UnityEngine;

namespace Interactions
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> Enter;
        public event Action<Collider> Exit;

        private void OnTriggerEnter(Collider other) =>
            Enter?.Invoke(other);

        private void OnTriggerExit(Collider other) =>
            Exit?.Invoke(other);

        private void OnValidate() =>
            GetComponent<Collider>().isTrigger = true;

    }
}
