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

namespace PUL.GS.Web.Controllers
{
    public class TableController : Controller
    {
        private readonly TableData _tableAgent;
        public TableController(IOptions<AppSettings> appSettings)
        {
            _tableAgent = new TableData(appSettings.Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetTableList()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            int rolId = user.Role.Id;
            string userId = user.Id;
            string establishmentId = user.Establishment.id;
            var list = new Response<IEnumerable<Table>>() { Success = true };
           
            list = _tableAgent.GetTables(userId, establishmentId);
           
            return await Task.FromResult(Json(list));
        }

        public IActionResult NewTable()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewTable(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

                int rolId = user.Role.Id;
                string userId = user.Id;
                string establishmentId = user.Establishment.id;

                Table table = new Table()
                {
                    establishmentId = establishmentId,
                    userId = userId,
                    Location = form["location"],
                    Logo = "../assets/images/table/mesa.jpg",
                    Quantity = Convert.ToInt32(form["quantity"]),
                    SelectType = form["selectType"],
                    MinimumConsumption = Convert.ToDouble(form["minimumConsumption"]),
                    SmokingArea = !string.IsNullOrEmpty(form["smokingArea"]) ? true : false,
                    Vacant = true
                };


                var result = _tableAgent.CreateTable(table);
                if (result.Success)
                {
                    return await Task.FromResult(RedirectToAction("Index", "Table"));
                }
            }
            return await Task.FromResult(View());
        }
    }
}
