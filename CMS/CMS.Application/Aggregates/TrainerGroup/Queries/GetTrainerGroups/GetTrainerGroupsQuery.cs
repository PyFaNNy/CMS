using CMS.Application.Abstractions;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroups
{
    public class GetTrainerGroupsQuery : GetPaginatedListBaseQuery<PaginatedList<TrainerGroup>>
    {
        public GetTrainerGroupsQuery(int? pageIndex, int? pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
