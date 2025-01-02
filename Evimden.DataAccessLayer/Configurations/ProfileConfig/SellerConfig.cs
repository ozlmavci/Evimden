using Evimden.CoreLayer.Concrete.ProfileEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.ProfileConfigs
{
    public class SellerConfig : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            // Primary key
            builder.HasKey(s => s.SellerId);

            // Properties
            builder.Property(s => s.SellerId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(s => s.UserId)
                .IsRequired();

            builder.Property(s => s.CountryId)
                .IsRequired();

            builder.Property(s => s.CityId)
                .IsRequired();

            builder.Property(s => s.DistrictId)
                .IsRequired();

            builder.Property(s => s.ShopName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Tckn)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(s => s.Vkn)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.ShopImagePath)
                .HasMaxLength(500);

            builder.Property(s => s.About)
                .HasMaxLength(1000);

            builder.Property(s => s.IsApproved)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(s => s.IsBanned)
                .IsRequired()
                .HasDefaultValue(false);

            // Relationships
            builder.HasOne(s => s.Country)
                .WithMany(c => c.Sellers)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.City)
                .WithMany(c => c.Sellers)
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.District)
                .WithMany(d => d.Sellers)
                .HasForeignKey(s => s.DistrictId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Orders)
                .WithOne(o => o.Seller)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SellerApprovals)
                .WithOne(sa => sa.Seller)
                .HasForeignKey(sa => sa.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("Sellers");
        }
    }
}