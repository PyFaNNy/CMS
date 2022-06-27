using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.Aggregates.Roles.Queries.GetRoles
{
    public class GetRolesQueryHandler : AbstractRequestHandler, IRequestHandler<GetRolesQuery, List<Role>>
    {
        public GetRolesQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<List<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await DbContext.Roles
                .ProjectTo<Role>(this.Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return roles;
        }
    }
}
