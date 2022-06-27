using AutoMapper;
using CMS.Application.Mappings;
using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Commands.CreateTrainerGroup
{
    public class CreateTrainerGroupCommand : IRequest<Unit>, IMapTo<Domain.Entities.User.TrainerGroup>
    {
        public string Name { get; set; }
        public int VisualOrder { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTrainerGroupCommand, Domain.Entities.User.TrainerGroup>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}
