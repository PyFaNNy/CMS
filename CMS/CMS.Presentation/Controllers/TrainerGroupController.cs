using CMS.Application.Aggregates.Trainer.Queries.GetTrainer;
using CMS.Application.Aggregates.TrainerGroup.Commands.CreateTrainerGroup;
using CMS.Application.Aggregates.TrainerGroup.Commands.DeleteTrainerGroup;
using CMS.Application.Aggregates.TrainerGroup.Commands.EditTrainerGroup;
using CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroup;
using CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroups;
using CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroupsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using СMS.Models;

namespace СMS.Controllers
{
    public class TrainerGroupController : BaseController
    {
        public TrainerGroupController(ILogger<TrainerGroupController> logger)
            : base(logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetModels(int? pageIndex = 1, int? pageSize = 10, Guid? id = null)
        {
            var result = new TrainerGroupViewModel();
            result.List = await Mediator.Send(new GetTrainerGroupsQuery(pageIndex, pageSize));
            if (id != null)
            {
                result.Current = await Mediator.Send(new GetTrainerGroupQuery() { TrainerGroupId = id.Value });
            }
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetModelsUsers( Guid? id = null)
        {
            var result = new TrainerGroupUserViewModel();
            result.TrainerGroups = await Mediator.Send(new GetTrainerGroupsListQuery());
            if (id != null)
            {
                result.Current = await Mediator.Send(new GetTrainerQuery() { TrainerId = id.Value });
            }
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddModel(TrainerGroupViewModel command)
        {
            await Mediator.Send(new CreateTrainerGroupCommand()
            {
                Description = command.CreateModel.Description,
                Name = command.CreateModel.Name,
                VisualOrder = command.CreateModel.VisualOrder
            });
            return RedirectToAction("GetModels");
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateModel(TrainerGroupViewModel command, Guid TrainerGroupId)
        {
            await Mediator.Send(new EditTrainerGroupCommand()
            {
                TrainerGroupId = TrainerGroupId,
                Description = command.EditModel.Description,
                Name = command.EditModel.Name,
                VisualOrder = command.EditModel.VisualOrder
            });
            return RedirectToAction("GetModels");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<RedirectToActionResult> DeleteModelAsync(Guid id)
        {
            await Mediator.Send(new DeleteTrainerGroupCommand { TrainerGroupId = id });
            return RedirectToAction("GetModels");
        }
    }
}
