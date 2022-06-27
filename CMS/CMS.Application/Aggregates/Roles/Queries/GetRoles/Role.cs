using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.Roles.Queries.GetRoles
{
    public class Role : IMapFrom<Domain.Entities.Role.Role>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Role.Role, Role>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
