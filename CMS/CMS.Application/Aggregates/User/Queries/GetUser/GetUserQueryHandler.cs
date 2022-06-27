using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.User.Queries.GetUser
{
    public class GetUserQueryHandler : AbstractRequestHandler, IRequestHandler<GetUserQuery, User>
    {
        public GetUserQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users
                .Where(x => x.Id == request.UserId)
                .ProjectTo<User>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return user;
        }
    }
}
