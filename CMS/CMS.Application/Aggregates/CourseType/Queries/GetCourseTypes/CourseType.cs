using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.CourseType.Queries.GetCourseTypes
{
    public class CourseType : IMapFrom<Domain.Entities.Course.CourseType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Course.CourseType, CourseType>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
