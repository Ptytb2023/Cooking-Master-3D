using UnityEngine;

namespace UI
{
    public class UIBillboard : MonoBehaviour
    {
        private Camera _camera;

        private void Awake() => 
            _camera = Camera.main;

        private void LateUpdate() => 
            LookAtCamera();

        private void LookAtCamera()
        {
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward,
                         _camera.transform.rotation * Vector3.up);
        }
    }
}
