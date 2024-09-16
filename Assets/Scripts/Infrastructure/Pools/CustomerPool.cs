using Customers;
using Infrastructure.Factorys;
using Infrastructure.Services.Assets;
using Zenject;

namespace Infrastructure.Pools
{
    public class CustomerPool : ICustomerPool
    {
        private ObjectPool<Customer> _pool;

        [Inject]
        public CustomerPool(IAssetProvider assetProvider, IFactoryObject factoryObject)
        {
            _pool = new ObjectPool<Customer>(assetProvider.GetCustomerPrefab(), factoryObject);
        }

        public Customer Get() =>
            _pool.Get();

        public void Return(Customer customer) =>
            _pool.Return(customer);
    }
}


