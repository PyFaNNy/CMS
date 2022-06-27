using CMS.Application.Aggregates.Roles.Queries.GetRoles;
using CMS.Application.Aggregates.User.Commands.ChangePassword;
using CMS.Application.Aggregates.User.Commands.ChangeRoles;
using CMS.Application.Aggregates.User.Commands.DeleteRole;
using CMS.Application.Aggregates.User.Queries.GetUser;
using CMS.Application.Aggregates.User.Queries.GetUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using СMS.Models;

namespace СMS.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ILogger<UserController> logger)
            : base(logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetModels(int? pageIndex = 1, int? pageSize = 10)
        {
            var result = await Mediator.Send(new GetUsersQuery(pageIndex, pageSize));
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetModel(Guid id)
        {
            var result = await Mediator.Send(new GetUserQuery { UserId = id });

            return View(result);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateModel(Guid id)
        {
            var result = new UpdateUserViewModel();
            result.User = await Mediator.Send(new GetUserQuery { UserId = id });
            var roles = await Mediator.Send(new GetRolesQuery());
            ViewBag.Roles = roles;
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ResetPassword(UpdateUserViewModel model, Guid UserId)
        {
            await Mediator.Send(new ChangePasswordCommand()
            {
                UserId = UserId,
                Password = model.PasswordCommand.Password,
                ConfirmPassword = model.PasswordCommand.ConfirmPassword
            });
            return RedirectToAction("GetModel", new { id = UserId });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditRoles(UpdateUserViewModel model, Guid UserId)
        {
            await Mediator.Send(new ChangeRolesCommand()
            {
                UserId = UserId,
                RoleIds = model.RolesCommand.RoleIds
            });
            return RedirectToAction("UpdateModel", new { id = UserId });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRoles(Guid roleId, Guid userId)
        {
            await Mediator.Send(new DeleteRoleCommand()
            {
                RoleId = roleId,
                UserId = userId
            });
            return RedirectToAction("UpdateModel", new { id = userId});
        }
    }
}
