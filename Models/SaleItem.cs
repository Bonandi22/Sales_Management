namespace Sales_Management.Models
{
    public class SaleItem
    {
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ProductPrice { get; set; }

        // Relationships
        public ProductModel? Product { get; set; }
        public SalesModel? Sale { get; set; }
    }
}
