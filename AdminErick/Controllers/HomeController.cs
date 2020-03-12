using AdminErick.Filters;
using AdminErick.Models.Entities.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminErick.Controllers
{
    public class HomeController : Controller
    {
        [UserAuthorization(pri: "public",view: "Dashboard")]
        public ActionResult Dashboard()
        {
            return View();
        }
        [UserAuthorization(pri: "Administrador", view: "Icons")]
        public ActionResult Icons()
        {
            return View();
        }
        [UserAuthorization(pri: "Administrador", view: "Map")]
        public ActionResult Map()
        {
            return View();
        }
    }
}