using PIM_API.Models;
using Microsoft.EntityFrameworkCore;

namespace PIM_API.Data
{
    public class PriceAPIDbContext : DbContext
    {
        public PriceAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
