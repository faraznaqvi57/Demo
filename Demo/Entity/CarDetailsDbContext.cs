using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Entity
{
    public class CarDetailsDbContext:DbContext
    {
        public CarDetailsDbContext(DbContextOptions<CarDetailsDbContext> options) : base(options) { }
        public DbSet<CarDetails> cardetails { get; set; }
        public DbSet<login> logins { get; set; }
    }
}
