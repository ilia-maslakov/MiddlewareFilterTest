using Microsoft.EntityFrameworkCore;
using Store.DataContext.Entities;

public interface IStoreDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
