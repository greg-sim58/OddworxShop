using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OddworxShop.Data.DAL;
using OddworxShop.Data.Models;
using OddworxShop.ViewModels;

namespace OddworxShop.Controllers
{
    [Authorize]
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
            using (DataContext dbx = new DataContext())
            {
                model = new ShopItemViewModel
                {
                    Items = db.Items.Where(i => i.Shop.Id == shopId).ToList(),
                    ShopId = shopId,
                    ShopName = db.Shops.Where(s => s.Id == shopId).FirstOrDefault().Name,
                    Shop = db.Shops.Find(shopId)
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

        public ActionResult AddOrEdit(int shopId, int? id)
        {
            ItemEditViewModel model = new ItemEditViewModel();

            model.Shop = db.Shops.Find(shopId);

            if (id != null)
            {
                var item = db.Items.Find(id);

                if (item != null)
                {
                    model.Description = item.Description;
                    model.IsActive = item.IsActive;
                    model.Name = item.Name;
                    model.Price = item.Price;
                    model.Images = item.Images;
                    model.Shop = item.Shop;
                }
                else
                {
                    model.Shop = db.Shops.Find(shopId);
                    model.Images = new List<Image>();
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ItemEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Item/Create
        public ActionResult Create(int shopId)
        {
            CreateItemViewModel model = new CreateItemViewModel();
            using (DataContext ctx = new DataContext())
            {
                model.Shop = ctx.Shops.Find(shopId);
                model.Images = new List<Image>();
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
            ItemEditViewModel model = new ItemEditViewModel();

            using (DataContext ctx = new DataContext())
            {
                Item item = ctx.Items.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }

                model.Id = item.Id;
                model.Description = item.Description;
                model.DefaultImage = item.DefaultImage;
                model.Images = item.Images;
                model.IsActive = item.IsActive;
                model.Name = item.Name;
                model.Price = item.Price;
                model.Shop = item.Shop;

                if (item.Category != null)
                {
                    model.Category = ctx.ItemCategories.Find(item.Category.Id);
                }
                else
                {
                    model.Category = ctx.ItemCategories.Where(ic => ic.Name.ToLower() == "unknown").FirstOrDefault();
                }

                return View(model);
            }
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,CreatedAt,CreatedBy,LastModifiedAt,LastModifiedBy,IsActive")] ItemEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = db.Items.Find(model.Id);

                if (item != null)
                {
                    item.Description = model.Description;
                    item.IsActive = model.IsActive;
                    item.Name = model.Name;
                    item.Price = model.Price;
                }
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewItemsByShop", new { shopId = item.Shop.Id });
            }
            return View(model);
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

        [HttpPost]
        public ActionResult SaveImage(int? itemId)
        {
            var image = new Image();
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase file = files[0];
                    string contentType = file.ContentType;
                    string fname;
                    fname = file.FileName;

                    using (Stream fs = file.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            image = new Image();
                            image.ImageData = bytes;
                            image.Description = fname;
                            image.Name = fname;

                            db.Images.Add(image);
                            if (db.SaveChanges() > 0)
                            {
                                var item = db.Items.Find(itemId);
                                if (item != null)
                                {
                                    item.Images.Add(image);
                                    item.DefaultImage = image.Id;
                                }
                                db.Entry(item).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else
                            {
                                return Json("Unable to upload file", JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json("Unable to upload file", JsonRequestBehavior.AllowGet);
                }
                return Json(image.Id, JsonRequestBehavior.AllowGet);
            }
            return Json("No picture selected", JsonRequestBehavior.AllowGet);
        }

        public ActionResult  GetImage(int? id)
        {
            if (id != null && id != 0)
            {
                var image = db.Images.Find(id);
                byte[] data = image.ImageData;
                return File(image.ImageData, "image/jpg");
            }
            return Json(0, JsonRequestBehavior.AllowGet);

            //return Json(new { base64imgage = Convert.ToBase64String(data) }, JsonRequestBehavior.AllowGet);
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
