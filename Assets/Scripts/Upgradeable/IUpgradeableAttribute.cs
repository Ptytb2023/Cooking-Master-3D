namespace Upgradeable
{
    public interface IUpgradeableAttribute
    {
        public float Value { get;}
        public void IncreaseAttribute(float amount);
    }
}
