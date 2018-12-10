using Model.EF;
using PusherServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlanketShop.Controllers
{
    public class ReviewController : Controller
    {
        private BlanketShopDbContext db = new BlanketShopDbContext();

        // GET: Admin/Reviews
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create( Products product)
        {
          
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(db.Products.Find(id));
        }

        public ActionResult Comments(long id)
        {
            var comments = db.Review.Where(x => x.Product_id == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Review data)
        {
            db.Review.Add(data);
            db.SaveChanges();
            var options = new PusherOptions();
            options.Cluster = "ap1";
            var pusher = new Pusher(
      "517985",
      "d6da99d6e03f6878b567",
      "eaa3506a81d07a10b73c",
      options);
            ITriggerResult result = await pusher.TriggerAsync(
      "my-channel",
      "my-event", data);
            return Content("ok");

        }
    }
}