using Evimden.CoreLayer.Concrete.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.OrderConfigs
{
    public class CouponConfig : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            // Primary key
            builder.HasKey(c => c.CouponId);

            // Properties
            builder.Property(c => c.CouponId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.Amount)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Rate)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.ExpirationDate)
                .IsRequired();

            builder.Property(c => c.IsUsed)
                .IsRequired();

            // Relationships
            builder.HasOne(c => c.Payment)
                .WithOne(p => p.Coupon)
                .HasForeignKey<Payment>(p => p.CouponId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("Coupons");
        }
    }
}

