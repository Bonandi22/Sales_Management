using System.ComponentModel.DataAnnotations;

namespace Sales_Management.Models
{
    public class SalesmanModel
    {
        [Key]
        public int SalesmanId { get; set; }        
        public string? FirstName { get; set; }        
        public string? LastName { get; set; }       
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public string? Password { get; set; }
        public ICollection<SalesModel>? Sales { get; set; }

    }
}
