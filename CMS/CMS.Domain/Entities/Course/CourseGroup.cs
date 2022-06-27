using CMS.Domain.Entities.Abstract;
using CMS.Domain.Interfaces;

namespace CMS.Domain.Entities.Course
{
    public class CourseGroup : VisibleEntity, IBaseEntity
    {
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; }
        public CourseGroup(string name, int visualOrder, string description) : base(name, visualOrder, description)
        {
        }
    }
}
