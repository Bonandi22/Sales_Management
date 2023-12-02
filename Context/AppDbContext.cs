using Microsoft.EntityFrameworkCore;

namespace Sales_Management.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }




    }
}