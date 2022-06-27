using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.CourseGroup.Commands.EditCourseGroup
{
    public class EditCourseGroupCommandHandler : AbstractRequestHandler, IRequestHandler<EditCourseGroupCommand, Unit>
    {
        public EditCourseGroupCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(EditCourseGroupCommand request, CancellationToken cancellationToken)
        {
            var courseGroup = await this.DbContext.CourseGroups
                .Where(x => x.Id == request.CourseGroupid)
                .FirstOrDefaultAsync(cancellationToken);

            if (courseGroup == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Course.Course), request.CourseGroupid);
            }

            this.Mapper.Map(request, courseGroup);

            await this.DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
