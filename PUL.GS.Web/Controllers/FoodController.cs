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
    [Route("Food")]
    public class FoodController : Controller
    {
        private readonly FoodData _foodAgent;
        public FoodController(IOptions<AppSettings> appSettings)
        {
            _foodAgent = new FoodData(appSettings.Value);
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
        [Route("GetFoodList")]
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


        [Route("NewFood")]
        public IActionResult NewFood()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<JsonResult> Create(FoodViewModel model)
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            model.userId = user.Id;
            model.establishmentId = user.Establishment.id;

            var entity = model.ToFoodModel();

            var response = _foodAgent.CreateFood(entity);
            return await Task.FromResult(Json(response));
        }

        [HttpDelete]
        [Route("DeleteItem/{id}")]
        public async Task<JsonResult> DeleteItem(string id)
        {
            var response = _foodAgent.DeleteFood(id);

            return await Task.FromResult(Json(response));
        }


        [HttpGet]
        [Route("GetFoodDetails/{id}")]
        public async Task<JsonResult> GetFoodDetails(string id)
        {
            var response = _foodAgent.GetFoodById(id);
            //HttpContext.Session.Set("userId", id);
            return await Task.FromResult(Json(response));
        }


        [HttpPost]
        [Route("UpdateItem")]
        public async Task<JsonResult> Updatetem(FoodViewModel model)
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            model.userId = user.Id;
            model.establishmentId = user.Establishment.id;

            var entity = model.ToFoodModel();

            var response = _foodAgent.UpdateFood(entity);
            return await Task.FromResult(Json(response));
        }
    }
}
