using Evimden.CoreLayer.Concrete.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.IdentityConfigs
{
    public class CustomUserTokenConfig : IEntityTypeConfiguration<CustomUserToken>
    {
        public void Configure(EntityTypeBuilder<CustomUserToken> builder)
        {
            builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            builder.Property(x => x.LoginProvider)
              .IsRequired()
              .HasMaxLength(128);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasMaxLength(128);

            builder.Property(x => x.Value)
              .HasMaxLength(2048);

            builder.HasOne(x => x.User)
                .WithMany(y => y.UserTokens)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.ToTable("UserTokens");
        }
    }
}
