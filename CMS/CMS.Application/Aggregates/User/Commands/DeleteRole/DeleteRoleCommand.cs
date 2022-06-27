using MediatR;

namespace CMS.Application.Aggregates.User.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
