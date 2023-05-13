using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataContext.Entities;

namespace Store.DataContext.Context.StoreDbConfiguration.SeedWork;

public static class EntityTypeBuilderExtensions
{
    public static void ConfigureEntitySignature<T>(this EntityTypeBuilder<T> builder) where T : class, IEntitySignature
    {
        builder.Property(p => p.CreatedById).HasColumnType("uuid").IsRequired();
        builder.Property(p => p.UpdatedById).HasColumnType("uuid");

        builder.HasOne(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.UpdatedBy).WithMany().HasForeignKey(p => p.UpdatedById)
            .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.CreatedAt);
        builder.HasIndex(p => p.CreatedById);
        builder.HasIndex(p => p.UpdatedAt);
        builder.HasIndex(p => p.UpdatedById);
    }

    public static void ConfigureDeleteSignature<T>(this EntityTypeBuilder<T> builder) where T : class, IDeleteSignature
    {
        // Не возвращаем удаленные сущности
        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.Property(p => p.DeletedById).HasColumnType("uuid");

        builder.HasOne(p => p.DeletedBy).WithMany().HasForeignKey(p => p.DeletedById)
            .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.DeletedAt);
        builder.HasIndex(p => p.DeletedById);
    }

    public static void ConfigureActionSignature<T>(this EntityTypeBuilder<T> builder) where T : class, IActionSignature
    {
        builder.Property(p => p.DoneById).HasColumnType("uuid").IsRequired();

        builder.HasOne(p => p.DoneBy).WithMany().HasForeignKey(p => p.DoneById)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.DoneAt);
        builder.HasIndex(p => p.DoneById);
    }
}
