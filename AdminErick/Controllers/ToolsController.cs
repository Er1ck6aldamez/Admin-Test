using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminErick.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult NotAuthorized()
        {
            ViewBag.Title = "Autorización";
            ViewBag.Message = "Lo sentimos, no cuentas con los permisos para acceder a esta área del sistema";
            ViewBag.Alert = "Contacta al administrador para mayor información";
            return View();
        }
    }
}