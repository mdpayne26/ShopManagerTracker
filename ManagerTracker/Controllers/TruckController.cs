using ManagerTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerTracker.Controllers
{
    public class TruckController : Controller
    {
        ApplicationDbContext db;
        public TruckController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Truck
        public ActionResult Index()
        {
            return View();
        }

        // GET: Truck/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Trucks.Find(id));
        }

        // GET: Truck/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Trucks, "Id", "TruckNumber");
            return View();
        }

        // POST: Truck/Create
        [HttpPost]
        public ActionResult Create(Trucks trucks)
        {
            try
            {
                // TODO: Add insert logic here
                db.Trucks.Add(trucks);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Truck/Edit/5
        public ActionResult Edit(int id)
        {
            List<Trucks> ListofTrucks = db.Trucks.ToList();
            return View();
        }

        // POST: Truck/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,Trucks trucks)
        {
            try
            {
                // TODO: Add update logic here
                Trucks thisTrucks = db.Trucks.Find(id);
                thisTrucks.TruckNumber = trucks.TruckNumber;
                thisTrucks.Year = trucks.Year;
                thisTrucks.Make = trucks.Make;
                thisTrucks.Model = trucks.Model;
                thisTrucks.Vin = trucks.Vin;
                thisTrucks.EngineSerialNumber = trucks.EngineSerialNumber;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Truck/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Trucks.Find(id));
        }

        // POST: Truck/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Trucks.Remove(db.Trucks.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
