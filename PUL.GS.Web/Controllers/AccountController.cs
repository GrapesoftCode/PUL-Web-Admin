using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PUL.GS.DataAgents;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using PUL.GS.Web.Controllers.Base;
using PUL.GS.Web.Extensions;
using PUL.GS.Web.Models;
using PUL.GS.Web.Models.Managers;

namespace PUL.GS.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly AccountData _accountAgent;
        private readonly EstablishmentData _establishmentAgent;
        public AccountController(
            IUserManager<User> userManager,
            ISignInManager<User> signInManager,
            IOptions<AppSettings> appSettings)
            : base(userManager, signInManager)
        {
            _accountAgent = new AccountData(appSettings.Value);
            _establishmentAgent = new EstablishmentData(appSettings.Value);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var token = _accountAgent.GetToken(user);
                if (token.Success)
                {
                    HttpContext.Session.Set(Constants.SessionKeyState, token.objectResult);
                    user.Token = token.objectResult;
                    var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var modules = _accountAgent.GetUserByCredentials(user.Username, user.Password, HttpContext.Session.Get<string>("token"));
                        var userId = modules.objectResult.Id;
                        var establishment = _establishmentAgent.GetEstablishmentById(userId);
                        modules.objectResult.Establishment = establishment.objectResult;


                        //ViewBag["UserData"] = modules.objectResult;
                        HttpContext.Session.Set(Constants.SessionKeyState, modules.objectResult);

                        this.User.GetUserId();
                        return await Task.FromResult(RedirectToAction("Dashboard", "Establishment"));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid credentials");
                    }
                }
            }
            return await Task.FromResult(View(user));
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return await Task.FromResult(RedirectToAction("", ""));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = new Role { Id = 2, Name = "Manager" };
                var result = _accountAgent.AddUser(user);
                if (result.Success)
                {
                    return await Task.FromResult(RedirectToAction("Login", "Account"));
                }
            }
            return await Task.FromResult(View());
        }
    }
}
