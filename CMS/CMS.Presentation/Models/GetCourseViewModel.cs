
using CMS.Application.Aggregates.Course.Queries.GetCourse;
using Trainer = CMS.Application.Aggregates.Trainer.Queries.GetTrainer.Trainer;

namespace СMS.Models
{
    public class GetCourseViewModel
    {
        public Trainer Trainer { get; set; }
        public Course Course { get; set; }
    }
}
