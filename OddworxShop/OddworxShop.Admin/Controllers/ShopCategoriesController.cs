using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OddworxShop.Data.DAL;
using OddworxShop.Data.Models;

namespace OddworxShop.Admin.Controllers
{
    public class ShopCategoriesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ShopCategory
        public ActionResult Index()
        {
            return View(db.ShopCategories.ToList());
        }

        // GET: ShopCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopCategory shopCategory = db.ShopCategories.Find(id);
            if (shopCategory == null)
            {
                return HttpNotFound();
            }
            return View(shopCategory);
        }

        // GET: ShopCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreatedAt,CreatedBy,LastModifiedAt,LastModifiedBy,IsActive")] ShopCategory shopCategory)
        {
            if (ModelState.IsValid)
            {
                shopCategory.CreatedAt = DateTime.Now;
                shopCategory.CreatedBy = 0;
                shopCategory.LastModifiedAt = DateTime.Now;
                shopCategory.LastModifiedBy = 0;
                shopCategory.IsActive = true;

                db.ShopCategories.Add(shopCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopCategory);
        }

        // GET: ShopCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopCategory shopCategory = db.ShopCategories.Find(id);
            if (shopCategory == null)
            {
                return HttpNotFound();
            }
            return View(shopCategory);
        }

        // POST: ShopCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedAt,CreatedBy,LastModifiedAt,LastModifiedBy,IsActive")] ShopCategory shopCategory)
        {
            if (ModelState.IsValid)
            {
                shopCategory.LastModifiedAt = DateTime.Now;
                shopCategory.LastModifiedBy = 0;

                db.Entry(shopCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopCategory);
        }

        // GET: ShopCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopCategory shopCategory = db.ShopCategories.Find(id);
            if (shopCategory == null)
            {
                return HttpNotFound();
            }
            return View(shopCategory);
        }

        // POST: ShopCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopCategory shopCategory = db.ShopCategories.Find(id);
            db.ShopCategories.Remove(shopCategory);
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
