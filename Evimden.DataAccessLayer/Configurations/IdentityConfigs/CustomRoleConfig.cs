using Evimden.CoreLayer.Concrete.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.IdentityConfigs
{
    public class CustomRoleConfig : IEntityTypeConfiguration<CustomRole>
    {
        public void Configure(EntityTypeBuilder<CustomRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.NormalizedName)
                .HasMaxLength(256);

            builder.HasMany(x => x.RoleClaims)
                .WithOne(y => y.Role)
                .HasForeignKey(y => y.RoleId)
                .IsRequired();

            builder.ToTable("Roles");
        }
    }
}
