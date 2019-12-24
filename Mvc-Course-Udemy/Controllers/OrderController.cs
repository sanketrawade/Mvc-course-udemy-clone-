using MyShop.Core.Model;
using MyShop.DataAcess.InSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            GenericDataAccess<Order> order = new GenericDataAccess<Order>(new DataContext());
            IQueryable<Order> Vieworder = order.DisplayAll();
            return View(Vieworder);
        }


    }
}