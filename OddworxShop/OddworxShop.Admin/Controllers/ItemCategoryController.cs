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
    [Authorize]
    public class ItemCategoryController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ItemCategory
        public ActionResult Index()
        {
            return View(db.ItemCategories.ToList());
        }

        // GET: ItemCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemCategory = db.ItemCategories.Find(id);
            if (itemCategory == null)
            {
                return HttpNotFound();
            }
            return View(itemCategory);
        }

        // GET: ItemCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Parent")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                itemCategory.CreatedAt = DateTime.Now;
                itemCategory.CreatedBy = 0;
                itemCategory.LastModifiedAt = DateTime.Now;
                itemCategory.LastModifiedBy = 0;
                itemCategory.IsActive = true;
                

                db.ItemCategories.Add(itemCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemCategory);
        }

        // GET: ItemCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemCategory = db.ItemCategories.Find(id);
            if (itemCategory == null)
            {
                return HttpNotFound();
            }
            return View(itemCategory);
        }

        // POST: ItemCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Parent")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemCategory);
        }

        // GET: ItemCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemCategory = db.ItemCategories.Find(id);
            if (itemCategory == null)
            {
                return HttpNotFound();
            }
            return View(itemCategory);
        }

        // POST: ItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemCategory itemCategory = db.ItemCategories.Find(id);
            db.ItemCategories.Remove(itemCategory);
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
