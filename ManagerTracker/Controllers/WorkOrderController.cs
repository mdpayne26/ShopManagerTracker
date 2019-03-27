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
            var workOrders = db.WorkOrders;
            return View(workOrders.ToList());
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
            //ViewBag.TrucksId = new SelectList(db.Trucks.SelectMany(t => t.TruckNumber));
            //ViewBag.TrailersId = new SelectList(db.Trailers.SelectMany(r => r.TrailerNumber));
            ViewBag.MechanicsId = new SelectList(db.Mechanics.Select(m=> m.Id));
            //string userId = User.Identity.GetUserId();
            //var user = db.Mechanics.Where(m => m.ApplicationUserId == userId).Single();
            ViewBag.TrucksId = new SelectList(db.Trucks.Select(t=> t.TruckNumber));
            ViewBag.TrailersId = new SelectList(db.Trailers.Select(r=> r.TrailerNumber));
            //DateTime localdate = DateTime.Now;
           
                return View();
        }

        // POST: WorkOrder/Create
        [HttpPost]
        public ActionResult Create(WorkOrders workOrders)
        {
            try
            {
                db.WorkOrders.Add(workOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
