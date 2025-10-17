using System;
using System.Collections.Generic;
using System.Linq;

namespace Afl6.Models
{
    public class Order
    {
        public DateTime Time { get; set; } = DateTime.Now;
        public List<OrderLine> OrderLines { get; set; } = new();
        public double TotalPrice() => OrderLines.Sum(x => x.TotalPrice());
        public override string ToString() => $"Order - {TotalPrice():C}";
    }
}