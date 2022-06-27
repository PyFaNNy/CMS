using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;

namespace CMS.Application.Aggregates.Trainer.Commands.CreateTrainer
{
    public class CreateTrainerCommandHandler : AbstractRequestHandler, IRequestHandler<CreateTrainerCommand, Unit>
    {
        public CreateTrainerCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = this.Mapper.Map<Domain.Entities.User.Trainer>(request);

            await this.DbContext.Trainers.AddAsync(trainer, cancellationToken);
            await this.DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
