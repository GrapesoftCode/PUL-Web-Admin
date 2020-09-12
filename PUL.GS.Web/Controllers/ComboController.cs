using System;
using System.Collections.Generic;
using System.IO;
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
    public class ComboController : Controller
    {
        private readonly ComboData _comboAgent;
        public ComboController(IOptions<AppSettings> appSettings)
        {
            _comboAgent = new ComboData(appSettings.Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetComboList()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            string userId = user.Id;
            string establishmentId = user.Establishment.id;
            var list = new Response<IEnumerable<Combo>>();
           
            list = _comboAgent.GetCombos(userId, establishmentId);
            return await Task.FromResult(Json(list));
        }


        public IActionResult NewCombo()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCombo(ComboViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            model.userId = user.Id;
            model.establishmentId = user.Establishment.id;
            var entity = model.ToComboModel();
            var result = _comboAgent.CreateCombo(entity);
            if (result.Success)
            {
                return await Task.FromResult(RedirectToAction("Index", "Combo"));
            }
            //}
            return await Task.FromResult(View());
        }
    }
}
