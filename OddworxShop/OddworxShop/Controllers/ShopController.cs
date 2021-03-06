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
    public class ShopController : Controller
    {
        private DataContext db = new DataContext();

        // Add shop
        public ActionResult OpenShop()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View("Register", "Account");
            }
        }

        #region PRIVATE


        #endregion


        public ActionResult UserShops()
        {
            using (DataContext ctx = new DataContext())
            {
                var userId = ctx.Users.Where(u => u.EMail == User.Identity.Name).FirstOrDefault().Id;
                var shops = ctx.Shops.Where(s => s.AdminUser.Id == userId).ToList();

                return View("UserShops", shops);
            }
        }

        public ActionResult ViewShopItems(int id)
        {
            ShopItemViewModel model = new ShopItemViewModel();

            return RedirectToAction("ViewItemsByShop", "Item", new { shopId = id });
        }

        // GET: Shop
        public ActionResult Index()
        {
            return View(db.Shops.ToList());
        }

        // GET: Shop/Details/5
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

        // GET: Shop/Create
        public ActionResult Create()
        {
            CreateShopViewModel model = new CreateShopViewModel();
            //model.AdminUser = User.Identity


            return View("Create", model);
        }

        // POST: Shop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ContactEmail,ContactPhone,WebSite")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                shop.CreatedAt = DateTime.Now;
                shop.CreatedBy = 0;
                shop.LastModifiedAt = DateTime.Now;
                shop.LastModifiedBy = 0;
                shop.IsActive = true;
                shop.AdminUser = db.Users.Where(u => u.EMail == User.Identity.Name).FirstOrDefault(); ;

                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("UserShops");
            }

            return View(shop);
        }

        private User GetUser(string name)
        {
            using (DataContext ctx = new DataContext())
            {
                var user = ctx.Users.Where(u => u.EMail == User.Identity.Name).FirstOrDefault();
                return user;
            }
        }

        // GET: Shop/Edit/5
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

        // POST: Shop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ContactEmail,ContactPhone,WebSite,CreatedAt,CreatedBy,LastModifiedAt,LastModifiedBy,IsActive")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Shop/Delete/5
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

        // POST: Shop/Delete/5
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
