using AdminErick.Models.DataAccess;
using AdminErick.Models.Entities.members;
using AdminErick.Models.Entities.roles;
using AdminErick.Models.Entities.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AdminErick.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        #region Index
        public ActionResult Index()
        {
            List<UserShowList> lstUsers = new List<UserShowList>();
            using (db_AdminErickEntities db = new db_AdminErickEntities())
            {
                lstUsers = (from lst in db.Users
                            select new UserShowList()
                            {
                                IdUser = lst.Id,
                                MembershipName = lst.Memberships.MembershipName,
                                RolName = lst.Roles.RoleName,
                                UserName = lst.UserName
                            }).ToList();
            }
            return View(lstUsers);
        }
        #endregion

        // POST: add
        #region Create
        public ActionResult AddNew()
        {
            UserEdit userEdit = new UserEdit();
            userEdit.RolSelected = GetRoles();
            userEdit.MembershipSelected = GetMemberships();
            return View(userEdit);
        }

        [HttpPost]
        public ActionResult AddNew(UserEdit userEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userEdit.Password.Trim().Equals(userEdit.PasswordRepeat.Trim()))
                    {
                        using (Models.DataAccess.db_AdminErickEntities db = new Models.DataAccess.db_AdminErickEntities())
                        {
                            Users users = new Users();
                            users.IdMembership = int.Parse(userEdit.IdMembership.ToString());
                            users.IdRole = int.Parse(userEdit.IdRol.ToString());
                            users.Password = userEdit.Password.Trim();
                            users.UserName = userEdit.UserName.Trim();

                            db.Users.Add(users);
                            db.SaveChanges();

                            return Redirect("~/Users/Success/");
                        }
                    }
                    ViewBag.ErrorPass = "Las contraseñas no coinciden";
                }
                userEdit.RolSelected = GetRoles();
                userEdit.MembershipSelected = GetMemberships();
                return View(userEdit);
            }
            catch (Exception e)
            {
                return Redirect("~/Error/");
            }
        }
        #endregion


        // POST: Edit
        #region EditData
        public ActionResult EditData(int Id)
        {
            try
            {
                UserEdit userEdit = new UserEdit();
                using (db_AdminErickEntities db = new db_AdminErickEntities())
                {
                    var _data = db.Users.Where(p => p.Id == Id).FirstOrDefault();

                    userEdit.Id = _data.Id;
                    userEdit.Password = _data.Password;
                    userEdit.PasswordRepeat = _data.Password;
                    userEdit.UserName = _data.UserName;
                    userEdit.IdMembership = _data.IdMembership;
                    userEdit.IdRol = _data.IdRole;
                    userEdit.RolSelected = GetRoles();
                    userEdit.MembershipSelected = GetMemberships();
                }
                return View(userEdit);
            }
            catch (Exception)
            {
                return Redirect("~/Error/");
            }
        }

        [HttpPost]
        public ActionResult EditData(UserEdit userEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userEdit.Password.Trim().Equals(userEdit.PasswordRepeat.Trim()))
                    {
                        using (db_AdminErickEntities db = new db_AdminErickEntities())
                        {
                            Users users = new Users();
                            users.Id = userEdit.Id;
                            users.IdMembership = int.Parse(userEdit.IdMembership.ToString());
                            users.IdRole = int.Parse(userEdit.IdRol.ToString());
                            users.Password = userEdit.Password.Trim();
                            users.UserName = userEdit.UserName.Trim();

                            db.Entry(users).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            return Redirect("~/Users/Success/");
                        }
                    }
                    ViewBag.ErrorPass = "Las contraseñas no coinciden";
                }
                userEdit.RolSelected = GetRoles();
                userEdit.MembershipSelected = GetMemberships();
                return View(userEdit);
            }
            catch (Exception e)
            {
                return Redirect("~/Error/");
            }
        }
        #endregion


        // POST: ViewDetail
        #region ViewDetail
        public ActionResult ViewDetail(int Id)
        {
            try
            {
                UserShowList user = new UserShowList();
                using (db_AdminErickEntities db = new db_AdminErickEntities())
                {
                    var _data = db.Users.Where(p => p.Id == Id).FirstOrDefault();

                    user.IdUser = _data.Id;
                    user.UserName = _data.UserName;
                    user.RolName = _data.Roles.RoleName;
                    user.MembershipName = _data.Memberships.MembershipName;
                }
                return View(user);
            }
            catch (Exception)
            {
                return Redirect("~/Error/");
            }
        }
        #endregion


        // POST: Delete
        #region DeleteData
        public ActionResult DeleteData(int Id)
        {
            try
            {
                UserEdit userEdit = new UserEdit();
                using (db_AdminErickEntities db = new db_AdminErickEntities())
                {
                    var _data = db.Users.Where(p => p.Id == Id).FirstOrDefault();

                    userEdit.Id = _data.Id;
                    userEdit.UserName = _data.UserName;
                }
                return View(userEdit);
            }
            catch (Exception)
            {
                return Redirect("~/Error/");
            }
        }

        [HttpPost]
        public ContentResult DeleteDataAjax(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    using (db_AdminErickEntities db = new db_AdminErickEntities())
                    {
                        Users _entry = db.Users.Find(Id);
                        db.Users.Remove(_entry);
                        db.SaveChanges();
                    }
                    return Content("Success");
                }
                return Content("Data not found");
            }
            catch (Exception e)
            {
                return Content("Error!");
            }
        }
        #endregion


        #region Othes Methods
        private List<RolesEdit> GetRoles()
        {
            using (Models.DataAccess.db_AdminErickEntities db = new Models.DataAccess.db_AdminErickEntities())
            {
                return (from roles in db.Roles
                        select new RolesEdit
                        {
                            Id = roles.Id,
                            RoleName = roles.RoleName
                        }).ToList();
            }
        }
        private List<MembershipEdit> GetMemberships()
        {
            using (Models.DataAccess.db_AdminErickEntities db = new Models.DataAccess.db_AdminErickEntities())
            {
                return (from member in db.Memberships
                        select new MembershipEdit
                        {
                            Id = member.Id,
                            MembershipName = member.MembershipName
                        }).ToList();
            }
        }

        public ActionResult Success()
        {
            return View();
        }
        #endregion


    }
}