using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Trainer.Queries.GetTrainersList
{
    public class GetTrainersListQueryHandler : AbstractRequestHandler, IRequestHandler<GetTrainersListQuery, List<Trainer>>
    {
        public GetTrainersListQueryHandler(IMediator mediator, ICMSDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<List<Trainer>> Handle(GetTrainersListQuery request, CancellationToken cancellationToken)
        {
            var trainers = await DbContext.Trainers
                .ProjectTo<Trainer>(this.Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return trainers;
        }
    }
}
