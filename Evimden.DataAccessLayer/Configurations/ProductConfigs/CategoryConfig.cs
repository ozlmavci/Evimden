using Evimden.CoreLayer.Concrete.ProductEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.ProductConfigs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Primary key
            builder.HasKey(c => c.CategoryId);

            // Properties
            builder.Property(c => c.CategoryId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ParrentCategoryId)
                .IsRequired();

            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            // Relationships
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("Categories");
        }
    }
}



