using ManagerTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ManagerTracker.Controllers
{
    public class WorkOrderController : Controller
    {
        ApplicationDbContext db;
        public WorkOrderController()
        {
            db = new ApplicationDbContext();
        }
        // GET: WorkOrder
        public ActionResult Index()
        {
            var workOrders = db.WorkOrders.ToList();
            foreach(WorkOrders poop in workOrders)
            {
                poop.Trucks = db.Trucks.Where(p => p.Id == poop.TrucksId).Single();
                poop.Trailers = db.Trailers.Where(s => s.Id == poop.TrailersId).Single();
                poop.Mechanics = db.Mechanics.Where(m => m.Id == poop.MechanicsId).Single();
            }
            
            return View(workOrders);
        }

        // GET: WorkOrder/Details/5
        public ActionResult Details(int id)
        {
            return View(db.WorkOrders.Find(id));
        }

        // GET: WorkOrder/Create
        public ActionResult Create()
        {
            //ViewBag.MechanicsId = new SelectList(db.Mechanics.SelectMany(s => s.FirstName));
            //ViewBag.TrucksId = new SelectList(db.Trucks.SelectMany(t => t.Number));
            //ViewBag.TrailersId = new SelectList(db.Trailers.SelectMany(r => r.Number));
            //string userId = User.Identity.GetUserId();
            //var user = db.Mechanics.Where(m => m.ApplicationUserId == userId).Single();
            ViewBag.MechanicsId = new SelectList(db.Mechanics.Select(m => m.Id));
            ViewBag.TrucksId = new SelectList(db.Trucks.Select(t=> t.Number));
            ViewBag.TrailersId = new SelectList(db.Trailers.Select(r=> r.Number));
            return View();
        }

        // POST: WorkOrder/Create
        [HttpPost]
        public ActionResult Create(WorkOrders workOrders, int MechanicsId, string TrucksId, string TrailersId)
        {

            //db.WorkOrders.Add(workOrders);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            try
            {
                //workOrders.TrucksId = db.Trucks.Where(t => t.Id == TrucksId).
                workOrders.TrucksId = db.Trucks.Where(t => t.Number == TrucksId).Single().Id;
                workOrders.TrailersId = db.Trailers.Where(r => r.Number == TrailersId).Single().Id;
                workOrders.MechanicsId = MechanicsId;
                if (true)
                {
                    db.WorkOrders.Add(workOrders);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                else
                {
                    foreach (var obj in ModelState.Values)
                    {
                        foreach (var error in obj.Errors)
                        {
                            if (!string.IsNullOrEmpty(error.ErrorMessage))
                                System.Diagnostics.Debug.WriteLine("ERROR WHY = " + error.ErrorMessage);
                        }
                    }
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: WorkOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrders @workOrders = db.WorkOrders.Find(id);
            if (@workOrders == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: WorkOrder/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Date,StartTime,EndTime,PartQuantity,PartPrice,PartNumberOrDescription,RepairDescription,MechanicsId,TrucksId,TrailersId")]WorkOrders @workOrders)
        {
           if (ModelState.IsValid)
            {
                db.Entry(@workOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: WorkOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.WorkOrders.Find(id));
        }

        // POST: WorkOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.WorkOrders.Remove(db.WorkOrders.Find(id));
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
