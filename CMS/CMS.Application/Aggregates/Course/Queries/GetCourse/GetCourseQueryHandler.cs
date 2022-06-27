using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Course.Queries.GetCourse
{
    public class GetCourseQueryHandler : AbstractRequestHandler, IRequestHandler<GetCourseQuery, Course>
    {
        public GetCourseQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Course> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course =await DbContext.Courses
                .Where(x => x.Id == request.CourseId)
                .ProjectTo<Course>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return course;
        }
    }   
}
