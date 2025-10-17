namespace Afl6.Models
{
    public class OrderLine
    {
        public Item Item { get; set; }
        public double Quantity { get; set; }

        public OrderLine(Item item, double quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public double TotalPrice() => Item.PricePerUnit * Quantity;

        public override string ToString() => $"{Item.Name} x{Quantity} = {TotalPrice():C}";
    }
}