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
        public ActionResult Detail(int id)
        {
            DetailModel DetailModelCotext = new DetailModel();
            DetailModelCotext.product = context.Product.Where(n => n.ProductId == id).FirstOrDefault();
            DetailModelCotext.ListProductCategory = context.Product.Where(n => n.CategoryId == id).ToList();
            return View(DetailModelCotext);
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}