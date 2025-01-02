using Evimden.CoreLayer.Concrete.ProfileEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.ProfileConfigs
{
    public class SellerApprovalConfig : IEntityTypeConfiguration<SellerApproval>
    {
        public void Configure(EntityTypeBuilder<SellerApproval> builder)
        {
            // Primary key
            builder.HasKey(sa => sa.SellerApprovalId);

            // Properties
            builder.Property(sa => sa.SellerApprovalId)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Guid tipinde bir alan olduğu için ValueGeneratedOnAdd() metodu ile otomatik artan bir alan oluşturulur.

            builder.Property(sa => sa.SellerId)
                .IsRequired();

            builder.Property(sa => sa.ApprovalStatus)
                .IsRequired();

            // Relationships
            builder.HasOne(sa => sa.Seller)
                .WithMany(s => s.SellerApprovals)
                .HasForeignKey(sa => sa.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("SellerApprovals");
        }
    }
}