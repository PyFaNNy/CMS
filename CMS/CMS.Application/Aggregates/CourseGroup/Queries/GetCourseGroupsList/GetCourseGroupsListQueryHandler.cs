using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroupsList
{
    internal class GetCourseGroupsListQueryHandler : AbstractRequestHandler, IRequestHandler<GetCourseGroupsListQuery, List<CourseGroup>>
    {
        public GetCourseGroupsListQueryHandler(IMediator mediator, ICMSDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<List<CourseGroup>> Handle(GetCourseGroupsListQuery request, CancellationToken cancellationToken)
        {
            var groups = await DbContext.CourseGroups
                .ProjectTo<CourseGroup>(this.Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return groups;
        }
    }
}
