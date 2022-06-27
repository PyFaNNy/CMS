using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.Application.Abstractions;
using CMS.Application.Interfaces;
using CMS.Application.Models;
using MediatR;

namespace CMS.Application.Aggregates.Trainer.Queries.GetTrainers
{
    public class GetTrainersQueryHandler : AbstractRequestHandler, IRequestHandler<GetTrainersQuery, PaginatedList<Trainer>>
    {
        public GetTrainersQueryHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<PaginatedList<Trainer>> Handle(GetTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = DbContext.Trainers
                .ProjectTo<Trainer>(this.Mapper.ConfigurationProvider);

            var paginatedList = await PaginatedList<Trainer>.CreateAsync(trainers, request.PageIndex, request.PageSize);

            return paginatedList;
        }
    }
}
