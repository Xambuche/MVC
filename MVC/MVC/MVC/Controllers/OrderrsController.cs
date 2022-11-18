using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class OrderrsController : Controller
    {
        private DevConn db = new DevConn();

        // GET: Orderrs
        public ActionResult Index()
        {
            return View(db.Orderrs.ToList());
        }

        // GET: Orderrs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderr orderr = db.Orderrs.Find(id);
            if (orderr == null)
            {
                return HttpNotFound();
            }
            return View(orderr);
        }

        // GET: Orderrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orderrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OderDate,AgentID")] Orderr orderr)
        {
            if (ModelState.IsValid)
            {
                db.Orderrs.Add(orderr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderr);
        }

        // GET: Orderrs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderr orderr = db.Orderrs.Find(id);
            if (orderr == null)
            {
                return HttpNotFound();
            }
            return View(orderr);
        }

        // POST: Orderrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OderDate,AgentID")] Orderr orderr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderr);
        }

        // GET: Orderrs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderr orderr = db.Orderrs.Find(id);
            if (orderr == null)
            {
                return HttpNotFound();
            }
            return View(orderr);
        }

        // POST: Orderrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Orderr orderr = db.Orderrs.Find(id);
            db.Orderrs.Remove(orderr);
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
