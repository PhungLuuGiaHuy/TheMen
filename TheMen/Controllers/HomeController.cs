using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMen.Models;

namespace TheMen.Controllers
{
    public class HomeController : Controller
    {

        TheMenDbContext context = new TheMenDbContext();
        public ActionResult Index()
        {
            HomeModel homeModelcontext = new HomeModel();

            homeModelcontext.ListCategory = context.Category.ToList();
            homeModelcontext.ListProduct = context.Product.ToList();
            return View(homeModelcontext);
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
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }

    }
}