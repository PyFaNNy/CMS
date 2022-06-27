using AutoMapper;
using CMS.Application.Mappings;
using MediatR;

namespace CMS.Application.Aggregates.TrainerGroup.Commands.EditTrainerGroup
{
    public class EditTrainerGroupCommand : IRequest<Unit>, IMapTo<Domain.Entities.User.TrainerGroup>
    {
        public Guid TrainerGroupId { get; set; }
        public string Name { get; set; }
        public int VisualOrder { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditTrainerGroupCommand, Domain.Entities.User.TrainerGroup>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}
