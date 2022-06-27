using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroupsList
{
    public class GetCourseGroupsListQuery : IRequest<List<CourseGroup>>
    {
    }
}
