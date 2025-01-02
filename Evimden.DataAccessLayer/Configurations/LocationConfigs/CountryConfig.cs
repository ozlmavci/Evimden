using Evimden.CoreLayer.Concrete.LocationEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Primary key
        builder.HasKey(c => c.CountryId);

        // Properties
        builder.Property(c => c.CountryId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(c => c.CountryName)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships
        builder.HasMany(c => c.Cities)
            .WithOne(ci => ci.Country)
            .HasForeignKey(ci => ci.CountryId)
            .OnDelete(DeleteBehavior.NoAction); // Döngüyü önlemek için NoAction

        builder.HasMany(c => c.Sellers)
            .WithOne(s => s.Country)
            .HasForeignKey(s => s.CountryId)
            .OnDelete(DeleteBehavior.Cascade); // Uygun olan yerde Cascade bırakıldı.

        builder.HasMany(c => c.Shippers)
            .WithOne(sh => sh.Country)
            .HasForeignKey(sh => sh.CountryId)
            .OnDelete(DeleteBehavior.Cascade); // Uygun olan yerde Cascade bırakıldı.

        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.Country)
            .HasForeignKey(a => a.CountryId)
            .OnDelete(DeleteBehavior.NoAction); // NoAction kullanıldı.

        // Table mapping
        builder.ToTable("Countries");
    }
}
