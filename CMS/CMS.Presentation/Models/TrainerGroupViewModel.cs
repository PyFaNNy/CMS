using CMS.Application.Aggregates.TrainerGroup.Commands.CreateTrainerGroup;
using CMS.Application.Aggregates.TrainerGroup.Commands.EditTrainerGroup;
using CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroup;
using CMS.Application.Models;

namespace СMS.Models
{
    public class TrainerGroupViewModel
    {
        public PaginatedList<CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroups.TrainerGroup> List
        {
            get;
            set;
        }

        public CreateTrainerGroupCommand CreateModel
        {
            get;
            set;
        } = new CreateTrainerGroupCommand();

        public EditTrainerGroupCommand EditModel
        {
            get;
            set;
        } = new EditTrainerGroupCommand();

        public TrainerGroup Current
        {
            get;
            set;
        }
    }
}
