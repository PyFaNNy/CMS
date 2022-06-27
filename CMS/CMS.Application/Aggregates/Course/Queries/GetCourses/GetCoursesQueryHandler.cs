using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.Course.Queries.GetCourses
{
    public class GetCoursesQueryHandler : AbstractRequestHandler, IRequestHandler<GetCoursesQuery, PaginatedList<Course>>
    {
        public GetCoursesQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<PaginatedList<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = DbContext.Courses
                .ProjectTo<Course>(this.Mapper.ConfigurationProvider);

            var paginatedList = await PaginatedList<Course>.CreateAsync(courses, request.PageIndex, request.PageSize);

            return paginatedList;
        }
    }
}
