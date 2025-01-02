using Evimden.CoreLayer.Concrete.LocationEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        // Primary key
        builder.HasKey(c => c.CityId);

        // Properties
        builder.Property(c => c.CityId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(c => c.CountryId)
            .IsRequired();

        builder.Property(c => c.CityName)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships
        builder.HasOne(c => c.Country)
            .WithMany(cn => cn.Cities)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.NoAction); // Döngüyü önlemek için NoAction

        builder.HasMany(c => c.Districts)
            .WithOne(d => d.City)
            .HasForeignKey(d => d.CityId)
            .OnDelete(DeleteBehavior.Cascade); // Uygun olan yerde Cascade bırakıldı.

        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.City)
            .HasForeignKey(a => a.CityId)
            .OnDelete(DeleteBehavior.NoAction); // NoAction olarak ayarlandı.

        builder.HasMany(c => c.Sellers)
            .WithOne(s => s.City)
            .HasForeignKey(s => s.CityId)
            .OnDelete(DeleteBehavior.NoAction); // NoAction olarak ayarlandı.

        // Table mapping
        builder.ToTable("Cities");
    }
}
