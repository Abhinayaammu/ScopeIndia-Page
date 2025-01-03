using Microsoft.EntityFrameworkCore;

namespace Project1.Entity
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }
        public DbSet<UserAccount> UserAccounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
        {
           base.OnModelCreating(modelBuilder);
        }
        
    }
}
