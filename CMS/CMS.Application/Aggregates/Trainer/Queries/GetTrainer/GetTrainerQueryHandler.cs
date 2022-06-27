using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Trainer.Queries.GetTrainer
{
    public class GetTrainerQueryHandler : AbstractRequestHandler, IRequestHandler<GetTrainerQuery, Trainer>
    {
        public GetTrainerQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Trainer> Handle(GetTrainerQuery request, CancellationToken cancellationToken)
        {
            var trainer =await DbContext.Trainers
                .Where(x => x.Id == request.TrainerId)
                .ProjectTo<Trainer>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return trainer;
        }
    }
}
