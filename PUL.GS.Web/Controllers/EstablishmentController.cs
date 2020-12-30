using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PUL.GS.DataAgents;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using PUL.GS.Web.Extensions;
using PUL.GS.Web.Models;
using PUL.GS.Web.Profiles;

namespace PUL.GS.Web.Controllers
{
    public class EstablishmentController : Controller
    {
        private readonly EstablishmentData _establishmentAgent;
        private readonly AccountData _accountAgent;
        //private readonly IMapper _mapper;
        public EstablishmentController(
             //IMapper mapper, 
             IOptions<AppSettings> appSettings)
        {
            _establishmentAgent = new EstablishmentData(appSettings.Value);
            _accountAgent = new AccountData(appSettings.Value);
            //this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            return View();
        }


        [HttpGet]
        public ActionResult Profile()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            var userId = user.Id;
            var result = _establishmentAgent.GetEstablishmentById(userId);

            if (result.Success)
            {
                user.Establishment = result.objectResult;
                var menu = _accountAgent.GetModulesByUserId(userId, null);
                if (menu.Success)
                {
                    user.Modules = menu.objectResult;
                }

                return View(result.objectResult);
            }

            return RedirectToAction("NewEstablishment", "Establishment");
        }


        [HttpGet]
        public IActionResult NewEstablishment()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> NewEstablishment(EstablishmentViewModel model) {

            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            string userId = user.Id;
            model.userId = userId;

            var entity = model.ToEstablishmentModel();
            var result = _establishmentAgent.CreateEstablishment(entity);
            user.Establishment = result.objectResult;
            HttpContext.Session.Set(Constants.SessionKeyState, user);

            return await Task.FromResult(Json(result));
        }
    }
}
