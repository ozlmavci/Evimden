using Evimden.CoreLayer.Concrete.ProfileEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.ProfileConfigs
{
    public class PaymentInformationConfig : IEntityTypeConfiguration<PaymentInformation>
    {
        public void Configure(EntityTypeBuilder<PaymentInformation> builder)
        {
            // Primary key
            builder.HasKey(pi => pi.PaymentInformationId);

            // Properties
            builder.Property(pi => pi.PaymentInformationId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pi => pi.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(pi => pi.CardHolderName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pi => pi.ExpirationMonth)
                .IsRequired();

            builder.Property(pi => pi.ExpirationYear)
                .IsRequired();

            builder.Property(pi => pi.Cvv)
                .IsRequired()
                .HasMaxLength(4);

            // Relationships
            builder.HasMany(pi => pi.Payments)
                .WithOne(p => p.PaymentInformation)
                .HasForeignKey(p => p.PaymentInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table mapping
            builder.ToTable("PaymentInformations");
        }
    }
}