using Evimden.CoreLayer.Concrete.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ProductCartConfig : IEntityTypeConfiguration<ProductCart>
{
    public void Configure(EntityTypeBuilder<ProductCart> builder)
    {
        // Birincil anahtar
        builder.HasKey(pc => pc.ProductCartId);

        // Özellikler
        builder.Property(pc => pc.ProductCartId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(pc => pc.CartId)
            .IsRequired();

        builder.Property(pc => pc.ProductId)
            .IsRequired();

        builder.Property(pc => pc.Quantity)
            .IsRequired();

        // İlişkiler
        builder.HasOne(pc => pc.Cart)
            .WithMany(c => c.ProductCarts)
            .HasForeignKey(pc => pc.CartId)
            .OnDelete(DeleteBehavior.Cascade); // Cart silindiğinde ProductCart silinir.

        builder.HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCarts)
            .HasForeignKey(pc => pc.ProductId)
            .OnDelete(DeleteBehavior.NoAction);  // Product silindiğinde ProductCart silinmez.

        // Tabloya eşleme
        builder.ToTable("ProductCarts");
    }
}
