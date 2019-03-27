using ManagerTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.MechanicsId = new SelectList(db.Mechanics);
            ViewBag.TrucksId = new SelectList(db.Trucks);
            ViewBag.TrailersId = new SelectList(db.Trailers);
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
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkOrder/Edit/5
        public ActionResult Edit(int id)
        {
            List<WorkOrders> ListofWorkOrders = db.WorkOrders.ToList();
            return View();
        }

        // POST: WorkOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, WorkOrders workOrders)
        {
            try
            {
                // TODO: Add update logic here
                WorkOrders thisworkOrders = db.WorkOrders.Find(id);
                thisworkOrders.Date = workOrders.Date;
                thisworkOrders.StartTime = workOrders.StartTime;
                thisworkOrders.EndTime = workOrders.EndTime;
                thisworkOrders.PartNumberOrDescription = workOrders.PartNumberOrDescription;
                thisworkOrders.PartQuantity = workOrders.PartQuantity;
                thisworkOrders.PartPrice = workOrders.PartPrice;
                thisworkOrders.RepairDescription = workOrders.RepairDescription;
                thisworkOrders.MechanicsId = workOrders.MechanicsId;
                thisworkOrders.TrucksId = workOrders.TrucksId;
                thisworkOrders.TrailersId = workOrders.TrailersId;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
