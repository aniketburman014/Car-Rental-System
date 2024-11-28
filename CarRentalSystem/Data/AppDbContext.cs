using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Car> CarsDbContext { get; set; }
        public DbSet<Transaction> TransactionsDbContext { get; set; }
    }
}
