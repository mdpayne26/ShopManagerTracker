using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerTracker.Models
{
    public class MechanicController : Controller
    {
        ApplicationDbContext db;
        public MechanicController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Mechanic
        public ActionResult Index()
        {
            var mechanics = db.Mechanics;
            return View(mechanics.ToList());
        }

        // GET: Mechanic/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                var user = db.Mechanics.Where(c => c.ApplicationUserId == userId).Single();
                return View(user);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Mechanic/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Mechanics, "Id", "Name");
            return View();
        }

        // POST: Mechanic/Create
        [HttpPost]
        public ActionResult Create(Mechanics mechanics)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mechanics.ApplicationUserId = User.Identity.GetUserId();
                    db.Mechanics.Add(mechanics);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Mechanic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mechanic/Edit/5
        [HttpPost]
        public ActionResult Edit(Mechanics mechanics)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Mechanics.Where(c => c.ApplicationUserId == userId).Single();
            try
            {
                // TODO: Add update logic here
                db.Entry(mechanics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Mechanic/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Mechanics.Find(id));
        }

        // POST: Mechanic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    Mechanics person = db.Mechanics.Find(id);
                    db.Mechanics.Remove(person);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
