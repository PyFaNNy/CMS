using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.User.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : AbstractRequestHandler, IRequestHandler<DeleteRoleCommand, Unit>
    {
        public DeleteRoleCommandHandler(IMediator mediator, ICMSDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users
                .Include(u => u.Roles)
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            var role = user.Roles.FirstOrDefault(x => x.Id == request.RoleId);
            user.Roles.Remove(role);
            DbContext.Users.Update(user);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
