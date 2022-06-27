using MediatR;

namespace CMS.Application.Aggregates.Trainer.Queries.GetTrainersList
{
    public class GetTrainersListQuery : IRequest<List<Trainer>>
    {
    }
}
