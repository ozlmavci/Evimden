using Evimden.CoreLayer.Concrete.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.OrderConfigs
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Primary key
            builder.HasKey(p => p.PaymentId);

            // Properties
            builder.Property(p => p.PaymentId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PaymentType)
                .IsRequired();

            builder.Property(p => p.PaymentInformationId)
                .IsRequired();

            builder.Property(p => p.CouponId);

            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.Property(p => p.TransactionStatus)
                .IsRequired();

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.TaxAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.IsRefunded)
                .IsRequired();

            builder.Property(p => p.RefundDate);

            // Relationships
            builder.HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Order>(o => o.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Coupon)
                .WithOne(c => c.Payment)
                .HasForeignKey<Payment>(p => p.CouponId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.PaymentInformation)
                .WithMany(pi => pi.Payments)
                .HasForeignKey(p => p.PaymentInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("Payments");
        }
    }
}