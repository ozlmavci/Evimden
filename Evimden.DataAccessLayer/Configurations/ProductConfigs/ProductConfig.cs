using Evimden.CoreLayer.Concrete.ProductEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Birincil anahtar
        builder.HasKey(p => p.ProductId);

        // Özellikler
        builder.Property(p => p.ProductId)
            .IsRequired()
            .ValueGeneratedOnAdd(); // Guid alanı için otomatik artış.

        builder.Property(p => p.CategoryId)
            .IsRequired();

        builder.Property(p => p.SellerId)
            .IsRequired();

        builder.Property(p => p.ProductName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.DiscountRate)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.ContainGluten)
            .IsRequired();

        builder.Property(p => p.IsVisiable)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(p => p.IsApproved)
            .IsRequired()
            .HasDefaultValue(false);

        // İlişkiler
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction); // Kategori silindiğinde ürünler korunur.

        builder.HasOne(p => p.Seller)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SellerId)
            .OnDelete(DeleteBehavior.Cascade); // Satıcı silindiğinde ürünler silinir.

        builder.HasOne(p => p.ProductApproval)
            .WithOne(pa => pa.Product)
            .HasForeignKey<ProductApproval>(pa => pa.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Images)
            .WithOne(pi => pi.Product)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade); // Ürün silindiğinde görüntüler silinir.

        builder.HasMany(p => p.Orders)
            .WithOne(o => o.Product)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.NoAction); // Sipariş geçmişinin silinmesi istenmez.

        builder.HasMany(p => p.ProductCarts)
            .WithOne(pc => pc.Product)
            .HasForeignKey(pc => pc.ProductId)
            .OnDelete(DeleteBehavior.NoAction); // Ürün silindiğinde ProductCart silinmez.

        // Tabloya eşleme
        builder.ToTable("Products");
    }
}
