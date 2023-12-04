namespace Sales_Management.Models
{
    public class SalesmanModel
    {
        public int SalesmanId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }

        // Foreign key for many-to-one relationship
        public int ClientId { get; set; }
        public ClientModel? Client { get; set; }

        // Navigation properties
        public SalesmanModel? Salesman { get; set; }
        public ICollection<ProductModel>? Products { get; set; }
        public ICollection<SalesModel>? Sales { get; set; }
    }
}
