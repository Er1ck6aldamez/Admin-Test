using AdminErick.Models.DataAccess;
using AdminErick.Models.Entities.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminErick.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (db_AdminErickEntities db = new db_AdminErickEntities())
                    {
                        Users users = (from result in db.Users
                                       where result.Password.Trim() == login.Password.Trim() &&
                                             result.UserName.Trim() == login.UserName.Trim()
                                       select result ).FirstOrDefault();

                        if (users == null)
                        {
                            ViewBag.Error = "Usuario no encontrado\nVerifica tus credenciales";
                            return View(login);
                        }

                        Session["Userlogged"] = users;
                        return Redirect("~/Users");
                    }
                }
                return View(login);
            }
            catch (Exception)
            {
                return Redirect("~/Error");
            }
        }
    }
}