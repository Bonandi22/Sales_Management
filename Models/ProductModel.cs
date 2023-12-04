namespace Sales_Management.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Correção na propriedade SaleItems
        public List<SaleItem>? SaleItems { get; set; }

        // Navigation property for many-to-many com Sales
        public ICollection<SalesModel>? Sales { get; set; }

    }
}
