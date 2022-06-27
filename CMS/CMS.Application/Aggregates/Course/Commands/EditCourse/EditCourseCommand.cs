using AutoMapper;
using CMS.Application.Mappings;
using MediatR;

namespace CMS.Application.Aggregates.Course.Commands.EditCourse
{
    public class EditCourseCommand : IRequest<Unit>, IMapTo<Domain.Entities.Course.Course>
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public int VisualOrder { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public Guid CourseTypeId { get; set; }
        public Guid CourseGroupId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditCourseCommand, Domain.Entities.Course.Course>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.VisualOrder, opt => opt.MapFrom(s => s.VisualOrder))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.IsNew, opt => opt.MapFrom(s => s.IsNew))
                .ForMember(d => d.CourseTypeId, opt => opt.MapFrom(s => s.CourseTypeId))
                .ForMember(d => d.CourseGroupId, opt => opt.MapFrom(s => s.CourseGroupId));
        }
    }
}
