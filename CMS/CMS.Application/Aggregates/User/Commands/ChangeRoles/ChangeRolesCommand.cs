using MediatR;

namespace CMS.Application.Aggregates.User.Commands.ChangeRoles
{
    public class ChangeRolesCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid RoleIds { get; set; }
    }
}
