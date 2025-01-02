using Evimden.CoreLayer.Concrete.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.IdentityConfigs
{
    public class CustomUserLoginConfig : IEntityTypeConfiguration<CustomUserLogin>
    {
        public void Configure(EntityTypeBuilder<CustomUserLogin> builder)
        {
            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });

            builder.Property(x => x.LoginProvider)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.ProviderKey)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.ProviderDisplayName)
                .HasMaxLength(256);

            builder.HasOne(x => x.User)
                .WithMany(y => y.UserLogins)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.ToTable("UserLogins");


        }
    }
}
