using Evimden.CoreLayer.Concrete.ProfileEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // Primary key
        builder.HasKey(a => a.AddressId);

        // Properties
        builder.Property(a => a.AddressId).IsRequired().ValueGeneratedOnAdd();
        builder.Property(a => a.UserId).IsRequired();
        builder.Property(a => a.PhoneId).IsRequired();
        builder.Property(a => a.CountryId).IsRequired();
        builder.Property(a => a.CityId).IsRequired();
        builder.Property(a => a.DistrictId).IsRequired();
        builder.Property(a => a.AddressText).HasMaxLength(500);
        builder.Property(a => a.IsFavorite).IsRequired();
        builder.Property(a => a.IsActive).IsRequired();
        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.UpdatedDate).IsRequired();

        // Relationships
        builder.HasOne(a => a.City)
            .WithMany()
            .HasForeignKey(a => a.CityId)
            .OnDelete(DeleteBehavior.NoAction); // Döngüyü önlemek için NoAction kullanıldı.

        builder.HasOne(a => a.Country)
            .WithMany()
            .HasForeignKey(a => a.CountryId)
            .OnDelete(DeleteBehavior.NoAction); // Döngüyü önlemek için NoAction kullanıldı.

        builder.HasOne(a => a.District)
            .WithMany()
            .HasForeignKey(a => a.DistrictId)
            .OnDelete(DeleteBehavior.NoAction); // Döngüyü önlemek için NoAction kullanıldı.

        builder.HasOne(a => a.Phone)
            .WithMany()
            .HasForeignKey(a => a.PhoneId)
            .OnDelete(DeleteBehavior.Cascade); // Phone'da Cascade uygun olabilir.

        builder.HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.NoAction); // Döngüyü önlemek için NoAction kullanıldı.

        // Table mapping
        builder.ToTable("Addresses");
    }
}
