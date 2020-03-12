using AdminErick.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminErick.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UserAuthorization : AuthorizeAttribute
    {
        private Users users;
        private string typePrivacity = string.Empty, showView = "";

        public UserAuthorization(string pri, string view)
        {
            this.typePrivacity = pri;
            this.showView = view;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            string rolUserLogged = "";
            users = (Users)HttpContext.Current.Session["Userlogged"];
            try
            {
                using (db_AdminErickEntities db = new db_AdminErickEntities())
                {
                    rolUserLogged = (from result in db.Users
                                     where result.Id == users.Id
                                     select result).FirstOrDefault().Roles.RoleName;
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            filterContext.Result = new RedirectResult(
                    (typePrivacity == "public" ? "~/Home/" + showView + "/" : 
                            (rolUserLogged == typePrivacity) ? "~/Home/" + showView + "/" : 
                                        "~/Tools/NotAuthorized/"
                    ));
        }
    }
}