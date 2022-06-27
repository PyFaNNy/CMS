using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroup
{
    public class GetCourseGroupQuery : IRequest<CourseGroup>
    {
        public Guid CourseId { get; set; }
    }
}
