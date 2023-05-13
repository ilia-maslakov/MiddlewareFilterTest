using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataContext.Entities;
using Store.DataContext.SeedData;

namespace Store.DataContext.Context.StoreDbConfiguration.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            // Properties
            builder.Property(p => p.Id).HasColumnType("uuid").IsRequired();
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1024);
            builder.Property(p => p.Price).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(p => p.Count).IsRequired();

            // Indexes
            builder.HasIndex(p => p.Name);

            // Initial data
            foreach (var product in ProductData.Default)
            {
                builder.HasData(product);
            }
        }
    }
}