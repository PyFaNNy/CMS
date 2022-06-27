using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Course.Commands.EditTrainers
{
    public class EditTrainersCommandHandler : AbstractRequestHandler, IRequestHandler<EditTrainersCommand, Unit>
    {
        public EditTrainersCommandHandler(IMediator mediator, ICMSDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(EditTrainersCommand request, CancellationToken cancellationToken)
        {
            var course = await DbContext.Courses
                .Include(u => u.Trainers)
                .Where(x => x.Id == request.CourseId)
                .FirstOrDefaultAsync(cancellationToken);

            if (course == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Course.Course), request.CourseId);
            }

            var trainer = await DbContext.Trainers
                .Where(X => X.Id == request.TrainerId)
                .FirstOrDefaultAsync(cancellationToken);

            course.Trainers.Add(trainer);
            DbContext.Courses.Update(course);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
