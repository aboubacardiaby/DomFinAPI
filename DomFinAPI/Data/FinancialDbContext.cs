using Microsoft.EntityFrameworkCore;

namespace DomFinAPI.Data
{
    public class FinancialDbContext : DbContext
    {
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Account> Accounts { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations if necessary
        }
    }
}
