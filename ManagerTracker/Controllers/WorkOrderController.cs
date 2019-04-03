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
            foreach (WorkOrders workorder in workOrders)
            {
                workorder.Trucks = db.Trucks.Where(p => p.Id == workorder.TrucksId).Single();
                workorder.Trailers = db.Trailers.Where(s => s.Id == workorder.TrailersId).Single();
                workorder.Mechanics = db.Mechanics.Where(m => m.Id == workorder.MechanicsId).Single();
            }
            return View(workOrders);
        }

        // GET: WorkOrder/Details/5
        public ActionResult Details(WorkOrders workOrders, int MechanicsId, string TrucksId, string TrailersId)
        {


           

            return View();
            //return View(db.WorkOrders.Find(id));
        }

        // GET: WorkOrder/Create
        public ActionResult Create()
        {
            ViewBag.MechanicsId = new SelectList(db.Mechanics.Select(m => m.Id));
            ViewBag.TrucksId = new SelectList(db.Trucks.Select(t=> t.Number));
            ViewBag.TrailersId = new SelectList(db.Trailers.Select(r=> r.Number));
            return View();
        }

        // POST: WorkOrder/Create
        [HttpPost]
        public ActionResult Create(WorkOrders workOrders, int MechanicsId, string TrucksId, string TrailersId)
        {
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
            ViewBag.MechanicsId = new SelectList(db.Mechanics.Select(m => m.Id));
            ViewBag.TrucksId = new SelectList(db.Trucks.Select(t => t.Number));
            ViewBag.TrailersId = new SelectList(db.Trailers.Select(r => r.Number));
            return View();
        }

        // POST: WorkOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int MechanicsId, string TrucksId, string TrailersId, [Bind(Include = "Id,Date,StartTime,EndTime,PartQuantity,PartPrice,PartNumberOrDescription,RepairDescription,MechanicsId,TrucksId,TrailersId")]WorkOrders @workOrders)
        {
            workOrders.TrucksId = db.Trucks.Where(t => t.Number == TrucksId).Single().Id;
            workOrders.TrailersId = db.Trailers.Where(r => r.Number == TrailersId).Single().Id;
            workOrders.MechanicsId = MechanicsId;
            if (true)
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
