using MyShop.Core.Model;
using MyShop.Core.Model.ViewModel;
using MyShop.DataAcess.InSQL;
using MyShop.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class OrderController : Controller
    {
        OrderService orderservice = new OrderService();
        AdminOrderViewModel viewModel;
        GenericDataAccess<OrderStatus> orderStatus;
        GenericDataAccess<Order> orderContext;
        GenericDataAccess<OrderItem> orderItemContext;
        // GET: Order

        public OrderController()
        {
            orderStatus = new GenericDataAccess<OrderStatus>(new DataContext());
            orderContext = new GenericDataAccess<Order>(new DataContext());
            orderItemContext = new GenericDataAccess<OrderItem>(new DataContext());
        }

        public ActionResult Index()
        {
            return View(orderContext.DisplayAll());
        }

        [Authorize]
        public ActionResult showOrder()
        {
            List<Order> order = orderContext.DisplayAll().Where(p => p.Email == User.Identity.Name).ToList();
            return View(order);
        }

       
        public ActionResult UpdateOrder(string id)
        {
            viewModel = new AdminOrderViewModel();
            Order order = orderContext.Find(id);
            //order.orderItems = orderItemContext.DisplayAll().Where(item => item.orderId == order.ID).ToList();
            viewModel.Order = order;
            viewModel.Status = orderStatus.DisplayAll();
            return View(viewModel);
        }


        [HttpPost]
        //[ActionName("Update")]
        public ActionResult UpdateOrder(string id,Order order)
        {
            orderContext.Update(order, id);
            orderContext.Commit();
            return RedirectToAction("Index");
        }


    }
}
