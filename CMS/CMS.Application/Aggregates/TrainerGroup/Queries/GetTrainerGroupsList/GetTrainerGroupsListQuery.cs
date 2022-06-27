using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroupsList
{
    public class GetTrainerGroupsListQuery : IRequest<List<TrainerGroup>>
    {
    }
}
