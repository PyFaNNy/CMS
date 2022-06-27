using CMS.Application.Abstractions;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.Trainer.Queries.GetTrainers
{
    public class GetTrainersQuery : GetPaginatedListBaseQuery<PaginatedList<Trainer>>
    {
        public GetTrainersQuery(int? pageIndex, int? pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
