using AutoMapper;
using CMS.Application.Aggregates.Course.Commands.CreateCourse;
using CMS.Application.Mappings;
using MediatR;

namespace CMS.Application.Aggregates.Trainer.Commands.CreateTrainer
{
    public class CreateTrainerCommand : IRequest<Unit>, IMapTo<Domain.Entities.User.Trainer>
    {
        public Guid Id { get; set; }
        public int VisualOrder { get; set; }
        public Guid TrainerGroupId { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTrainerCommand, Domain.Entities.User.Trainer>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.TrainerGroupId, opt => opt.MapFrom(s => s.TrainerGroupId));
        }
    }
}
