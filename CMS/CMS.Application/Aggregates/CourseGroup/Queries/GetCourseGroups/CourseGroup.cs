using AutoMapper;
using CMS.Application.Mappings;

namespace CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroups
{
    public class CourseGroup : IMapFrom<Domain.Entities.Course.CourseGroup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VisualOrder { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Course.CourseGroup, CourseGroup>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder));
        }
    }
}
