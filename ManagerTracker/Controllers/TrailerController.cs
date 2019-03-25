using ManagerTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerTracker.Controllers
{
    public class TrailerController : Controller
    {
        ApplicationDbContext db;
        public TrailerController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Trailer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trailer/Details/5
        public ActionResult Details(int id)
        {


            return View(db.Trailers.Find(id));
           
        }

        // GET: Trailer/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Trailers, "Id", "TrailerNumber");
            return View();
        }

        // POST: Trailer/Create
        [HttpPost]
        public ActionResult Create(Trailers trailers)
        {
            try
            {
                db.Trailers.Add(trailers);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trailer/Edit/5
        public ActionResult Edit(int id)
        {
            List<Trailers> ListofTrailers = db.Trailers.ToList();
            return View();
        }

        // POST: Trailer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Trailers trailers)
        {
            try
            {
                // TODO: Add update logic here
                Trailers thistrailers = db.Trailers.Find(id);
                thistrailers.TrailerNumber = trailers.TrailerNumber;
                thistrailers.Year = trailers.Year;
                thistrailers.Make = trailers.Make;
                thistrailers.Model = trailers.Model;
                thistrailers.Vin = trailers.Vin;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trailer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Trailers.Find(id));
        }

        // POST: Trailer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Trailers.Remove(db.Trailers.Find(id));
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
