using MyShop.Core.Model;
using MyShop.DataAcess.InSQL;
using MyShop.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class OrderController : Controller
    {
        OrderService orderservice = new OrderService();
        // GET: Order
        public ActionResult Index()
        {
            GenericDataAccess<Order> order = new GenericDataAccess<Order>(new DataContext());
            IQueryable<Order> Vieworder = order.DisplayAll();
            return View(Vieworder);
        }

        [HttpGet]
        public ActionResult UpdateOrder(string id)
        {
            Order order = orderservice.FindOrder(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult UpdateOrder(string id, Order order)
        {
            orderservice.UpdateOrder(order, id);
            return RedirectToAction("Index");
        }


    }
}