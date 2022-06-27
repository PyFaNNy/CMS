using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.CourseType.Queries.GetCourseTypes
{
    public class GetCourseTypesQueryHandler : AbstractRequestHandler, IRequestHandler<GetCourseTypesQuery, List<CourseType>>
    {
        public GetCourseTypesQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<List<CourseType>> Handle(GetCourseTypesQuery request, CancellationToken cancellationToken)
        {
            var groups =await DbContext.CourseTypes
                .ProjectTo<CourseType>(this.Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return groups;
        }
    }
}
