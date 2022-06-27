using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroup
{
    public class GetTrainerGroupQueryHandler : AbstractRequestHandler, IRequestHandler<GetTrainerGroupQuery, TrainerGroup>
    {
        public GetTrainerGroupQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<TrainerGroup> Handle(GetTrainerGroupQuery request, CancellationToken cancellationToken)
        {
            var trainerGroup = await DbContext.TrainerGroups
                .Where(x => x.Id == request.TrainerGroupId)
                .ProjectTo<TrainerGroup>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return trainerGroup;
        }
    }
}
