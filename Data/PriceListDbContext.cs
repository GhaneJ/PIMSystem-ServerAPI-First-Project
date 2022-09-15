using ListPriceGeneralAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ListPriceGeneralAPI.Data
{
    public class PriceListDbContext : DbContext
    {
        public PriceListDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
