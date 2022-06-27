using CMS.Application.Aggregates.User.Commands.SignIn;
using CMS.Application.Aggregates.User.Queries.GetUserByEmail;
using CMS.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using СMS.Models;

namespace СMS.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ILogger<AccountController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignInCommand command)
        {
            await Mediator.Send(command);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
                var user = await Mediator.Send(new GetUserByEmailQuery(model.UserName));
                var result = CryptoHelper.VerifyHashedPassword(user.PasswordHash, model.Password);

                if (result)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction(nameof(CourseController.GetModelsUsers), "Course");
            }
                else
                {
                    ModelState.AddModelError("", "Error login/password");
                }

                return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(CourseController.GetModelsUsers), "Course");
        }
    }
}
