using Banking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking_System.Data
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Transaction)
                .WithOne(e => e.Account)
                .HasForeignKey(id => id.AccountId);
                


            base.OnModelCreating(modelBuilder);
        }
    }
}

