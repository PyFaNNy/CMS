using CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroupsList;
using Trainer = CMS.Application.Aggregates.Trainer.Queries.GetTrainer.Trainer;

namespace СMS.Models
{
    public class TrainerGroupUserViewModel
    {
        public List<TrainerGroup> TrainerGroups { get; set; }
        public Trainer Current { get; set; }
    }
}
