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
    public class SizesController : BaseController
    {
        private BlanketShopDbContext db = new BlanketShopDbContext();

        // GET: Admin/Sizes
        public ActionResult Index()
        {
            return View(db.Sizes.ToList());
        }

        // GET: Admin/Sizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sizes sizes = db.Sizes.Find(id);
            if (sizes == null)
            {
                return HttpNotFound();
            }
            return View(sizes);
        }

        // GET: Admin/Sizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Size_id,Size_name")] Sizes sizes)
        {
            if (ModelState.IsValid)
            {
                db.Sizes.Add(sizes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sizes);
        }

        // GET: Admin/Sizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sizes sizes = db.Sizes.Find(id);
            if (sizes == null)
            {
                return HttpNotFound();
            }
            return View(sizes);
        }

        // POST: Admin/Sizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Size_id,Size_name")] Sizes sizes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sizes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sizes);
        }

        // GET: Admin/Sizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sizes sizes = db.Sizes.Find(id);
            if (sizes == null)
            {
                return HttpNotFound();
            }
            return View(sizes);
        }

        // POST: Admin/Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sizes sizes = db.Sizes.Find(id);
            db.Sizes.Remove(sizes);
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
