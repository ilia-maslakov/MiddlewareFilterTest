using Microsoft.EntityFrameworkCore;
using Store.DataContext.Entities;

namespace Store.DataContext.Context
{
    public class StoreDbContext : DbContext, IStoreDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
            Products = Set<Product>();
            Users = Set<User>();
            
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=storebase;Username=StoreDBAdmin;Password=Store123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Addd the Postgres Extension for UUID generation
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }
    }
}