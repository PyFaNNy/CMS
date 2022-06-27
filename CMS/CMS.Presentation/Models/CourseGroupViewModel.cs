using CMS.Application.Aggregates.CourseGroup.Commands.CreateCourseGroup;
using CMS.Application.Aggregates.CourseGroup.Commands.EditCourseGroup;
using CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroup;
using CMS.Application.Models;

namespace СMS.Models
{
    public class CourseGroupViewModel
    {
        public PaginatedList<CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroups.CourseGroup> List 
        { 
            get;
            set;
        }

        public CreateCourseGroupCommand CreateModel
        {
            get;
            set;
        } = new CreateCourseGroupCommand();

        public EditCourseGroupCommand EditModel
        {
            get;
            set;
        } = new EditCourseGroupCommand();

        public CourseGroup Current
        {
            get;
            set;
        }
    }
}
