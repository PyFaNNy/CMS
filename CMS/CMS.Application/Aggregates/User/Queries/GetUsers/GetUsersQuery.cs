using CMS.Application.Abstractions;
using CMS.Application.Models;

namespace CMS.Application.Aggregates.User.Queries.GetUsers
{
    public class GetUsersQuery : GetPaginatedListBaseQuery<PaginatedList<User>>
    {
        public GetUsersQuery(int? pageIndex, int? pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
