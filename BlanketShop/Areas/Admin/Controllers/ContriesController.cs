using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace BlanketShop.Areas.Admin.Controllers
{
    public class ContriesController : BaseController
    {
        private BlanketShopDbContext db = new BlanketShopDbContext();

        // GET: Admin/Contries
        public ActionResult Index()
        {
            return View(db.Contries.ToList());
        }

        // GET: Admin/Contries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contries contries = db.Contries.Find(id);
            if (contries == null)
            {
                return HttpNotFound();
            }
            return View(contries);
        }

        // GET: Admin/Contries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Country_id,Country_name")] Contries contries)
        {
            if (ModelState.IsValid)
            {
                db.Contries.Add(contries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contries);
        }

        // GET: Admin/Contries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contries contries = db.Contries.Find(id);
            if (contries == null)
            {
                return HttpNotFound();
            }
            return View(contries);
        }

        // POST: Admin/Contries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Country_id,Country_name")] Contries contries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contries);
        }

        // GET: Admin/Contries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contries contries = db.Contries.Find(id);
            if (contries == null)
            {
                return HttpNotFound();
            }
            return View(contries);
        }

        // POST: Admin/Contries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contries contries = db.Contries.Find(id);
            db.Contries.Remove(contries);
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
