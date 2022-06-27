using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Course.Commands.DeleteTrainer
{
    public class DeleteTrainerCommandHandler : AbstractRequestHandler, IRequestHandler<DeleteTrainerCommand, Unit>
    {
        public DeleteTrainerCommandHandler(IMediator mediator, ICMSDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
        {
            var course = await DbContext.Courses
                .Include(u => u.Trainers)
                .Where(x => x.Id == request.CourseId)
                .FirstOrDefaultAsync(cancellationToken);

            var trainer = course.Trainers.FirstOrDefault(x => x.Id == request.TrainerId);
            course.Trainers.Remove(trainer);
            DbContext.Courses.Update(course);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
