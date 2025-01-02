using Evimden.CoreLayer.Concrete.CargoEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.CargoConfigs
{
    public class ShipperConfig : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            // Primary key
            builder.HasKey(s => s.ShipperId);

            // Properties
            builder.Property(s => s.ShipperId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(s => s.CountryId)
                .IsRequired();

            builder.Property(s => s.ShipperName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.ContactName)
                .HasMaxLength(100);

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(s => s.Email)
                .HasMaxLength(100);

            builder.Property(s => s.ApiUrl)
                .HasMaxLength(200);

            builder.Property(s => s.ApiKey)
                .HasMaxLength(100);

            // Relationships
            builder.HasOne(s => s.Country)
                .WithMany(c => c.Shippers)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("Shippers");
        }
    }
}