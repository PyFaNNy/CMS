using AutoMapper;
using CMS.Application.Mappings;
using MediatR;

namespace CMS.Application.Aggregates.CourseGroup.Commands.CreateCourseGroup
{
    public class CreateCourseGroupCommand : IRequest<Unit>, IMapTo<Domain.Entities.Course.CourseGroup>
    {
        public string Name { get; set; }
        public int VisualOrder { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCourseGroupCommand, Domain.Entities.Course.CourseGroup>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}
