using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using CMS.Common;
using MediatR;

namespace CMS.Application.Aggregates.User.Commands.SignIn
{
    public class SignInCommandHandler : AbstractRequestHandler, IRequestHandler<SignInCommand, Unit>
    {
        public SignInCommandHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User.User()
            {
                FirstName = request.FirstName,
                Location = request.Location,
                LastName = request.LastName,
                Email = request.Email,
                Password = CryptoHelper.HashPassword(request.Password),
                PasswordSalt = CryptoHelper.HashPassword(request.Password),
                Department = request.Department,
                Position = request.Position,
                StartDate = DateTime.UtcNow
            };
            //var user = this.Mapper.Map<Domain.Entities.User.User>(request);

            if (request.Photo?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    request.Photo.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    user.Photo = fileBytes;
                }
            }

            await this.DbContext.Users.AddAsync(user, cancellationToken);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
