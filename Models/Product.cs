namespace ClassicModels.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public int ProductLineId { get; set; }
        public string ProductLine { get; set; }
        public string ProductName { get; set; }
        public string ProductScale { get; set; }
        public string ProductVendor { get; set; }
        public string ProductDescription { get; set; }
        public int QuantityInStock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal Msrp { get; set; }

        public string FormatPrice()
        {
            return "$" + Msrp.ToString();
        }
    }
}