using bank.Entity;
using Microsoft.EntityFrameworkCore;

namespace bank.Repository.Implementation
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
