using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroups
{
    public class GetTrainerGroupsQueryHandler : AbstractRequestHandler, IRequestHandler<GetTrainerGroupsQuery, PaginatedList<TrainerGroup>>
    {
        public GetTrainerGroupsQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<PaginatedList<TrainerGroup>> Handle(GetTrainerGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = DbContext.TrainerGroups
                .ProjectTo<TrainerGroup>(this.Mapper.ConfigurationProvider);

            var paginatedList = await PaginatedList<TrainerGroup>.CreateAsync(groups, request.PageIndex, request.PageSize);

            return paginatedList;
        }
    }
}
