using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.User.Queries.GetUserByEmail
{
    public class User : IMapFrom<Domain.Entities.User.User>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User.User, User>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.PasswordHash, opt => opt.MapFrom(s => s.Password))
                .ForMember(d => d.IsAdmin, opt => opt.MapFrom(s => s.Roles.FirstOrDefault(x => x.Name == "Admin") != null ? true : false));
        }
    }
}
