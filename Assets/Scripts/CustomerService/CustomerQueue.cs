using Customers;
using System;
using System.Collections.Generic;

namespace CustomerService
{
    public class CustomerQueue
    {
        private CustomerQueuePoints _customerQueuePoints;

        private Queue<Customer> _customers = new Queue<Customer>();

        public CustomerQueue(CustomerQueuePoints customerQueuePoints)
        {
            _customerQueuePoints = customerQueuePoints;
            _customers = new Queue<Customer>();
        }

        public int Count => _customers.Count;

        public void EnqueueCustomer(Customer customer)
        {
            if (_customers.Count > _customerQueuePoints.MaxClients)
                throw new ArgumentException();

            _customers.Enqueue(customer);

            UpdateQueuePositions();
        }

        public Customer DequeueCustomer()
        {
            if (_customers.Count <= 0)
                return null;

            Customer customer = _customers.Dequeue();

            UpdateQueuePositions();

            return customer;
        }

        private void UpdateQueuePositions()
        {
            int index = 0;
            foreach (var customer in _customers)
                customer.MoveUpInLine(_customerQueuePoints.Points[index++]);
        }
    }
}
