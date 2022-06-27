using CMS.Application.Aggregates.Trainer.Commands.CreateTrainer;
using CMS.Application.Aggregates.Trainer.Commands.DeleteTrainer;
using CMS.Application.Aggregates.Trainer.Commands.EditTrainer;
using CMS.Application.Aggregates.Trainer.Queries.GetTrainer;
using CMS.Application.Aggregates.Trainer.Queries.GetTrainers;
using CMS.Application.Aggregates.TrainerGroup.Queries.GetTrainerGroupsList;
using CMS.Application.Aggregates.User.Queries.GetUsersList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace СMS.Controllers
{
    public class TrainerController : BaseController
    {
        public TrainerController(ILogger<TrainerController> logger)
            : base(logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetModels(int? pageIndex = 1, int? pageSize = 10)
        {
            var result = await Mediator.Send(new GetTrainersQuery(pageIndex, pageSize));
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetModel(Guid id)
        {
            var result = await Mediator.Send(new GetTrainerQuery { TrainerId = id });
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddModel()
        {
            ViewBag.Group = await Mediator.Send(new GetTrainerGroupsListQuery());
            ViewBag.Users = await Mediator.Send(new GetUsersListQuery());
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddModel(CreateTrainerCommand command)
        {
            await Mediator.Send(command);
            return RedirectToAction("GetModels");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateModel(Guid id)
        {
            ViewBag.Trainer = await Mediator.Send(new GetTrainerQuery() { TrainerId = id });
            ViewBag.Group = await Mediator.Send(new GetTrainerGroupsListQuery());
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateModel(EditTrainerCommand command, Guid id)
        {
            command.TrainerId = id;
            await Mediator.Send(command);
            return RedirectToAction("GetModels");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<RedirectToActionResult> DeleteModelAsync(Guid id)
        {
            await Mediator.Send(new DeleteTrainerCommand { TrainerId = id });
            return RedirectToAction("GetModels");
        }
    }
}
