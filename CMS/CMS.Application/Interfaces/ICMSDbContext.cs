using CMS.Domain.Entities.Course;
using CMS.Domain.Entities.Role;
using CMS.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Interfaces
{
    public interface ICMSDbContext
    {
        DbSet<User> Users
        {
            get;
            set;
        }

        DbSet<Trainer> Trainers
        {
            get;
            set;
        }

        DbSet<TrainerGroup> TrainerGroups
        {
            get;
            set;
        }

        DbSet<Role> Roles
        {
            get;
            set;
        }

        DbSet<Course> Courses
        {
            get;
            set;
        }

        DbSet<CourseType> CourseTypes
        {
            get;
            set;
        }

        DbSet<CourseGroup> CourseGroups
        {
            get;
            set;
        }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
