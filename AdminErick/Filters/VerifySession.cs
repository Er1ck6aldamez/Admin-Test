using AdminErick.Controllers;
using AdminErick.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminErick.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        private Users Users;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                Users = (Users)HttpContext.Current.Session["Userlogged"];

                if (Users == null)
                {
                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Login/Index");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
    }
}