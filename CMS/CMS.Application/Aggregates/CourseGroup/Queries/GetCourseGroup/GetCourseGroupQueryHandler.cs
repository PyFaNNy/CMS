using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroup
{
    public class GetCourseGroupQueryHandler : AbstractRequestHandler, IRequestHandler<GetCourseGroupQuery, CourseGroup>
    {
        public GetCourseGroupQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<CourseGroup> Handle(GetCourseGroupQuery request, CancellationToken cancellationToken)
        {
            var courseGroup = await DbContext.CourseGroups
                .Where(x => x.Id == request.CourseId)
                .ProjectTo<CourseGroup>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return courseGroup;
        }
    }
}
