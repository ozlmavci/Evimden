using Evimden.CoreLayer.Concrete.ProductEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.ProductConfigs
{
    public class ProductApprovalConfig : IEntityTypeConfiguration<ProductApproval>
    {
        public void Configure(EntityTypeBuilder<ProductApproval> builder)
        {
            // Primary key
            builder.HasKey(pa => pa.ProductApprovalId);

            // Properties
            builder.Property(pa => pa.ProductApprovalId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pa => pa.ProductId)
                .IsRequired();

            builder.Property(pa => pa.SellerId)
                .IsRequired();

            builder.Property(pa => pa.RequestStatus)
                .IsRequired();

            // Relationships
            builder.HasOne(pa => pa.Product)
                .WithOne(p => p.ProductApproval)
                .HasForeignKey<ProductApproval>(pa => pa.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("ProductApprovals");
        }
    }
}



