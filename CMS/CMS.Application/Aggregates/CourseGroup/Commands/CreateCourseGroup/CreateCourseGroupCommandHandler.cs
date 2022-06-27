using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Commands.CreateCourseGroup
{
    public class CreateCourseGroupCommandHandler : AbstractRequestHandler, IRequestHandler<CreateCourseGroupCommand, Unit>
    {
        public CreateCourseGroupCommandHandler(IMediator mediator, ICMSDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateCourseGroupCommand request, CancellationToken cancellationToken)
        {
            var courseGroup = this.Mapper.Map<Domain.Entities.Course.CourseGroup>(request);

            await this.DbContext.CourseGroups.AddAsync(courseGroup, cancellationToken);
            await this.DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
