using MediatR;

namespace CMS.Application.Aggregates.Trainer.Queries.GetTrainer
{
    public class GetTrainerQuery : IRequest<Trainer>
    {
        public Guid TrainerId { get; set; }
    }
}
