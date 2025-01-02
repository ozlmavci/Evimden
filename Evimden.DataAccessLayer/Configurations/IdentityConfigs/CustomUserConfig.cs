using Evimden.CoreLayer.Concrete.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.IdentityConfigs
{
    public class CustomUserConfig : IEntityTypeConfiguration<CustomUser>
    {
        public void Configure(EntityTypeBuilder<CustomUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.NormalizedUserName)
                .HasMaxLength(256);

            builder.Property(x => x.Email)
                .HasMaxLength(256);

            builder.Property(x => x.NormalizedEmail)
                .HasMaxLength(256);

            builder.Property(x => x.FirstName)
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasMaxLength(100);

            builder.HasIndex(x => x.NormalizedUserName)
                .IsUnique()
                .HasDatabaseName("UserNameIndex");

            builder.HasIndex(x => x.NormalizedEmail)
                .HasDatabaseName("EmailIndex");

            builder.ToTable("Users");
        }
    }
}
