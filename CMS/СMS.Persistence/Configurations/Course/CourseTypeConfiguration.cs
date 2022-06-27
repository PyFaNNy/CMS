using CMS.Domain.Entities.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СMS.Persistence.Extensions;

namespace СMS.Persistence.Configurations.Course
{

    public class CourseTypeConfiguration : IEntityTypeConfiguration<CourseType>
    {
        public void Configure(EntityTypeBuilder<CourseType> builder)
        {
            builder.ToTable("CourseType", "course");

            builder.Property(x => x.Name)
                .HasLowMaxLength()
                .IsRequired();

            builder.Property(x => x.VisualOrder)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasHighMaxLength()
                .IsRequired(false);

            builder.HasMany(t => t.Courses)
                .WithOne(x => x.CourseType)
                .HasForeignKey(o => o.CourseTypeId);
        }
    }
}
