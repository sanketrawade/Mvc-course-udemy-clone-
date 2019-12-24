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
            order.status = "Confirm";
            orderContext.Insert(order);
            orderContext.Commit();
        }
    }
}
