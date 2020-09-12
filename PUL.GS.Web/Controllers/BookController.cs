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
using PUL.GS.Web.Controllers.Base;
using PUL.GS.Web.Extensions;

namespace PUL.GS.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly BookData _bookAgent;
        public BookController(IOptions<AppSettings> appSettings)
        {
            _bookAgent = new BookData(appSettings.Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pending()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GeneralReportStatusBooks()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            string establishmentId = user.Establishment.id;
            var list = new Response<IEnumerable<GeneralReportStatusBooks>>() { Success = true };

            list = _bookAgent.GeneralReportStatusBooks(establishmentId);

            return await Task.FromResult(Json(list));
        }
    }
}
