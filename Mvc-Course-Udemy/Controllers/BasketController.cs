using MyShop.Core.Model;
using MyShop.Core.Model.ViewModel;
using MyShop.DataAcess.InSQL;
using MyShop.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course_Udemy.Controllers
{
    public class BasketController : Controller
    {
        BasketService basketservice;
        GenericDataAccess<Basket> basketcontext;
        OrderService orderservice;
        GenericDataAccess<Customer> customers;

        public BasketController()
        {
            DataContext context = new DataContext();
            basketcontext = new GenericDataAccess<Basket>(context);
            GenericDataAccess<Product> productcontext = new GenericDataAccess<Product>(context);
            GenericDataAccess<Order> orderContext = new GenericDataAccess<Order>(context);
            basketservice = new BasketService(basketcontext,productcontext);
            customers = new GenericDataAccess<Customer>(context);
        }

        public BasketController(BasketService basketservice)
        {
            this.basketservice = basketservice;
        }

        // GET: Basket
        public ActionResult Index()
        {
            List<ItemListViewModel> model = basketservice.GetBasketItem(this.HttpContext);
            return View(model);
        }

        public ActionResult addtoBasket(string id)
        {
            basketservice.addtoBasket(this.HttpContext, id);
            return RedirectToAction("Index",basketservice);
        }

        public ActionResult removeBasketItem(string Itemid)
        {
            basketservice.removeBasketItem(this.HttpContext, Itemid);
            return RedirectToAction("Index");
        }

        public PartialViewResult count()
        {
            var count = basketservice.basketItemCount(this.HttpContext);
            BasketItemCountViewModel model = new BasketItemCountViewModel();
            return PartialView(model);
        }
        

        [Authorize]
        [HttpGet]
        public ActionResult checkout()
        {
            Order order = new Order();
            Customer customer = customers.DisplayAll().FirstOrDefault(p => p.Email == User.Identity.Name);
            if (customer != null)
            {
                order.firstName = customer.firstName;
                order.lastName = customer.lastName;
                order.street = customer.street;
                order.state = customer.state;
                order.zipCode = customer.zipCode;
                order.Email = customer.Email;
                order.city = customer.city;
                return View(order);
            }
            else
            {
                return RedirectToAction("error");
            }
            
        }

        [HttpPost]
        public ActionResult checkout(Order order)
        {
            var basketItems = basketservice.GetBasketItem(this.HttpContext);

            order.status = "Order Placed";
            //foreach(var item in basketItems)
            //{
            //    order.orderItems.Add(new OrderItem()
            //    {
            //        itemName = item.itemName,
            //        itemPrice = item.itemPrice,
            //        itemImage = item.itemImage,
            //        itemQuentity = item.itemQuentity
            //    });
            //}
            orderservice = new OrderService();
            orderservice.generateOrder(order, basketItems);
            basketservice.removeAllBasketItems(this.HttpContext);
            return RedirectToAction("orderDetails",order);
        }


       

        public ActionResult orderDetails(Order order)
        {
            return View(order);
        }

        public ActionResult MyOrders()
        {
            return View();
        }


        public ActionResult error()
        {
            return View();
        }

    }
}