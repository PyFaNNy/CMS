using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СMS.Persistence.Extensions;

namespace СMS.Persistence.Configurations.Course
{
    public class CourseConfiguration : IEntityTypeConfiguration<CMS.Domain.Entities.Course.Course>
    {
        public void Configure(EntityTypeBuilder<CMS.Domain.Entities.Course.Course> builder)
        {
            builder.ToTable("Course", "course");

            builder.Property(x => x.Name)
                .HasLowMaxLength()
                .IsRequired();

            builder.Property(x => x.VisualOrder)
                .IsRequired();

            builder.Property(x => x.IsNew)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasLongMaxLength()
                .IsRequired(false);


            builder.HasMany(c => c.Trainers)
                .WithMany(s => s.Courses)
                .UsingEntity(j => j.ToTable("CourseTrainer"));
        }
    }
}
