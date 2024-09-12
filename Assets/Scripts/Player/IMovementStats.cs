namespace Player
{
    public interface IMovementStats
    {
        float Speed { get; }
    }

    public interface IMutableMovementStats : IMovementStats
    {
        void MultiplySpeed(float multiplier);
        void SetSpeed(float newSpeed);
    }
}