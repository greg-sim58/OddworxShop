using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OddworxShop.Data.DAL;
using OddworxShop.Data.Models;
using OddworxShop.Admin.ViewModels;


namespace OddworxShop.Admin.Controllers
{
    [Authorize]
    public class ShopsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Shops
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Shops.ToList());
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            ShopsViewModel model = new ShopsViewModel();

            return View(model);
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ContactEmail,ContactPhone,WebSite,CreatedAt,CreatedBy,LastModifiedAt,LastModifiedBy,IsActive")] ShopsViewModel model)
        {
            if (ModelState.IsValid)
            {

                Shop shop = new Shop();
                shop.CreatedAt = DateTime.Now;
                shop.CreatedBy = 0;
                shop.LastModifiedAt = DateTime.Now;
                shop.LastModifiedBy = 0;
                shop.IsActive = true;
                shop.ContactEmail = model.ContactEmail;
                shop.ContactPhone = model.ContactPhone;
                shop.Description = model.Description;
                shop.Name = model.Name;
                shop.WebSite = model.WebSite;

                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ContactEmail,ContactPhone,WebSite,CreatedAt,CreatedBy,LastModifiedAt,LastModifiedBy,IsActive")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                shop.LastModifiedAt = DateTime.Now;
                shop.LastModifiedBy = 0;
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
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
