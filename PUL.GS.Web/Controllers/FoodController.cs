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
    public class FoodController : Controller
    {
        private readonly FoodData _foodAgent;
        public FoodController(IOptions<AppSettings> appSettings)
        {
            _foodAgent = new FoodData(appSettings.Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetFoodList()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            string userId = user.Id;
            string establishmentId = user.Establishment.id;
            var list = new Response<IEnumerable<Food>>() { Success = true };

            list = _foodAgent.GetFoods(userId, establishmentId);

            return await Task.FromResult(Json(list));
        }

        public IActionResult NewFood()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewFood(FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

                int rolId = user.Role.Id;
                model.userId = user.Id;
                model.establishmentId = user.Establishment.id;

                var entity = model.ToFoodModel();

                var result = _foodAgent.CreateFood(entity);
                if (result.Success)
                {
                    return await Task.FromResult(RedirectToAction("Index", "Food"));
                }
            }
            return await Task.FromResult(View());
        }
    }
}
