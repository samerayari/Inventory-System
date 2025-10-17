namespace Afl6.Models
{
    public class BulkItem : Item
    {
        public string MeasurementUnit { get; set; }

        public BulkItem(string name, double pricePerUnit, string measurementUnit)
            : base(name, pricePerUnit)
        {
            MeasurementUnit = measurementUnit;
        }
    }
}