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
        public BookController(IOptions<AppSettings> appSettings, IOptions<OneSignal> oneSignal)
        {
            _bookAgent = new BookData(appSettings.Value, oneSignal.Value);
        }

        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            return View();
        }

        public IActionResult Pending()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.Logo = user.Establishment.Logo.Uri;
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            ViewBag.Email = user.Email;
            ViewBag.FullName = user.FirstName + " " + user.SurName + " " + user.LastName;
            ViewBag.Logo = user.Establishment.Logo.Uri;
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

        [HttpPost]
        public async Task<JsonResult> GetListBooksByBookState()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            string establishmentId = user.Establishment.id;
            int bookState = 1;
            var list = new Response<IEnumerable<Book>>() { Success = true };

            list = _bookAgent.GetListBooksByBookState(establishmentId, bookState);

            return await Task.FromResult(Json(list));
        }


        [HttpPost]
        public async Task<JsonResult> UpdateBook([FromBody] BookUpdate updateBook)
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);

            string establishmentId = user.Establishment.id;
            var result = new Response<Book>() { Success = true };
            var book = new Book()
            {
                id = updateBook.id,
                BookStatus = updateBook.BookStatus
            };

            result = _bookAgent.UpdateBook(establishmentId, book);
            if (result.Success)
            {
                var bookResult = result.objectResult;
                string[] playersId = new string[] { bookResult.PlayerId };
                Notification notification = new Notification()
                {
                    app_id = "58997a76-3b19-4c01-9909-85d729b19784",
                    url = "https://app.onesignal.com",
                    include_player_ids = playersId,
                    headings = new Language()
                    {
                        en = "PUL Reservación"
                    }
                };

                if (updateBook.BookStatus == 2){
                    notification.contents = new Language()
                    {
                        en = "Su reservación ha sido aceptada."
                    };
                }
                else {
                    notification.contents = new Language()
                    {
                        en = "Su reservación fue cancelada."
                    };
                }

                var notificationResult = _bookAgent.CreateNotification(notification);
                if (!notificationResult.Success)
                {
                    result.Error = new Error()
                    {
                        Message = $"Se actualizo la solicitud y el usuario no fue notificado, contacte al area de sistemas."
                    };
                    result.Success = false;
                }
            }

            return await Task.FromResult(Json(result));
        }

    }
}
