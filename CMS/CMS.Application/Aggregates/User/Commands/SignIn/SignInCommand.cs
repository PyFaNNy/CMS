using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using CMS.Application.Mappings;
using CMS.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CMS.Application.Aggregates.User.Commands.SignIn
{
    public class SignInCommand : IRequest<Unit>, IMapTo<Domain.Entities.User.User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public IFormFile Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SignInCommand, Domain.Entities.User.User>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => CryptoHelper.HashPassword(s.Password)))
                .ForMember(d => d.PasswordSalt, opt => opt.MapFrom(s => CryptoHelper.HashPassword(s.Password)))
                .ForMember(d => d.Location, opt => opt.MapFrom(s => s.Location))
                .ForMember(d => d.Position, opt => opt.MapFrom(s => s.Position))
                .ForMember(d => d.Department, opt => opt.MapFrom(s => s.Department));
        }
    }
}
