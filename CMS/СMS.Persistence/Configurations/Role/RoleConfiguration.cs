using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СMS.Persistence.Extensions;

namespace СMS.Persistence.Configurations.Role
{

    public class RoleConfiguration : IEntityTypeConfiguration<CMS.Domain.Entities.Role.Role>
    {
        public void Configure(EntityTypeBuilder<CMS.Domain.Entities.Role.Role> builder)
        {
            builder.ToTable("Role", "role");

            builder.Property(x => x.Name)
                .HasLowMaxLength()
                .IsRequired();


            builder.HasMany(c => c.Users)
                .WithMany(s => s.Roles)
                .UsingEntity(j => j.ToTable("UserRole"));
        }
    }
}
