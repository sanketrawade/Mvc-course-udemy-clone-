using MyShop.Core.Model;
using MyShop.Core.Model.ViewModel;
using MyShop.DataAcess.InSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Test
{
    public class OrderService
    {
        GenericDataAccess<Order> orderContext;
        GenericDataAccess<Basket> basketContext;
        HttpContextBase httpcontext;

        public OrderService()
        {
            orderContext = new GenericDataAccess<Order>(new DataContext());
        }

        public OrderService(GenericDataAccess<Order> orderContext)
        {
            this.orderContext = orderContext;
        }

        //public Order showOrder()
        //{
        //    Order order = orderContext.DisplayAll().Where(p => p.Email == User.Identity.Name).FirstOrDefault();
        //    return order;
        //}

        public void generateOrder(Order order,List<ItemListViewModel> basketItems)
        {
            foreach(var item in basketItems)
            {
                order.orderItems.Add(new OrderItem()
                {
                    itemImage = item.itemImage,
                    itemPrice = item.itemPrice,
                    itemName = item.itemName,
                    itemQuentity = item.itemQuentity
                });
            }
            orderContext.Insert(order);
            orderContext.Commit();
        }

        public Order FindOrder(string id)
        {
            Order order = orderContext.Find(id);
            return order;
        }

        public void UpdateOrder(Order order,string id)
        {
            orderContext.Update(order, id);
            orderContext.Commit();
        }
    }
}
