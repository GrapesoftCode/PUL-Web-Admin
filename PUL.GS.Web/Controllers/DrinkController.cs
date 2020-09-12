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
    public class DrinkController : Controller
    {
        private readonly DrinkData _drinkAgent;
        public DrinkController(IOptions<AppSettings> appSettings)
        {
            _drinkAgent = new DrinkData(appSettings.Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
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

        public IActionResult NewDrink()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewDrink(DrinkViewModel model)
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            model.userId = user.Id;
            model.establishmentId = user.Establishment.id;
            var entity = model.ToDrinkModel();
            var result = _drinkAgent.CreateDrink(entity);
            if (result.Success)
            {
                return await Task.FromResult(RedirectToAction("Index", "Drink"));
            }
            return await Task.FromResult(View());
        }
    }
}
