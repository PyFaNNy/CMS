using CMS.Application.Abstractions;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroups
{
    public class GetCourseGroupsQuery : GetPaginatedListBaseQuery<PaginatedList<CourseGroup>>
    {
        public GetCourseGroupsQuery(int? pageIndex, int? pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
