using UnityEngine;

namespace Infrastructure.Services.Input
{
    internal class StandaloneInputService : IInputService
    {
        private PcInputService _pcInputService;
        private MobileInputService _mobileInputService;

        public StandaloneInputService()
        {
            _pcInputService = new PcInputService();
            _mobileInputService = new MobileInputService();
        }

        public Vector2 Axis
        {
            get
            {
                Vector2 axis = _mobileInputService.Axis;

                if (axis == Vector2.zero)
                    axis = _pcInputService.Axis;

                return axis;
            }
        }
    }
}
