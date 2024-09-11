using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class MobileInputService : IInputService
    {
        public Vector2 Axis => GetInputSimpleAxis();
        private Vector2 GetInputSimpleAxis()
        {
            float horizontal = SimpleInput.GetAxis(InputAxes.Horizontal);
            float vertical = SimpleInput.GetAxis(InputAxes.Vertical);

            return new Vector2(horizontal, vertical);
        }
    }
}

