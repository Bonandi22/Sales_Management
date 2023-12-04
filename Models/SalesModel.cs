namespace Sales_Management.Models
{
    public class SalesModel
    {
        public int? SalesId { get; set; }
        public DateTime? SalesDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? SalesmanId { get; set; }
        public int? ClientId { get; set; }

        // Relationships
        public SalesmanModel? Salesman { get; set; }
        public ClientModel? Client { get; set; }
        public ICollection<SaleItem>? SaleItems { get; set; }
    }
}
