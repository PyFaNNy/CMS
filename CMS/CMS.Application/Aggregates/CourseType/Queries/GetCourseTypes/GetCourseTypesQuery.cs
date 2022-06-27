using MediatR;

namespace CMS.Application.Aggregates.CourseType.Queries.GetCourseTypes
{
    public class GetCourseTypesQuery : IRequest<List<CourseType>>
    {
    }
}
