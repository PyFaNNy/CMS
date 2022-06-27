using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.Course.Queries.GetCourses
{
    public class Course : IMapFrom<Domain.Entities.Course.Course>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CourseType { get; set; }
        public string CourseGroup { get; set; }
        public string Description { get; set; }
        public List<Trainer> Trainers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Course.Course, Course>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.CourseType, opt => opt.MapFrom(s => s.CourseType.Name))
                .ForMember(d => d.CourseGroup, opt => opt.MapFrom(s => s.CourseGroup.Name))
                .ForMember(d => d.Trainers, opt => opt.MapFrom(s => s.Trainers));
        }
    }
}
