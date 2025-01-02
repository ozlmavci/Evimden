using Evimden.CoreLayer.Concrete.ProfileEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.ProfileConfigs
{
    public class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            // Primary key
            builder.HasKey(p => p.PhoneId);

            // Properties
            builder.Property(p => p.PhoneId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            // Relationships
            builder.HasMany(p => p.Addresses)
                .WithOne(a => a.Phone)
                .HasForeignKey(a => a.PhoneId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("Phones");
        }
    }
}