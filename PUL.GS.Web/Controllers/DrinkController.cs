using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    [Route("Drink")]
    public class DrinkController : Controller
    {
        private readonly DrinkData _drinkAgent;
        public DrinkController(IOptions<AppSettings> appSettings)
        {
            _drinkAgent = new DrinkData(appSettings.Value);
        }

        [Route("")]
        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            return View();
        }

        [HttpPost]
        [Route("GetDrinkList")]
        public async Task<JsonResult> GetDrinkList()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            string userId = user.Id;
            string establishmentId = user.Establishment.id;
            var list = new Response<IEnumerable<Drink>>() { Success = true };

            list = _drinkAgent.GetDrinks(userId, establishmentId);

            return await Task.FromResult(Json(list));
        }

        [Route("NewDrink")]
        public IActionResult NewDrink()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<JsonResult> Create(DrinkViewModel model)
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            model.userId = user.Id;
            model.establishmentId = user.Establishment.id;

            var entity = model.ToDrinkModel();

            var response = _drinkAgent.CreateDrink(entity);
            return await Task.FromResult(Json(response));
        }

        [HttpDelete]
        [Route("DeleteItem/{id}")]
        public async Task<JsonResult> DeleteItem(string id)
        {
            var response = _drinkAgent.DeleteDrink(id);

            return await Task.FromResult(Json(response));
        }

        [HttpGet]
        [Route("GetDrinkDetails/{id}")]
        public async Task<JsonResult> GetDrinkDetails(string id)
        {
            var response = _drinkAgent.GetDrinkById(id);
            //HttpContext.Session.Set("userId", id);
            return await Task.FromResult(Json(response));
        }

        [HttpPost]
        [Route("UpdateItem")]
        public async Task<JsonResult> Updatetem(DrinkViewModel model)
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            model.userId = user.Id;
            model.establishmentId = user.Establishment.id;

            var entity = model.ToDrinkModel();

            var response = _drinkAgent.UpdateDrink(entity);
            return await Task.FromResult(Json(response));
        }
    }
}
