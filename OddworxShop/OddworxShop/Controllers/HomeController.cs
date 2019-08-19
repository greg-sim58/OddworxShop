using OddworxShop.Data.DAL;
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
                var model = ctx.Items.ToList();

                

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
    }
}