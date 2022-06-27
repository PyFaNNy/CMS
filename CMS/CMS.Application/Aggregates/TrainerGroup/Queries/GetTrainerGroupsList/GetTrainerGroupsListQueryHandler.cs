using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroupsList
{
    public class GetTrainerGroupsListQueryHandler : AbstractRequestHandler, IRequestHandler<GetTrainerGroupsListQuery, List<TrainerGroup>>
    {
        public GetTrainerGroupsListQueryHandler(IMediator mediator, ICMSDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<List<TrainerGroup>> Handle(GetTrainerGroupsListQuery request, CancellationToken cancellationToken)
        {
            var groups = await DbContext.TrainerGroups
                .ProjectTo<TrainerGroup>(this.Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return groups;
        }
    }
}
