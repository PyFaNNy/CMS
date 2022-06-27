using CMS.Domain.Entities.Abstract;
using CMS.Domain.Interfaces;

namespace CMS.Domain.Entities.Course
{
    public class CourseType : VisibleEntity, IBaseEntity
    {
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; }
        public CourseType(string name, int visualOrder, string description) : base(name, visualOrder, description)
        {
        }
    }
}
