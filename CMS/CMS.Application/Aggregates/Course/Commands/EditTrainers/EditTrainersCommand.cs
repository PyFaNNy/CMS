using MediatR;

namespace CMS.Application.Aggregates.Course.Commands.EditTrainers
{
    public class EditTrainersCommand : IRequest<Unit>
    {
        public Guid CourseId { get; set; }
        public Guid TrainerId { get; set; }
    }
}
