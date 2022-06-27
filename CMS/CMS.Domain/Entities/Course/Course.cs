using CMS.Domain.Entities.Abstract;
using CMS.Domain.Entities.User;
using CMS.Domain.Interfaces;

namespace CMS.Domain.Entities.Course
{
    public class Course : VisibleEntity, IBaseEntity
    {
        public Guid Id { get; set; }
        public bool IsNew { get; set; }
        public Guid CourseTypeId { get; set; }
        public Guid CourseGroupId { get; set; }
        public CourseType CourseType { get; set; }
        public CourseGroup CourseGroup { get; set; }
        public List<Trainer> Trainers { get; set; }

        public Course(string name, int visualOrder, string description, bool isNew, Guid courseTypeId, Guid courseGroupId) :
            base(name, visualOrder, description)
        {
            IsNew = isNew;
            CourseTypeId = courseTypeId;
            CourseGroupId = courseGroupId;
        }


    }
}
