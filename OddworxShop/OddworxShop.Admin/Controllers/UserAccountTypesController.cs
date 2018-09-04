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
    public class UserAccountTypesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: UserAccountType
        public ActionResult Index()
        {
            return View(db.UserAccountTypes.ToList());
        }

        // GET: UserAccountType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccountType userAccountType = db.UserAccountTypes.Find(id);
            if (userAccountType == null)
            {
                return HttpNotFound();
            }
            return View(userAccountType);
        }

        // GET: UserAccountType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccountType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PaymentFrequency")] UserAccountType userAccountType)
        {
            if (ModelState.IsValid)
            {
                db.UserAccountTypes.Add(userAccountType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccountType);
        }

        // GET: UserAccountType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccountType userAccountType = db.UserAccountTypes.Find(id);
            if (userAccountType == null)
            {
                return HttpNotFound();
            }
            return View(userAccountType);
        }

        // POST: UserAccountType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PaymentFrequency")] UserAccountType userAccountType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccountType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccountType);
        }

        // GET: UserAccountType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccountType userAccountType = db.UserAccountTypes.Find(id);
            if (userAccountType == null)
            {
                return HttpNotFound();
            }
            return View(userAccountType);
        }

        // POST: UserAccountType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccountType userAccountType = db.UserAccountTypes.Find(id);
            db.UserAccountTypes.Remove(userAccountType);
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
