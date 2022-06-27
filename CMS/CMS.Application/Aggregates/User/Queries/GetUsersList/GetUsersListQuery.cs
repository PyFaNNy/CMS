using MediatR;

namespace CMS.Application.Aggregates.User.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<List<User>>
    {
    }
}
