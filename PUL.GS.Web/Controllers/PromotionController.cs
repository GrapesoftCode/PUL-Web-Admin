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
    public class PromotionController : Controller
    {
        private readonly PromotionData _promotionAgent;
        public PromotionController(IOptions<AppSettings> appSettings)
        {
            _promotionAgent = new PromotionData(appSettings.Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetPromotionList()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            string userId = user.Id;
            string establishmentId = user.Establishment.id;
            var list = new Response<IEnumerable<Promotion>>() { Success = true };

            list = _promotionAgent.GetPromotions(userId, establishmentId);

            return await Task.FromResult(Json(list));
        }

        public IActionResult NewPromotion()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPromotion(PromotionViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            model.userId = user.Id;
            model.establishmentId = user.Establishment.id;

            var entity = model.ToPromotionModel();

            var result = _promotionAgent.CreatePromotion(entity);
            if (result.Success)
            {
                return await Task.FromResult(RedirectToAction("Index", "Promotion"));
            }
            //}
            return await Task.FromResult(View());
        }
    }
}
