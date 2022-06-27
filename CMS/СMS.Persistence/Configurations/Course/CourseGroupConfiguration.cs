using CMS.Domain.Entities.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СMS.Persistence.Extensions;

namespace СMS.Persistence.Configurations.Course
{
    public class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
    {
        public void Configure(EntityTypeBuilder<CourseGroup> builder)
        {
            builder.ToTable("CourseGroup", "course");

            builder.Property(x => x.Name)
                .HasLowMaxLength()
                .IsRequired();

            builder.Property(x => x.VisualOrder)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasHighMaxLength()
                .IsRequired(false);

            builder.HasMany(t => t.Courses)
                .WithOne(x => x.CourseGroup)
                .HasForeignKey(o => o.CourseGroupId);
        }
    }
}
