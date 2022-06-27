using CMS.Application.Abstractions;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.Course.Queries.GetCourses
{
    public class GetCoursesQuery : GetPaginatedListBaseQuery<PaginatedList<Course>>
    {
        public GetCoursesQuery(int? pageIndex, int? pageSize) : base(pageIndex, pageSize)
        {
                
        }
    }
}
