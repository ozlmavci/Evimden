using Evimden.CoreLayer.Concrete.ProductEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.ProductConfigs
{
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // Primary key
            builder.HasKey(pi => pi.ProductImageId);

            // Properties
            builder.Property(pi => pi.ProductImageId)
                .IsRequired()
                .ValueGeneratedOnAdd(); //Guid tipinde bir alan olduğu için ValueGeneratedOnAdd() metodu ile otomatik artan bir alan oluşturur.

            builder.Property(pi => pi.ProductId)
                .IsRequired();

            builder.Property(pi => pi.ImagePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(pi => pi.SavedFileName)
                .HasMaxLength(255);

            // Relationships
            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("ProductImages");
        }
    }
}