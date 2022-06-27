using AutoMapper;
using CMS.Application.Mappings;
using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Commands.EditCourseGroup
{
    public class EditCourseGroupCommand : IRequest<Unit>, IMapTo<Domain.Entities.Course.CourseGroup>
    {
        public Guid CourseGroupid { get; set; }
        public string Name { get; set; }
        public int VisualOrder { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditCourseGroupCommand, Domain.Entities.Course.CourseGroup>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}
