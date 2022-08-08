﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCOrnek.Models;

namespace MVCOrnek.Content
{
    public class CarController : Controller
    {
        private supercarEntities db = new supercarEntities();

        // GET: Car
        public ActionResult Index()
        {
            return View(db.carreg.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carreg carreg = db.carreg.Find(id);
            if (carreg == null)
            {
                return HttpNotFound();
            }
            return View(carreg);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,carno,make,model,available")] carreg carreg)
        {
            if (ModelState.IsValid)
            {
                db.carreg.Add(carreg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carreg);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carreg carreg = db.carreg.Find(id);
            if (carreg == null)
            {
                return HttpNotFound();
            }
            return View(carreg);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,carno,make,model,available")] carreg carreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carreg);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carreg carreg = db.carreg.Find(id);
            if (carreg == null)
            {
                return HttpNotFound();
            }
            return View(carreg);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carreg carreg = db.carreg.Find(id);
            db.carreg.Remove(carreg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
