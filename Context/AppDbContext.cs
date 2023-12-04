using Microsoft.EntityFrameworkCore;
using Sales_Management.Models;

namespace Sales_Management.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SalesmanModel> Salesmen { get; set; }
        public DbSet<SalesModel> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Cliente -> Vendas (Um-para-Muitos)
            modelBuilder.Entity<ClientModel>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Client)
                .HasForeignKey(s => s.ClientId);

            // Vendedor -> Vendas (Um-para-Muitos)
            modelBuilder.Entity<SalesmanModel>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Salesman)
                .HasForeignKey(s => s.SalesmanId);

            // Produto -> Itens_Venda (Um-para-Muitos)
            modelBuilder.Entity<ProductModel>()
                .HasMany(p => p.SaleItems)
                .WithOne(si => si.Product)
                .HasForeignKey(si => si.ProductId);

            // Venda -> Itens_Venda (Um-para-Muitos)
            modelBuilder.Entity<SalesModel>()
                .HasMany(s => s.SaleItems)
                .WithOne(si => si.Sale)
                .HasForeignKey(si => si.SaleId);

            // Configurar relacionamento de muitos-para-muitos entre Produto e Venda
            modelBuilder.Entity<SaleItem>()
                .HasKey(si => new { si.SaleId, si.ProductId });

            modelBuilder.Entity<SaleItem>()
                        .HasOne(si => si.Sale)
                        .WithMany(s => s.SaleItems)
                        .HasForeignKey(si => si.SaleId);

            modelBuilder.Entity<SaleItem>()
                      .HasOne(si => si.Product)
                      .WithMany(p => p.SaleItems)
                      .HasForeignKey(si => si.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}