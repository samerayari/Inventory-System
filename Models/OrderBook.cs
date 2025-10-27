using System.Collections.Generic;
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

        // Behandler næste ordre og returnerer dens ordrelinjer
        public List<OrderLine> ProcessNextOrder()
        {
            if (QueuedOrders.Count == 0)
                return new List<OrderLine>();

            
            var nextOrder = QueuedOrders[0];
            QueuedOrders.RemoveAt(0); 
            ProcessedOrders.Add(nextOrder); 

            
            Inventory.UpdateStockAfterOrder(nextOrder);

         
            return nextOrder.OrderLines;
        }
        
        public double TotalRevenue()
        {
            double total = 0;
            foreach (var order in ProcessedOrders)
                total += order.TotalPrice();
            return total;
        }
    }
}