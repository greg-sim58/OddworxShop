using OddworxShop.Data.DAL;
using OddworxShop.Data.Models;
using OddworxShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OddworxShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (DataContext ctx = new DataContext())
            {
                var model = ctx.Items.Include("Shop").ToList();

                return View(model);
            }
        }

        public ActionResult Front()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowItemsDetails(int? id)
        {
            ShowItemDetailsViewModel model = new ShowItemDetailsViewModel();

            if (id != null)
            {
                using (DataContext ctx = new DataContext())
                {
                    var item = ctx.Items.Find(id);

                    if (item != null)
                    {
                        model.Description = item.Description;
                        model.DefaultImage = item.DefaultImage;
                        model.Id = item.Id;
                        model.Name = item.Name;
                        model.Price = item.Price;
                    }
                }
            }

            return View(model);
        }
    }
}