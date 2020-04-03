using MyShop.Core.Model;
using MyShop.DataAcess.InSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class OrderStatusController : Controller
    {
        public GenericDataAccess<OrderStatus> status;


        public OrderStatusController()
        {
            status = new GenericDataAccess<OrderStatus>(new DataContext());
        }

        // GET: OrderStatus
        public ActionResult Index()
        {
            return View(status.DisplayAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderStatus Newstatus)
        {
            status.Insert(Newstatus);
            status.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            OrderStatus product = status.Find(id) as OrderStatus;
            return View(product);
        }

        public ActionResult Details(string id)
        {
            OrderStatus orderstatus = status.Find(id) as OrderStatus;
            return View(orderstatus);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteProduct(string id)
        {
            status.Delete(id);
            status.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            OrderStatus orderstatus = status.Find(id);
            return View(orderstatus);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditProduct(string id, OrderStatus Editstatus, HttpPostedFileBase file)
        {
            status.Update(Editstatus, id);
            status.Commit();
            return RedirectToAction("Index");
        }
    }
}
