using MediatR;

namespace CMS.Application.Aggregates.Roles.Queries.GetRoles
{
    public class GetRolesQuery : IRequest<List<Role>>
    {
    }
}
