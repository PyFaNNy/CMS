using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using CMS.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.User.Commands.ChangeRoles
{
    public class ChangeRolesCommandHandler : AbstractRequestHandler, IRequestHandler<ChangeRolesCommand, Unit>
    {
        public ChangeRolesCommandHandler(IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(ChangeRolesCommand request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users
                .Include(u => u.Roles)
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User.User), request.UserId);
            }

            var roles = await DbContext.Roles
                .Where(X => X.Id == request.RoleIds)
                .FirstOrDefaultAsync(cancellationToken);

            user.Roles.Add(roles);
            DbContext.Users.Update(user);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
