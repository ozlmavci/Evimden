using Evimden.CoreLayer.Concrete.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evimden.DataAccessLayer.Configurations.IdentityConfigs
{
    public class CustomUserRoleConfig : IEntityTypeConfiguration<CustomUserRole>
    {
        public void Configure(EntityTypeBuilder<CustomUserRole> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            builder.ToTable("UserRoles");
        }
    }
}
