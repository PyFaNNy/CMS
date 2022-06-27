using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Trainer.Commands.EditTrainer
{
    public class EditTrainerCommandHandler : AbstractRequestHandler, IRequestHandler<EditTrainerCommand, Unit>
    {
        public EditTrainerCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(EditTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = await this.DbContext.Trainers
                .Where(x => x.Id == request.TrainerId)
                .FirstOrDefaultAsync(cancellationToken);

            if (trainer == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Course.Course), request.TrainerId);
            }

            this.Mapper.Map(request, trainer);

            await this.DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
