using BusTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTicketBookingSystem.Controllers
{
    public class RoleController : Controller
    {
        private OperationDataContext context = null;

        public RoleController()
        {
            context = new OperationDataContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            // create the roleList variable
            List<RoleModel> roleList = new List<RoleModel>();

            // perform linq operation
            var query = from role in context.Roles select role;

            // store the query to list
            var roles = query.ToList();

            // looping through all items in roles
            foreach (var roleItem in roles)
            {
                roleList.Add(new RoleModel()
                {
                    Id = roleItem.Id,
                    Name = roleItem.Name
                });
            }

            return View(roleList);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
