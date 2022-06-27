using MediatR;

namespace CMS.Application.Aggregates.Course.Queries.GetCourse
{
    public class GetCourseQuery : IRequest<Course>
    {
        public Guid CourseId { get; set; }
    }
}
