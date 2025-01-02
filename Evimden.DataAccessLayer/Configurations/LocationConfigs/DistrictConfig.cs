using Evimden.CoreLayer.Concrete.LocationEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class DistrictConfig : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        // Primary key
        builder.HasKey(d => d.DistrictId);

        // Properties
        builder.Property(d => d.DistrictId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(d => d.CityId)
            .IsRequired();

        builder.Property(d => d.CountryId)
            .IsRequired();

        builder.Property(d => d.DistrictName)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships
        builder.HasOne(d => d.City)
            .WithMany(c => c.Districts)
            .HasForeignKey(d => d.CityId)
            .OnDelete(DeleteBehavior.NoAction); // NoAction kullanıldı.

        builder.HasMany(d => d.Addresses)
            .WithOne(a => a.District)
            .HasForeignKey(a => a.DistrictId)
            .OnDelete(DeleteBehavior.NoAction); // NoAction kullanıldı.

        builder.HasMany(d => d.Sellers)
            .WithOne(s => s.District)
            .HasForeignKey(s => s.DistrictId)
            .OnDelete(DeleteBehavior.Cascade); // Uygun olan yerde Cascade bırakıldı.

        // Table mapping
        builder.ToTable("Districts");
    }
}
