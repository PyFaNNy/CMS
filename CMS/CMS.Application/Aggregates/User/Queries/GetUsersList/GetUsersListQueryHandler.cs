using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.User.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : AbstractRequestHandler, IRequestHandler<GetUsersListQuery, List<User>>
    {
        public GetUsersListQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<List<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users
                .ProjectTo<User>(this.Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return user;
        }
    }
}
