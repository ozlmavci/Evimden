using Evimden.CoreLayer.Concrete.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CartConfig : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        // Birincil anahtar
        builder.HasKey(c => c.CartId);

        // Özellikler
        builder.Property(c => c.CartId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.SubTotal)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // İlişkiler
        builder.HasMany(c => c.ProductCarts)
            .WithOne(pc => pc.Cart)
            .HasForeignKey(pc => pc.CartId)
            .OnDelete(DeleteBehavior.Cascade);  // Sepet silindiğinde ProductCart silinir.

        // Tabloya eşleme
        builder.ToTable("Carts");
    }
}
