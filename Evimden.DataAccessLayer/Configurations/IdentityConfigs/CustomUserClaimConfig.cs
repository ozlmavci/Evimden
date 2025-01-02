using Evimden.CoreLayer.Concrete.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.IdentityConfigs
{
    public class CustomUserClaimConfig : IEntityTypeConfiguration<CustomUserClaim>
    {
        public void Configure(EntityTypeBuilder<CustomUserClaim> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClaimType)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.ClaimValue)
                .HasMaxLength(1024);

            builder.HasOne(x => x.User)
                .WithMany(y => y.UserClaims)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.ToTable("UserClaims");
        }
    }
}
