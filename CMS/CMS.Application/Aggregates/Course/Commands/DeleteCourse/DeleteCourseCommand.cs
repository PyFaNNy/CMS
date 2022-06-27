using MediatR;

namespace CMS.Application.Aggregates.Course.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest<Unit>
    {
        public Guid CourseId { get; set; }
    }
}
