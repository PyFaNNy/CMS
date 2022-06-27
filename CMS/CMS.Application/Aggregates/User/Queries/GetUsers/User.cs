using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.User.Queries.GetUsers
{
    public class User : IMapFrom<Domain.Entities.User.User>
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string IsActive { get; set; }
        public byte[] Photo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User.User, User>()
                .ForMember(d => d.Photo, opt => opt.MapFrom(s => s.Photo))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.Position, opt => opt.MapFrom(s => s.Position))
                .ForMember(d => d.Location, opt => opt.MapFrom(s => s.Location))
                .ForMember(d => d.Department, opt => opt.MapFrom(s => s.Department))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(s => (s.EndDate == null ? true : false)));
        }
    }
}
