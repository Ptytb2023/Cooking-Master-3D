using ReactivePropertes;
using System;

namespace Shops
{
    public interface IUpgrade
    {
        string Name { get; }
        IReactiveProperty<int> Level { get; }
        IReactiveProperty<int> NextPrice { get; }
        event Action MaxLevel;
    }
}