using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.CourseGroup.Commands.DeleteCourseGroup
{
    public class DeleteCourseGroupCommandHandler : AbstractRequestHandler, IRequestHandler<DeleteCourseGroupCommand, Unit>
    {
        public DeleteCourseGroupCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteCourseGroupCommand request, CancellationToken cancellationToken)
        {
            var courseGroup = await this.DbContext.CourseGroups
                .Where(x => x.Id == request.CourseGroupId)
                .Include(x => x.Courses)
                .FirstOrDefaultAsync(cancellationToken);

            if (courseGroup == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Course.Course), request.CourseGroupId);
            }

            if (courseGroup.Courses.Count == 0)
            {
                this.DbContext.CourseGroups.Remove(courseGroup);
                await this.DbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
