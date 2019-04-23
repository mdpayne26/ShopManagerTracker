using ManagerTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerTracker.Controllers
{
    public class ManagerController : Controller
    {
        ApplicationDbContext db;
        public ManagerController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                var user = db.Manager.Where(m => m.ApplicationUserId == userId).Single();
                return View(user);
                //return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Manager, "Id", "Name");
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        public ActionResult Create(Manager manager)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.ApplicationUserId = User.Identity.GetUserId();
                    db.Manager.Add(manager);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
        [HttpPost]
        public ActionResult Edit(Manager manager)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Manager.Where(c => c.ApplicationUserId == userId).Single();
            try
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manager manager = db.Manager.Find(id);
                    db.Manager.Remove(manager);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MANAGER WORKORDER CHARTS
        public ActionResult TruckCharts()
        {
            return View();
        }

        // POST: MANAGER WORKORDER CHARTS
        [HttpPost]
        public ActionResult TruckCharts(int id)
        {
            return View();
        }

        // GET: MANAGER WORKORDER CHARTS
        public ActionResult TrailerCharts()
        {
            return View();
        }

        // POST: MANAGER WORKORDER CHARTS
        [HttpPost]
        public ActionResult TrailerCharts(int id)
        {
            return View();
        }
    }
}
