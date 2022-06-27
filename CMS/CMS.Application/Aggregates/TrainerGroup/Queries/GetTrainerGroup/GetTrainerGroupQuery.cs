using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroup
{
    public class GetTrainerGroupQuery : IRequest<TrainerGroup>
    {
        public Guid TrainerGroupId { get; set; }
    }
}
