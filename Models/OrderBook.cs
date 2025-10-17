using System.Collections.ObjectModel;
using System.Linq;

namespace Afl6.Models
{
    public class OrderBook
    {
        public ObservableCollection<Order> QueuedOrders { get; } = new();
        public ObservableCollection<Order> ProcessedOrders { get; } = new();

        public Inventory Inventory { get; } = new(); 

        public void QueueOrder(Order order)
        {
            QueuedOrders.Add(order);
        }

        public void ProcessNextOrder()
        {
            if (QueuedOrders.Count == 0) return;
            var next = QueuedOrders.First();
            QueuedOrders.RemoveAt(0);
            ProcessedOrders.Add(next);

           
            Inventory.UpdateStockAfterOrder(next);
        }

        public double TotalRevenue() => ProcessedOrders.Sum(o => o.TotalPrice());
    }
}