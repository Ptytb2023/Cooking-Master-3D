using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class PcInputService : IInputService
    {
        public Vector2 Axis => GetInputUnityAxis();

        private  Vector2 GetInputUnityAxis()
        {
            float horizontal = UnityEngine.Input.GetAxis(InputAxes.Horizontal);
            float vertical = UnityEngine.Input.GetAxis(InputAxes.Vertical);

            return new Vector2(horizontal, vertical);
        }
    }

}

