using System.Linq;
using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Course.Commands.EditCourse
{
    public class EditCourseCommandHandler : AbstractRequestHandler, IRequestHandler<EditCourseCommand, Unit>
    {
        public EditCourseCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await this.DbContext.Courses
                .Where(x => x.Id == request.CourseId)
                .FirstOrDefaultAsync(cancellationToken);

            if (course == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Course.Course), request.CourseId);
            }

            this.Mapper.Map(request, course);
            
            await this.DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
