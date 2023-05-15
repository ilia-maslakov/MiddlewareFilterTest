using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataContext.Entities;
using Store.DataContext.SeedData;

namespace Store.DataContext.Context.StoreDbConfiguration.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        // Properties
        builder.Property(p => p.Id).HasColumnType("uuid").IsRequired();
        builder.Property(p => p.Name).HasMaxLength(64);
        builder.Property(p => p.Email).HasMaxLength(256);
        builder.Property(p => p.Login).HasMaxLength(256);
        builder.Property(p => p.Role).HasColumnType("int");
        builder.Property(p => p.Hash).HasMaxLength(256);

        // Indexes
        builder.HasIndex(p => p.Login).IsUnique();
        builder.HasIndex(p => p.Email);

        // Initial data
        foreach (var user in UserData.Default)
        {
            builder.HasData(user);
        }

    }
}
