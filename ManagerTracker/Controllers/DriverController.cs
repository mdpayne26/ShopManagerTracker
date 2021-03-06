﻿using ManagerTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerTracker.Controllers
{
    public class DriverController : Controller
    {
        
        ApplicationDbContext db;
        public DriverController()
        {
            db = new ApplicationDbContext();
           
        }

        // GET: Driver
        public ActionResult Index()
        {
            var drivers = db.Drivers;
            return View(drivers.ToList());
        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var driver = db.Drivers.Single(d => d.Id == id);
                return View(driver);
                //string userId = User.Identity.GetUserId();
                //var user = db.Drivers.Where(c => c.ApplicationUserId == userId).Single();
                //return View(user);
                //var mechanic = db.Mechanics.Single(m => m.Id == id);
                //return View(mechanic);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Drivers, "Id", "Name");
            return View();
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(Drivers drivers)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    drivers.ApplicationUserId = User.Identity.GetUserId();
                    db.Drivers.Add(drivers);
                    db.SaveChanges();
                }
                return RedirectToAction("DistanceCreate", "Driver");
            }
            catch
            {
                return View();
            }
        }
        
        //GET: Distance/Create
        public ActionResult DistanceCreate()
        {
            
            //ViewBag.Origin = 

            
                return View();
        }
       
        //POST: Distance/Create
        [HttpPost]
        public ActionResult DistanceCreate(int id)
        {
            return View();
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(Drivers drivers)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Drivers.Where(c => c.ApplicationUserId == userId).Single();
            try
            {
                // TODO: Add update logic here
                db.Entry(drivers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Drivers.Find(id));
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    Drivers drivers = db.Drivers.Find(id);
                    db.Drivers.Remove(drivers);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //GET: Driver/Confirmation
        //public ActionResult Confirmation()
        //{
        //    return View();
        //}

        //POST: Driver/Confirmation
        [HttpPost]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
