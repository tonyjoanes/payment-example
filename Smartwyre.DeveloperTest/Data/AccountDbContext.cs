namespace Smartwyre.DeveloperTest.Data
{
    using Microsoft.EntityFrameworkCore;
    using Smartwyre.DeveloperTest.Types;

    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) 
            : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
    }
}
