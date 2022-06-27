using CMS.Application.Aggregates.CourseGroup.Commands.CreateCourseGroup;
using CMS.Application.Aggregates.CourseGroup.Commands.DeleteCourseGroup;
using CMS.Application.Aggregates.CourseGroup.Commands.EditCourseGroup;
using CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroup;
using CMS.Application.Aggregates.CourseGroup.Queries.GetCourseGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using СMS.Models;

namespace СMS.Controllers
{
    public class CourseGroupController : BaseController
    {
        public CourseGroupController(ILogger<CourseGroupController> logger)
            : base(logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetModels(int? pageIndex = 1, int? pageSize = 10, Guid? id = null)
        {
            var result = new CourseGroupViewModel();
            result.List = await Mediator.Send(new GetCourseGroupsQuery(pageIndex, pageSize));
            if (id != null)
            {
                result.Current = await Mediator.Send(new GetCourseGroupQuery() {CourseId = id.Value});
            }
            return View(result);
        }
        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddModel(CourseGroupViewModel command)
        {
            await Mediator.Send(new CreateCourseGroupCommand()
            {
                Description = command.CreateModel.Description,
                Name = command.CreateModel.Name,
                VisualOrder = command.CreateModel.VisualOrder
            });
            return RedirectToAction("GetModels");
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateModel(CourseGroupViewModel command, Guid CourseGroupId)
        {
            await Mediator.Send(new EditCourseGroupCommand()
            {
                CourseGroupid = CourseGroupId,
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
            await Mediator.Send(new DeleteCourseGroupCommand { CourseGroupId = id });
            return RedirectToAction("GetModels");
        }
    }
}
