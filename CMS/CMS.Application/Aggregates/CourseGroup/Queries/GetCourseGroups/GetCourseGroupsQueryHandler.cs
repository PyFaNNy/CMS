using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroups
{
    public class GetCourseGroupsQueryHandler : AbstractRequestHandler, IRequestHandler<GetCourseGroupsQuery, PaginatedList<CourseGroup>>
    {
        public GetCourseGroupsQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<PaginatedList<CourseGroup>> Handle(GetCourseGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = DbContext.CourseGroups
                .ProjectTo<CourseGroup>(this.Mapper.ConfigurationProvider);

            var paginatedList = await PaginatedList<CourseGroup>.CreateAsync(groups, request.PageIndex, request.PageSize);

            return paginatedList;
        }
    }
}
