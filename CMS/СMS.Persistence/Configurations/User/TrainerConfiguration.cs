using CMS.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СMS.Persistence.Extensions;

namespace СMS.Persistence.Configurations.User
{

    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable("Trainer", "user");

            builder.Property(x => x.VisualOrder)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasLongMaxLength()
                .IsRequired(false);

            builder.HasOne(u => u.User)
                .WithOne(p => p.Trainer)
                .HasForeignKey<Trainer>(p => p.Id);
        }
    }
}
