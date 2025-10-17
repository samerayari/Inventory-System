using System.Collections.Generic;
using System.Linq;

namespace Afl6.Models
{
    public class Inventory
    {
        
        public Dictionary<Item, double> Stock { get; set; } = new();

        
        public void AddStock(Item item, double quantity)
        {
            if (Stock.ContainsKey(item))
                Stock[item] += quantity;
            else
                Stock[item] = quantity;
        }

        
        public void UpdateStockAfterOrder(Order order)
        {
            foreach (var line in order.OrderLines)
            {
                if (Stock.ContainsKey(line.Item))
                    Stock[line.Item] -= line.Quantity;
            }
        }

        
        public List<Item> LowStockItems()
        {
            return Stock.Where(s => s.Value < 5).Select(s => s.Key).ToList();
        }
    }
}