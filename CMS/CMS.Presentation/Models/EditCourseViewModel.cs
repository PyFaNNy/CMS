using CMS.Application.Aggregates.Course.Commands.DeleteTrainer;
using CMS.Application.Aggregates.Course.Commands.EditTrainers;
using CMS.Application.Aggregates.Course.Queries.GetCourse;

namespace СMS.Models
{
    public class EditCourseViewModel
    {
        public List<CMS.Application.Aggregates.Trainer.Queries.GetTrainersList.Trainer> Trainers { get; set; }
        public Course CurrentCourse { get; set; }
        public EditTrainersCommand EditTrainerCommand { get; set; } = new EditTrainersCommand();
        public DeleteTrainerCommand DeleteTrainerCommand { get; set; } = new DeleteTrainerCommand();
    }
}
