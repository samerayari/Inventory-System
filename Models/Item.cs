namespace Afl6.Models
{
    public class Item
    {
        public string Name { get; set; }
        public double PricePerUnit { get; set; }

        public Item(string name, double pricePerUnit)
        {
            Name = name;
            PricePerUnit = pricePerUnit;
        }

        public override string ToString() => $"{Name} ({PricePerUnit:C})";
    }
}