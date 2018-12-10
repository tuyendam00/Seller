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
    public class ColorsController : BaseController
    {
        private BlanketShopDbContext db = new BlanketShopDbContext();

        // GET: Admin/Colors
        public ActionResult Index()
        {
            return View(db.Colors.ToList());
        }

        // GET: Admin/Colors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colors colors = db.Colors.Find(id);
            if (colors == null)
            {
                return HttpNotFound();
            }
            return View(colors);
        }

        // GET: Admin/Colors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Colors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Color_id,Color_name")] Colors colors)
        {
            if (ModelState.IsValid)
            {
                db.Colors.Add(colors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colors);
        }

        // GET: Admin/Colors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colors colors = db.Colors.Find(id);
            if (colors == null)
            {
                return HttpNotFound();
            }
            return View(colors);
        }

        // POST: Admin/Colors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Color_id,Color_name")] Colors colors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colors);
        }

        // GET: Admin/Colors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colors colors = db.Colors.Find(id);
            if (colors == null)
            {
                return HttpNotFound();
            }
            return View(colors);
        }

        // POST: Admin/Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colors colors = db.Colors.Find(id);
            db.Colors.Remove(colors);
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
