using CMS.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СMS.Persistence.Extensions;

namespace СMS.Persistence.Configurations.User
{
    public class TrainerGroupConfiguration : IEntityTypeConfiguration<TrainerGroup>
    {
        public void Configure(EntityTypeBuilder<TrainerGroup> builder)
        {
            builder.ToTable("TrainerGroup", "user");

            builder.Property(x => x.Name)
                .HasLongMaxLength()
                .IsRequired();

            builder.Property(x => x.Description)
                .HasHighMaxLength()
                .IsRequired(false);

            builder.Property(x => x.VisualOrder)
                .IsRequired();

            builder.HasMany(t => t.Trainers)
                .WithOne(x => x.TrainerGroup)
                .HasForeignKey(o => o.TrainerGroupId);
        }
    }
}
