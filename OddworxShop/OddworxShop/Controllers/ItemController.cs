﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OddworxShop.Data.DAL;
using OddworxShop.Data.Models;
using OddworxShop.ViewModels;

namespace OddworxShop.Controllers
{
    public class ItemController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Item
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        public ActionResult ViewItemsByShop(int shopId)
        {

            ShopItemViewModel model = new ShopItemViewModel();
            using (DataContext dbx =  new DataContext())
            {
                model = new ShopItemViewModel
                {
                    Items = db.Items.Where(i => i.Shop.Id == shopId).ToList(),
                    ShopId = shopId,
                    ShopName = db.Shops.Where(s => s.Id == shopId).FirstOrDefault().Name
                };

            }

            return View(model);
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create(int shopId)
        {
            CreateItemViewModel model = new CreateItemViewModel();
            using (DataContext ctx = new DataContext())
            {
                model.Shop = ctx.Shops.Find(shopId);
            }
            return View(model);
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price, Shop")] CreateItemViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                Item item = new Item();

                using (DataContext ctx = new DataContext())
                {
                    item.Name = model.Name;
                    item.Price = model.Price;
                    item.Description = model.Description;
                    item.Shop = ctx.Shops.Find(model.Shop.Id);

                    item.CreatedAt = DateTime.Now;
                    item.CreatedBy = 0;
                    item.LastModifiedAt = DateTime.Now;
                    item.LastModifiedBy = 0;
                    item.IsActive = true;

                    ctx.Items.Add(item);
                    ctx.SaveChanges();
                    return RedirectToAction("ViewItemsByShop", new { shopId = model.Shop.Id });
                }
            }

            return View(model);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,CreatedAt,CreatedBy,LastModifiedAt,LastModifiedBy,IsActive")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewItemsByShop", new { shopId = item.Shop.Id } );
            }
            return View(item);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
