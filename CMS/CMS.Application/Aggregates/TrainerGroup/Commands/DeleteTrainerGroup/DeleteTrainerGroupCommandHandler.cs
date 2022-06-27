using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.TrainerGroup.Commands.DeleteTrainerGroup
{
    public class DeleteTrainerGroupCommandHandler : AbstractRequestHandler, IRequestHandler<DeleteTrainerGroupCommand, Unit>
    {
        public DeleteTrainerGroupCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteTrainerGroupCommand request, CancellationToken cancellationToken)
        {
            var trainerGroup = await this.DbContext.TrainerGroups
                .Where(x => x.Id == request.TrainerGroupId)
                .FirstOrDefaultAsync(cancellationToken);

            if (trainerGroup == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User.TrainerGroup), request.TrainerGroupId);
            }

            if (trainerGroup.Trainers.Count == 0)
            {
                this.DbContext.TrainerGroups.Remove(trainerGroup);
                await this.DbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
