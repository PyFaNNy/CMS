using MediatR;

namespace CMS.Application.Aggregates.Trainer.Commands.DeleteTrainer
{
    public class DeleteTrainerCommand : IRequest<Unit>
    {
        public Guid TrainerId { get; set; }
    }
}
