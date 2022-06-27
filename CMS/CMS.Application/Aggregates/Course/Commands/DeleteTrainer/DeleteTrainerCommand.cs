using MediatR;

namespace CMS.Application.Aggregates.Course.Commands.DeleteTrainer
{
    public class DeleteTrainerCommand : IRequest<Unit>
    {
        public Guid CourseId { get; set; }
        public Guid TrainerId { get; set; }
    }
}
