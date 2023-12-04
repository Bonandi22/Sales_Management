﻿namespace Sales_Management.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Navigation properties
        public ICollection<SalesModel>? Sales { get; set; }
        public ICollection<SalesmanModel>? Salesmen { get; set; }
    }
}
