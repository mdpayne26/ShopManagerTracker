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
        public ActionResult Index(string searchBy, string search, string FirstName)
        {
            var workOrders = db.WorkOrders.ToList();
            foreach (WorkOrders workorder in workOrders)
            {
                //{
                workorder.Trucks = db.Trucks.Where(p => p.Id == workorder.TrucksId).Single();
                workorder.Trailers = db.Trailers.Where(s => s.Id == workorder.TrailersId).Single();
                workorder.Mechanics = db.Mechanics.Where(m => m.Id == workorder.MechanicsId).Single();
                //}
                if (searchBy == "FirstName")
                {
                    var workOrder = db.WorkOrders.Where(m => m.Mechanics.FirstName == search).ToList();
                    foreach (WorkOrders order in workOrder)
                    {
                        order.Trucks = db.Trucks.Where(t => t.Id == order.TrucksId).Select(t => t).Single();
                        order.Trailers = db.Trailers.Where(r => r.Id == order.TrailersId).Select(r => r).Single();
                        order.Mechanics = db.Mechanics.Where(m => m.Id == order.MechanicsId).Select(m => m).Single();
                    }
                        return View(workOrder);
                }
                if (searchBy == "TruckNumber")
                {
                    var workOrder = db.WorkOrders.Where(p => p.Trucks.Number == search).ToList();
                    foreach (WorkOrders order in workOrder)
                    {
                        order.Mechanics = db.Mechanics.Where(m => m.Id == order.MechanicsId).Select(m => m).Single();
                        order.Trucks = db.Trucks.Where(t => t.Id == order.TrucksId).Select(t => t).Single();
                        order.Trailers = db.Trailers.Where(r => r.Id == order.TrailersId).Select(r => r).Single();
                    }

                    return View(workOrder);
                }
                if (searchBy == "TrailerNumber")
                {
                    var workOrder = db.WorkOrders.Where(s => s.Trailers.Number == search).ToList();
                    foreach (WorkOrders order in workOrder)
                    {
                        order.Mechanics = db.Mechanics.Where(m => m.Id == order.MechanicsId).Select(m => m).Single();
                        order.Trailers = db.Trailers.Where(r => r.Id == order.TrailersId).Select(r => r).Single();
                        order.Trucks = db.Trucks.Where(t => t.Id == order.TrucksId).Select(t => t).Single();
                    }
                        return View(workOrder);
                }
            }
            return View(workOrders);
        }

        // GET: WorkOrder/Details/5
        public ActionResult Details(int id, int? MechanicsId, string TrucksId, string TrailersId, WorkOrders workOrder)
        {
            try
            {
                //var mechanic = db.Mechanics.Single(m => m.Id == id);
                //
                //ViewBag.MechanicsId = new SelectList(db.Mechanics.ToList(), "Id", "FirstName");
                //ViewBag.TrucksId = new SelectList(db.Trucks.Select(t => t.Number));
                //ViewBag.TrailersId = new SelectList(db.Trailers.Select(r => r.Number));
                //ViewBag.MechanicsId = new SelectList(db.Mechanics.Select(m => m.FirstName));
                //ViewBag.Mechanics = db.Mechanics.Where(m => m.Id).Select(m => m.FirstName);

                //workOrders.TrucksId = db.Trucks.Where(t => t.Number == TrucksId).Single().Id;
                //workOrders.TrailersId = db.Trailers.Where(r => r.Number == TrailersId).Single().Id;
                //workOrders.MechanicsId = db.Mechanics.Where(m => m.FirstName == FirstName).Single().Id;

                workOrder.Trucks = db.Trucks.Where(p => p.Id == workOrder.TrucksId).Single();
                workOrder.Trailers = db.Trailers.Where(s => s.Id == workOrder.TrailersId).Single();
                workOrder.Mechanics = db.Mechanics.Where(m => m.Id == workOrder.MechanicsId).Single();

                return View(db.WorkOrders.Find(id));
                //var workOrder = db.WorkOrders.Single(w => w.Id == id);
                //return View(workOrder);
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
        }

        // GET: WorkOrder/Create
        public ActionResult Create()
        {
            ViewBag.MechanicsId = new SelectList(db.Mechanics.Select(m => m.FirstName));
            // ViewBag.MechanicsId = new SelectList(db.Mechanics.ToList(), "Id", "FirstName");
            ViewBag.TrucksId = new SelectList(db.Trucks.Select(t=> t.Number));
            ViewBag.TrailersId = new SelectList(db.Trailers.Select(r=> r.Number));
            return View();
        }

        // POST: WorkOrder/Create
        [HttpPost]
        public ActionResult Create(WorkOrders workOrders, int MechanicsId, string TrucksId, string TrailersId, string FirstName)
        {
            workOrders.TrucksId = db.Trucks.Where(t => t.Number == TrucksId).Single().Id;
            workOrders.TrailersId = db.Trailers.Where(r => r.Number == TrailersId).Single().Id;
            //workOrders.MechanicsId = MechanicsId;
            workOrders.MechanicsId = db.Mechanics.Where(m => m.FirstName == FirstName).Single().Id;
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
            ViewBag.MechanicsId = new SelectList(db.Mechanics.Select(m => m.FirstName));
            ViewBag.TrucksId = new SelectList(db.Trucks.Select(t => t.Number));
            ViewBag.TrailersId = new SelectList(db.Trailers.Select(r => r.Number));
            return View();
        }

        // POST: WorkOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int MechanicsId, string TrucksId, string TrailersId, string FirstName, [Bind(Include = "Id,Date,StartTime,EndTime,PartQuantity,PartPrice,PartNumberOrDescription,RepairDescription,MechanicsId,TrucksId,TrailersId")]WorkOrders @workOrders)
        {
            workOrders.TrucksId = db.Trucks.Where(t => t.Number == TrucksId).Single().Id;
            workOrders.TrailersId = db.Trailers.Where(r => r.Number == TrailersId).Single().Id;
            workOrders.MechanicsId = db.Mechanics.Where(m => m.FirstName == FirstName).Single().Id;
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

        public ActionResult Search(string searching, Mechanics mechanics)
        {
            //var workOrders = db.WorkOrders.ToList();
            //foreach (WorkOrders workorder in workOrders)
            //{
            //    workorder.Trucks = db.Trucks.Where(p => p.Id == workorder.TrucksId).Single();
            //    workorder.Trailers = db.Trailers.Where(s => s.Id == workorder.TrailersId).Single();
            //    workorder.Mechanics = db.Mechanics.Where(m => m.Id == workorder.MechanicsId).Single();
            //}
            //return View(workOrders);
            //return View(db.WorkOrders.Where(x => x.MechanicsId.Contains(searching) || searching == null).ToList());
            //ViewBag.MechanicsId = from m in db.WorkOrders
            //var mechanics = from m in db.WorkOrders
            //                select m;
            //if (!String.IsNullOrEmpty(searching))
            //{
            //    //ViewBag.MechanicsId = mechanics.Where(db.Mechanics.Select(m => m.FirstName)).Contains(searching);
            //    mechanics = db.Mechanics.Where(m => m.FirstName.Contains(searching));
            //}


            return View();
        }

        [HttpPost]
        public ActionResult Search(WorkOrders workOrders,int MechanicsId, string TrucksId, string TrailersId, string FirstName)
        {
            ////workOrders.TrucksId = db.Trucks.Where(t => t.Number == TrucksId).Single().Id;
            ////workOrders.TrailersId = db.Trailers.Where(r => r.Number == TrailersId).Single().Id;
            ////workOrders.MechanicsId = db.Mechanics.Where(m => m.FirstName == FirstName).Single().Id;
            //db.WorkOrders.Find(TrucksId);
            //db.WorkOrders.Find(FirstName);
            //db.WorkOrders.Find(TrailersId);
            //return View();
            return View();
        }
    }
}
