using Bank.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {
                
        }

        public DbSet<BankAccount> BankAccount { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
