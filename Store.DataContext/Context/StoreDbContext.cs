using Microsoft.EntityFrameworkCore;
using Store.DataContext.Entities;

public class StoreDbContext : DbContext
{
    public StoreDbContext() { }

    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) {}


    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

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
