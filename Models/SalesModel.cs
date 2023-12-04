namespace Sales_Management.Models
{
    public class SalesModel
    {
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }

        // Foreign key for many-to-one relationship
        public int ClientId { get; set; }
        public ClientModel? Client { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<ProductModel>? Products { get; set; }
    }
}
