using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using PagedList;

namespace BlanketShop.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private BlanketShopDbContext db = new BlanketShopDbContext();

        // GET: Admin/Products
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var products = db.Products.Include(p => p.Categories).Include(p => p.Colors).Include(p => p.Contries).Include(p => p.Materials).Include(p => p.Sizes);
            ViewBag.SearchString = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.Name.Contains(searchString));
            }
            return View(products.OrderByDescending(x => x.ID).ToPagedList(page, pageSize));

            //var products = db.Products.Include(p => p.Categories).Include(p => p.Colors).Include(p => p.Contries).Include(p => p.Materials).Include(p => p.Sizes).Where(m => m.Name.Contains(searchString)).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
           
            //var cate = products.FirstOrDefault().Categories.Name;

        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Category_id = new SelectList(db.Categories, "ID", "Name");
            ViewBag.Color_id = new SelectList(db.Colors, "Color_id", "Color_name");
            ViewBag.Contry_id = new SelectList(db.Contries, "Country_id", "Country_name");
            ViewBag.Material_id = new SelectList(db.Materials, "Material_id", "Material_name");
            ViewBag.Size_id = new SelectList(db.Sizes, "Size_id", "Size_name");

            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category_id,Size_id,Color_id,Contry_id,Material_id,Name,MetaTitle,CreatedDate,Quantity,Price,Image,Warranty,Description,TopHot,Status")] Products products)
        {
            if (ModelState.IsValid)
            {
                products.CreatedDate = DateTime.Now;
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_id = new SelectList(db.Categories, "ID", "Name", products.Category_id);
            ViewBag.Color_id = new SelectList(db.Colors, "Color_id", "Color_name", products.Color_id);
            ViewBag.Contry_id = new SelectList(db.Contries, "Country_id", "Country_name", products.Contry_id);
            ViewBag.Material_id = new SelectList(db.Materials, "Material_id", "Material_name", products.Material_id);
            ViewBag.Size_id = new SelectList(db.Sizes, "Size_id", "Size_name", products.Size_id);
            return View(products);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_id = new SelectList(db.Categories, "ID", "Name", products.Category_id);
            ViewBag.Color_id = new SelectList(db.Colors, "Color_id", "Color_name", products.Color_id);
            ViewBag.Contry_id = new SelectList(db.Contries, "Country_id", "Country_name", products.Contry_id);
            ViewBag.Material_id = new SelectList(db.Materials, "Material_id", "Material_name", products.Material_id);
            ViewBag.Size_id = new SelectList(db.Sizes, "Size_id", "Size_name", products.Size_id);
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category_id,Size_id,Color_id,Contry_id,Material_id,Name,MetaTitle,CreatedDate,Quantity,Price,Image,Warranty,Description,TopHot,Status")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_id = new SelectList(db.Categories, "ID", "Name", products.Category_id);
            ViewBag.Color_id = new SelectList(db.Colors, "Color_id", "Color_name", products.Color_id);
            ViewBag.Contry_id = new SelectList(db.Contries, "Country_id", "Country_name", products.Contry_id);
            ViewBag.Material_id = new SelectList(db.Materials, "Material_id", "Material_name", products.Material_id);
            ViewBag.Size_id = new SelectList(db.Sizes, "Size_id", "Size_name", products.Size_id);
            return View(products);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
