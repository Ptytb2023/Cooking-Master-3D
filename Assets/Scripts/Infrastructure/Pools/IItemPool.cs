using Items;

namespace Infrastructure.Pools
{
    public interface IItemPool
    {
        Item Get(string id);
        void Return(Item item);
    }
}