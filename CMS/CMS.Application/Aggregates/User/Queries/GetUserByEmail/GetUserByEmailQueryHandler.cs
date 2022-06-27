using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Exceptions;
using CMS.Application.Extensions.IQueryableExtensions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.User.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : AbstractRequestHandler, IRequestHandler<GetUserByEmailQuery, User>
    {
        public GetUserByEmailQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users
                .Where(x => x.Email == request.Email)
                .NotRemoved()
                .ProjectTo<User>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new NotFoundException("User", request.Email);
            }

            return user;
        }
    }
}
