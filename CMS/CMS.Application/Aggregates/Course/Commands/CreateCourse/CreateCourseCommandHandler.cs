using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;

namespace CMS.Application.Aggregates.Course.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : AbstractRequestHandler, IRequestHandler<CreateCourseCommand, Unit>
    {
        public CreateCourseCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = this.Mapper.Map<Domain.Entities.Course.Course>(request);
            
            await this.DbContext.Courses.AddAsync(course, cancellationToken);
            await this.DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
