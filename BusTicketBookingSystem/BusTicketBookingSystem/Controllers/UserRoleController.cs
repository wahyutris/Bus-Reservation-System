using BusTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTicketBookingSystem.Controllers
{
    public class UserRoleController : Controller
    {
        private OperationDataContext context = null;

        public UserRoleController()
        {
            context = new OperationDataContext();
        }

        // GET: UserRole
        public ActionResult Index()
        {
            // create the userRoleList variable
            List<UserRoleModel> userRoleList = new List<UserRoleModel>();

            // perform linq operation
            var query = from userRole in context.UserRoles
                        join role in context.Roles
                        on userRole.RoleID equals role.Id
                        select new UserRoleModel
                        {
                            Id = userRole.Id,
                            Username = userRole.Username,
                            Password = userRole.Password,
                            RoleName = role.Name,
                        };

            // store the query to list
            userRoleList = query.ToList();

            return View(userRoleList);
        }

        // GET: UserRole/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRole/Create
        public ActionResult Create()
        {
            UserRoleModel model = new UserRoleModel();
            PrepareRole(model);

            return View(model);
        }

        // POST: UserRole/Create
        [HttpPost]
        public ActionResult Create(UserRoleModel model)
        {
            try
            {
                // TODO: Add insert logic here
                UserRole userRole = new UserRole()
                {
                    Username = model.Username,
                    Password = model.Password,
                    RoleID = model.RoleID
                };

                context.UserRoles.InsertOnSubmit(userRole);
                context.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: UserRole/Edit/5
        public ActionResult Edit(int id)
        {
            UserRoleModel model = context.UserRoles.Where(some => some.Id == id).Select(
                some => new UserRoleModel()
                {
                    Id = some.Id,
                    Username = some.Username,
                    Password = some.Password,
                    RoleID = some.RoleID
                }).SingleOrDefault();

            PrepareRole(model);
            return View(model);
        }

        // POST: UserRole/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserRoleModel model)
        {
            try
            {
                // TODO: Add update logic here
                UserRole userRole = context.UserRoles.Where(some => some.Id == model.Id).Single<UserRole>();
                userRole.Username = model.Username;
                userRole.Password = model.Password;
                userRole.RoleID = model.RoleID;
                context.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRole/Delete/5
        public ActionResult Delete(int id)
        {
            UserRoleModel model = context.UserRoles.Where(some => some.Id == id).Select(
                some => new UserRoleModel()
                {
                    Id = some.Id,
                    Username = some.Username,
                    Password = some.Password,
                    RoleID = some.RoleID
                }).SingleOrDefault();

            PrepareRole(model);
            return View(model);
        }

        // POST: UserRole/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserRoleModel model)
        {
            try
            {
                // TODO: Add delete logic here
                UserRole userRole = context.UserRoles.Where(some => some.Id == model.Id).Single<UserRole>();

                context.UserRoles.DeleteOnSubmit(userRole);
                context.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void PrepareRole (UserRoleModel model)
        {
            model.Roles = context.Roles.AsQueryable<Role>().Select(x =>
                          new SelectListItem()
                          {
                            Text = x.Name,
                            Value = x.Id.ToString()
                          });
        }
    }
}
