﻿using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroupsList
{
    public class Trainer : IMapFrom<Domain.Entities.User.Trainer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User.Trainer, Trainer>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.Photo, opt => opt.MapFrom(s => s.User.Photo))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.User.LastName));
        }
    }
}
