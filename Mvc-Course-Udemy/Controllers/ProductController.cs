using MyShop.Core.Model;
using MyShop.Core.Model.ViewModel;
using MyShop.DataAccessInMemory;
using MyShop.DataAcess.InSQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class ProductController : Controller
    {
        GenericDataAccess<ProductCategory> category;
        GenericDataAccess<Product> items;
        ProductCategoryViewModel viewmodel;
        public ProductController()
        {
            DataContext context = new DataContext();
            category = new GenericDataAccess<ProductCategory>(context);
           items = new GenericDataAccess<Product>(context);
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(items.DisplayAll());
        }

        public ActionResult Create()
        {
            viewmodel = new ProductCategoryViewModel();
            viewmodel.category = category.DisplayAll();
            viewmodel.product = new Product();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase file)
        {
            if (file != null)
            {
                product.Image = file.FileName;
                file.SaveAs(Server.MapPath("//Content//ProductImage//") + product.Image);
            }
            items.Insert(product);
            items.Commit();
            return RedirectToAction("Index");
        }

       public ActionResult Delete(string id)
        {
            Product product = items.Find(id) as Product;
            return View(product);
        }

        public ActionResult Details(string id)
        {
            Product product = items.Find(id) as Product;
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
            Product product = items.Find(id);
            viewmodel = new ProductCategoryViewModel();
            viewmodel.category = category.DisplayAll();
            viewmodel.product = product;
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditProduct(string id,Product product,HttpPostedFileBase file)
        {
            if (file != null)
            {
                product.Image = product.ID + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content/ProductImage//") + product.Image);
            }
            items.Update(product, id);
            items.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult orderList()
        {
            GenericDataAccess<Order> order = new GenericDataAccess<Order>(new DataContext());
            IQueryable<Order> Vieworder = order.DisplayAll();
            return View(Vieworder);
        }


    }
}