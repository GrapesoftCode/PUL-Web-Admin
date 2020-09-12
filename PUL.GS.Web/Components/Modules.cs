using Microsoft.AspNetCore.Mvc;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using PUL.GS.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace PUL.GS.Web.Components
{
    public class Modules : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.Session.Get<User>(Constants.SessionKeyState);
            var modules = HttpContext.Session.Get<string>(Constants.Moduleskey);
            string menu = string.Empty;

            if (modules == null)
            {
                menu = await ExecuteUserMenu(user.Modules);
                HttpContext.Session.Set(Constants.Moduleskey, menu);
                modules = menu;
            }

            user.ModulesString = modules;

            return View(user);
        }

        private async Task<string> ExecuteUserMenu(List<Module> listModules)
        {
            string menuDin = "<ul id='sidebarnav'>";
            menuDin += $"<li class=\"sidebar-item\"> <a class=\"sidebar-link waves-effect waves-dark sidebar-link\" href='{Url.Action("Dashboard", "Establishment")}' aria-expanded=\"false\"><i class=\"mdi mdi-av-timer\"></i><span class=\"hide-menu\">Dashboard</span></a></li>";

            foreach (var module in listModules)
            {
                menuDin += "<li class=\"sidebar-item\">" +
                            "<a class=\"sidebar-link has-arrow waves-effect waves-dark sidebar-link\" href=\"javascript:void(0)\" aria-expanded=\"false\">" +
                                "<i class='" + module.Icon + "'></i>" +
                                "<span class=\"hide-menu\">" + module.Tag + "</span>" +
                            "</a>" +
                            "<ul aria-expanded=\"false\" class=\"collapse first-level\">";

                foreach (var submodules in module.Submodules)
                {
                    menuDin += "<li class=\"sidebar-item\">" +
                                $"<a href='{Url.Action(submodules.Action, submodules.Controller)}' class=\"sidebar-link\">";
                    menuDin += "<i class='" + submodules.Icon + "'></i>";
                    menuDin += "<span class=\"hide-menu\">" + submodules.Tag + "</span>";
                    menuDin += "</a>";
                    menuDin += "</li>";
                }
                menuDin += "</ul>";
                menuDin += "</li>";
            }
            menuDin += "</ul>";

            return await Task.FromResult(menuDin);
        }
    }
}
