using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.User.Queries.GetUsers
{
    public class GetUsersQueryHandler : AbstractRequestHandler, IRequestHandler<GetUsersQuery, PaginatedList<User>>
    {
        public GetUsersQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<PaginatedList<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = DbContext.Users
                .ProjectTo<User>(this.Mapper.ConfigurationProvider);

            var paginatedList = await PaginatedList<User>.CreateAsync(users, request.PageIndex, request.PageSize);

            return paginatedList;
        }
    }
}
