using System.Reflection;
using CMS.Application.Interfaces;
using CMS.Domain.Entities.Course;
using CMS.Domain.Entities.Role;
using CMS.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace СMS.Persistence
{
    public class CMSDbContext : DbContext, ICMSDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerGroup> TrainerGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }

        public CMSDbContext(DbContextOptions<CMSDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();

            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
