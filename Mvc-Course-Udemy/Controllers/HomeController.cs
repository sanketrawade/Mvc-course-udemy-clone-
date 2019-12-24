using MyShop.Core.Model;
using MyShop.Core.Model.ViewModel;
using MyShop.DataAcess.InSQL;
using MyShop.Test;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class HomeController : Controller
    {
        GenericDataAccess<ProductCategory> category;
        GenericDataAccess<Product> items;
        DataContext context;
        public HomeController()
        {
            context = new DataContext();
            category = new GenericDataAccess<ProductCategory>(context);
            items = new GenericDataAccess<Product>(context);
        }

        // GET: Product
        public ActionResult Index()
        {
            ProductListViewModel listModel = new ProductListViewModel();
            listModel.category = category.DisplayAll();
            listModel.product = items.DisplayAll();//home page
            return View(listModel);        
        }

        public ActionResult Filter(string Viewcategory="Pistol")
        {
            ProductListViewModel listModel2 = new ProductListViewModel();
            listModel2.category = category.DisplayAll();
            listModel2.product = items.DisplayAll().Where(p => p.cateogory == Viewcategory);
            var json = JsonConvert.SerializeObject(listModel2);
            return Json(json, JsonRequestBehavior.AllowGet);
            //return View(listModel2);
        }


        public ActionResult Details(string id)
        {
            Product productdetail = items.Find(id);
            if (productdetail != null)
            {
                return View(productdetail);
            }
            return RedirectToAction("Index");
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