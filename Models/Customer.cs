using System.Collections.Generic;

namespace Afl6.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new();

        public Customer(string name) => Name = name;

        public void CreateOrder(OrderBook orderBook, Order order)
        {
            Orders.Add(order);
            orderBook.QueueOrder(order);
        }
    }
}