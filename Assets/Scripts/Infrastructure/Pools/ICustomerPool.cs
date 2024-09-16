using Customers;

namespace Infrastructure.Pools
{
    public interface ICustomerPool
    {
        Customer Get();
        void Return(Customer customer);
    }
}