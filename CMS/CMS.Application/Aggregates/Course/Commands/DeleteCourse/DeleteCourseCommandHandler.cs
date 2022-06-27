using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Course.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : AbstractRequestHandler, IRequestHandler<DeleteCourseCommand, Unit>
    {
        public DeleteCourseCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await this.DbContext.Courses
                .Where(x => x.Id == request.CourseId)
                .FirstOrDefaultAsync(cancellationToken);

            if (course == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Course.Course), request.CourseId);
            }

            this.DbContext.Courses.Remove(course);

            return Unit.Value;
        }
    }
}
