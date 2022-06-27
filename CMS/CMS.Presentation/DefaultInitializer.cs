using CMS.Application.Interfaces;
using CMS.Common;
using CMS.Domain.Entities.Course;
using CMS.Domain.Entities.Role;
using CMS.Domain.Entities.User;

namespace СMS
{
    public class DefaultInitializer
    {
        public static async Task InitializeAsync(ICMSDbContext dbContext)
        {
            if (!dbContext.CourseTypes.Any())
            {
                dbContext.CourseTypes.AddRange(new List<CourseType>
                {
                    new CourseType("Online", 1, "Online course")
                    {
                        Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda4")
                    },
                    new CourseType("Offline", 1, "Offline course")
                    {
                        Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda3")
                    }
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.CourseGroups.Any())
            {
                dbContext.CourseGroups.AddRange(new List<CourseGroup>
                {
                    new CourseGroup(".Net", 1, "The best for .Net developer")
                    {
                        Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda1")
                    },
                    new CourseGroup("Java", 1, "The best Java developer")
                    {
                        Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda2")
                    },
                    new CourseGroup("JavaScript", 1, "The JavaScript Course")
                    {
                        Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda5")
                    },
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.Courses.Any())
            {
                dbContext.Courses.AddRange(new List<Course>
                {
                    new Course(
                        "Junior .Net Developer",
                        1, 
                        "The best Course",
                        true,
                        Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda4"),
                        Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda1"))
                    {
                    Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda6")
                    },
                    new Course(
                        "Middle .Net Developer",
                        1,
                        "The best Course",
                        true,
                        Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda4"),
                        Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda1"))
                    {
                        Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda7")
                    },
                    new Course(
                        "Senior .Net Developer",
                        1,
                        "The best Course",
                        true,
                        Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda4"),
                        Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda1"))
                    {
                        Id = Guid.Parse("19f7d733-8826-4726-a669-0d29a882eda8")
                    }
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.TrainerGroups.Any())
            {
                dbContext.TrainerGroups.AddRange(new List<TrainerGroup>
                {
                    new TrainerGroup(".Net", 1, "The best trainers for .Net developer")
                    {
                        Id = Guid.Parse("11f7d733-8826-4726-a669-0d29a882eda1")
                    },
                    new TrainerGroup("Java", 1, "The best trainers for Java developer")
                    {
                        Id = Guid.Parse("12f7d733-8826-4726-a669-0d29a882eda2")
                    },
                    new TrainerGroup("JavaScript", 1, "The best trainers for JavaScript developer")
                    {
                        Id = Guid.Parse("13f7d733-8826-4726-a669-0d29a882eda5")
                    },
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.Roles.Any())
            {
                dbContext.Roles.AddRange(new List<Role>
                {
                    new Role()
                    {
                        Id = Guid.Parse("11f7d731-8826-4726-a669-0d29a882eda1"),
                        Name = "Admin"
                    },
                    new Role()
                    {
                        Id = Guid.Parse("12f7d732-8826-4726-a669-0d29a882eda2"),
                        Name = "User"
                    },
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.Users.Any())
            {
                var Admin = dbContext.Roles.FirstOrDefault(x =>
                    x.Id == Guid.Parse("11f7d731-8826-4726-a669-0d29a882eda1"));
                var User = dbContext.Roles.FirstOrDefault(x =>
                    x.Id == Guid.Parse("12f7d732-8826-4726-a669-0d29a882eda2"));
                dbContext.Users.AddRange(new List<User>
                {
                    new User()
                    {
                        Id = Guid.Parse("11f7d721-8826-4726-a669-0d29a882eda1"),
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@gmail.com",
                        Password = CryptoHelper.HashPassword("admin"),
                        PasswordSalt = CryptoHelper.HashPassword("admin"),
                        Department = "All",
                        Position = "Admin",
                        Location = "Minsk World",
                        Roles = new List<Role>()
                        {
                            Admin
                        }
                    },
                    new User()
                    {
                        Id = Guid.Parse("11f7d221-8826-4726-a669-0d29a882eda1"),
                        FirstName = "User",
                        LastName = "User",
                        Email = "user@gmail.com",
                        Password = CryptoHelper.HashPassword("user"),
                        PasswordSalt = CryptoHelper.HashPassword("user"),
                        Department = "All",
                        Position = "User",
                        Location = "Minsk World",
                        Roles = new List<Role>()
                        {
                            User
                        }
                    },
                });
                dbContext.SaveChanges();
            }
        }
    }
}
