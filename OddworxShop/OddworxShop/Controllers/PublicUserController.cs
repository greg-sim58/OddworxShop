using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OddworxShop.Common;

namespace OddworxShop.Controllers
{
    public class PublicUserController : Controller
    {
        // GET: PublicUser
        public ActionResult Index()
        {
            List<string> toAddresses = new List<string>();
            toAddresses.Add("gregory.adams2@capetown.gov.za");

            Common.EmailHelper.EmailSender.SendMail(toAddresses, null, "Test Subject", "Test body");
            return View();
        }

        public ActionResult UserProfile(int? id)
        {
            return View();
        }
    }
}