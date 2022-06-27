using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Commands.DeleteTrainerGroup
{
    public class DeleteTrainerGroupCommand : IRequest<Unit>
    {
        public Guid TrainerGroupId { get; set; }
    }
}
