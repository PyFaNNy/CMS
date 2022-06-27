using AutoMapper;
using CMS.Application.Mappings;
using MediatR;

namespace CMS.Application.Aggregates.Trainer.Commands.EditTrainer
{
    public class EditTrainerCommand : IRequest<Unit>, IMapTo<Domain.Entities.User.Trainer>
    {
        public Guid TrainerId { get; set; }
        public int VisualOrder { get; set; }
        public Guid TrainerGroupId { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditTrainerCommand, Domain.Entities.User.Trainer>()
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.TrainerGroupId, opt => opt.MapFrom(s => s.TrainerGroupId));
        }
    }
}
