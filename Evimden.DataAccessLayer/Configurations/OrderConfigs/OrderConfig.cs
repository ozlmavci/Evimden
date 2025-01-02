using Evimden.CoreLayer.Concrete.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.OrderConfigs
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary key
            builder.HasKey(o => o.OrderId);

            // Properties
            builder.Property(o => o.OrderId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(o => o.SellerId)
                .IsRequired();

            builder.Property(o => o.UserId)
                .IsRequired();

            builder.Property(o => o.AddressId)
                .IsRequired();

            builder.Property(o => o.PaymentId)
                .IsRequired();

            builder.Property(o => o.ProductId)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.OrderStatus)
                .IsRequired();

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.CargoTrackingCode)
                .IsRequired()
                .HasMaxLength(50);

            // Relationships
            builder.HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Order>(o => o.PaymentId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict or NoAction if desired

            builder.HasOne(o => o.Seller)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict or NoAction

            builder.HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict or NoAction

            builder.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict or NoAction

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict or NoAction

            // Table mapping
            builder.ToTable("Orders");
        }
    }
}
