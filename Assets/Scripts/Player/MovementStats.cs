using System;

namespace Player
{
    public class MovementStats : IMutableMovementStats
    {
        private float _speed;

        public MovementStats(float initialSpeed) =>
            _speed = ValidateParameter(initialSpeed, nameof(initialSpeed));

        public float Speed => _speed;

        public void MultiplySpeed(float multiplier) => 
            _speed *= ValidateParameter(multiplier, nameof(multiplier));

        public void SetSpeed(float newSpeed) => 
            _speed = ValidateParameter(newSpeed, nameof(newSpeed));

        private float ValidateParameter(float value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentException($"{paramName} cannot be negative or zero.", paramName);

            return value;
        }
    }


}