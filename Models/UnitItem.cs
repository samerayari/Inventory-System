namespace Afl6.Models
{
    public class UnitItem : Item
    {
        public double Weight { get; set; }

        public UnitItem(string name, double pricePerUnit, double weight)
            : base(name, pricePerUnit)
        {
            Weight = weight;
        }
    }
}