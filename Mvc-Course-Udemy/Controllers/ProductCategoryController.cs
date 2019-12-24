using MyShop.Core.Model;
using MyShop.DataAccessInMemory;
using MyShop.DataAcess.InSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class ProductCategoryController : Controller
    {
        DataContext context;
        GenericDataAccess<ProductCategory> items;
        public ProductCategoryController()
        {
            context = new DataContext();
            items = new GenericDataAccess<ProductCategory>(context);
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(items.DisplayAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategory product)
        {
            items.Insert(product);
            items.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            ProductCategory product = items.Find(id) as ProductCategory;
            return View(product);
        }

        public ActionResult Details(string id)
        {
            ProductCategory product = items.Find(id) as ProductCategory;
            return View(product);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteProduct(string id)
        {
            items.Delete(id);
            items.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            ProductCategory producttoedit = items.Find(id) as ProductCategory;
            return View(producttoedit);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory product, string id)
        {
            items.Update(product, id);
            items.Commit();
            return RedirectToAction("Index");
        }


    }
}