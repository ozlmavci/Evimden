using Evimden.CoreLayer.Concrete.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.IdentityConfigs
{
    public class CustomRoleClaimConfig : IEntityTypeConfiguration<CustomRoleClaim>
    {
        public void Configure(EntityTypeBuilder<CustomRoleClaim> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClaimType)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.ClaimValue)
                .HasMaxLength(1024);

            builder.HasOne(x => x.Role)
                .WithMany(y => y.RoleClaims)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            builder.ToTable("RoleClaims");
        }
    }
}
