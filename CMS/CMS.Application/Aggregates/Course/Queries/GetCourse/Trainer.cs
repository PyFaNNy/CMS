﻿using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.Course.Queries.GetCourse
{
    public class Trainer : IMapFrom<Domain.Entities.User.Trainer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int VisualOrder { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User.Trainer, Trainer>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.User.LastName));
        }
    }
}
