using System.Linq;
using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Trainer.Commands.DeleteTrainer
{
    public class DeleteTrainerCommandHandler : AbstractRequestHandler, IRequestHandler<DeleteTrainerCommand, Unit>
    {
        public DeleteTrainerCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = await this.DbContext.Trainers
                .Where(x => x.Id == request.TrainerId)
                .FirstOrDefaultAsync(cancellationToken);

            if (trainer == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User.Trainer), request.TrainerId);
            }

            this.DbContext.Trainers.Remove(trainer);

            return Unit.Value;
        }
    }
}
