using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using CMS.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.User.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : AbstractRequestHandler, IRequestHandler<ChangePasswordCommand, Unit>
    {
        public ChangePasswordCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User.User), request.UserId);
            }

            user.Password = CryptoHelper.HashPassword(request.Password);

            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
