using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Commands.DeleteCourseGroup
{
    public class DeleteCourseGroupCommand : IRequest<Unit>
    {
        public Guid CourseGroupId { get; set; }
    }
}
