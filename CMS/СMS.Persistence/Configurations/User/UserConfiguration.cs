using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СMS.Persistence.Extensions;

namespace СMS.Persistence.Configurations.User
{
    public class UserConfiguration : IEntityTypeConfiguration<CMS.Domain.Entities.User.User>
    {
        public void Configure(EntityTypeBuilder<CMS.Domain.Entities.User.User> builder)
        {
            builder.ToTable("User", "user");

            builder.Property(x => x.Email)
                .HasMediumMaxLength()
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMediumMaxLength()
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .HasMediumMaxLength()
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMediumMaxLength()
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMediumMaxLength()
                .IsRequired();

            builder.Property(x => x.Department)
                .HasMediumMaxLength()
                .IsRequired();

            builder.Property(x => x.Position)
                .HasMediumMaxLength()
                .IsRequired();

            builder.Property(x => x.Location)
                .HasMediumMaxLength()
                .IsRequired();

            builder.HasMany(c => c.Roles)
                .WithMany(s => s.Users)
                .UsingEntity(j => j.ToTable("UserRole"));
        }
    }
}
