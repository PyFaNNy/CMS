using CMS.Application.Aggregates.Course.Commands.CreateCourse;
using CMS.Application.Aggregates.Course.Commands.DeleteCourse;
using CMS.Application.Aggregates.Course.Commands.DeleteTrainer;
using CMS.Application.Aggregates.Course.Commands.EditCourse;
using CMS.Application.Aggregates.Course.Commands.EditTrainers;
using CMS.Application.Aggregates.Course.Queries.GetCourse;
using CMS.Application.Aggregates.Course.Queries.GetCourses;
using CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroupsList;
using CMS.Application.Aggregates.CourseType.Queries.GetCourseTypes;
using CMS.Application.Aggregates.Trainer.Queries.GetTrainer;
using CMS.Application.Aggregates.Trainer.Queries.GetTrainersList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using СMS.Models;

namespace СMS.Controllers
{
    public class CourseController : BaseController
    {
        public CourseController(ILogger<CourseController> logger)
            : base(logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetModels(int? pageIndex = 1, int? pageSize = 10)
        {
            var groups = await Mediator.Send(new GetCourseGroupsListQuery());
            ViewBag.Group = groups;
            var type = await Mediator.Send(new GetCourseTypesQuery());
            ViewBag.Type = type;
            var result = await Mediator.Send(new GetCoursesQuery(pageIndex, pageSize));
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetModelsUsers(int? pageIndex = 1, int? pageSize = 10)
        {
            var groups = await Mediator.Send(new GetCourseGroupsListQuery());
            ViewBag.Group = groups;
            var type = await Mediator.Send(new GetCourseTypesQuery());
            ViewBag.Type = type;
            var result = await Mediator.Send(new GetCoursesQuery(pageIndex, pageSize));
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetModel(Guid id, Guid? trainerId)
        {
            var result = new GetCourseViewModel();
            if (trainerId != null)
            {
                result.Trainer =  await Mediator.Send(new GetTrainerQuery() {TrainerId = trainerId.Value});
            }
            result.Course = await Mediator.Send(new GetCourseQuery { CourseId = id });
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddModel()
        {
            ViewBag.Group = await Mediator.Send(new GetCourseGroupsListQuery());
            ViewBag.Type = await Mediator.Send(new GetCourseTypesQuery());
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddModel(CreateCourseCommand command)
        {
            await Mediator.Send(command);

            return RedirectToAction("GetModels");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateModel(Guid id)
        {
            ViewBag.Group = await Mediator.Send(new GetCourseGroupsListQuery());
            ViewBag.Type = await Mediator.Send(new GetCourseTypesQuery());
            ViewBag.Course = await Mediator.Send(new GetCourseQuery() {CourseId = id});
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateModel(EditCourseCommand command, Guid id)
        {
            command.CourseId = id;
            await Mediator.Send(command);

            return RedirectToAction("GetModels");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditTrainers(Guid id)
        {
            var result = new EditCourseViewModel();

            result.CurrentCourse = await Mediator.Send(new GetCourseQuery() {CourseId = id});
            result.Trainers = await Mediator.Send(new GetTrainersListQuery());
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditTrainers(EditCourseViewModel model, Guid courseId)
        {
            model.EditTrainerCommand.CourseId = courseId;
            await Mediator.Send(model.EditTrainerCommand);

            return RedirectToAction("EditTrainers" ,new {id = courseId});
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteTrainer(Guid trainerId, Guid courseId)
        {

            await Mediator.Send(new DeleteTrainerCommand()
            {
                TrainerId = trainerId,
                CourseId = courseId
            });

            return RedirectToAction("EditTrainers" ,new { id = courseId });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<RedirectToActionResult> DeleteModelAsync(Guid id)
        {
            await Mediator.Send(new DeleteCourseCommand { CourseId = id });
            return RedirectToAction("GetModels");
        }
    }
}
