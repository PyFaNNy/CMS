using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Commands.CreateTrainerGroup
{
    public class CreateTrainerGroupCommandHandler : AbstractRequestHandler, IRequestHandler<CreateTrainerGroupCommand, Unit>
    {
        public CreateTrainerGroupCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateTrainerGroupCommand request, CancellationToken cancellationToken)
        {
            var trainerGroup = this.Mapper.Map<Domain.Entities.User.TrainerGroup>(request);

            await this.DbContext.TrainerGroups.AddAsync(trainerGroup, cancellationToken);
            await this.DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
