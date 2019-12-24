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
    public class BasketService
    {
        public GenericDataAccess<Basket> basketContext { get; set; }
        public GenericDataAccess<Product> productContext { get; set; }
        public GenericDataAccess<BasketItem> basketItemContext { get; set; }
        DataContext context = new DataContext();

        

        public BasketService(GenericDataAccess<Basket> basket, GenericDataAccess<Product> product)
        {
            basketContext = basket;
            productContext = product;
        }


        public Basket getBasket(HttpContextBase httpcontext)//Index Page of Basket show list of basket items 
        {
            HttpCookie cookie = httpcontext.Request.Cookies.Get("basketid");
            if (cookie != null)
            {
                Basket basket = new Basket();
                string cookievalue = cookie.Value;
                if (cookievalue != null)
                {
                    basket = basketContext.Find(cookievalue);
                }
                return basket;
            }
            else
            {
                Basket basket = new Basket();
                basket = createNewBasket(httpcontext);
                return basket;
            }
        }

        private Basket createNewBasket(HttpContextBase httpcontext)//Create new basket if not exist
        {
            Basket basket = new Basket();
            basketContext.Insert(basket);
            basketContext.Commit();
            string basketid = basket.ID;
            HttpCookie coookie = new HttpCookie("basketid", basketid);
            httpcontext.Response.Cookies.Add(coookie);
            return basket;
        }


        public int basketItemCount(HttpContextBase httpcontext)
        {
            var count = 0;
            Basket basket = this.getBasket(httpcontext);
            count = basket.BasketItems.Count();
            return count;
        }


        public void removeBasketItem(HttpContextBase httpcontextbase, string itemID)//delete item from basket
        {
            Basket basket = getBasket(httpcontextbase);
            BasketItem basketItem = basket.BasketItems.Where(items => items.ID == itemID).FirstOrDefault();
            basket.BasketItems.Remove(basketItem);
            basketContext.Commit();
        }

        public void removeAllBasketItems(HttpContextBase httpcontextbase)
        {
            Basket basket = getBasket(httpcontextbase);
            basket.BasketItems.Clear();
            basketContext.Commit();
        }


        public void addtoBasket(HttpContextBase httpcontextbase, string productID)//add new items in basket
        {
            Basket basket = getBasket(httpcontextbase);
            Product product = productContext.Find(productID);
            BasketItem basketitem = basket.BasketItems.Where(p => p.productId == productID).FirstOrDefault();
            if (basketitem != null)
            {
                basketitem.quantity = basketitem.quantity + 1;
            }
            else
            {
                basketitem = new BasketItem();
                basketitem.productId = product.ID;
                basketitem.basketId = basket.ID;
                basketitem.ID = Guid.NewGuid().ToString();
                basketitem.quantity = 1;
                basket.BasketItems.Add(basketitem);
            }
            basketContext.Commit();
        }

        public List<ItemListViewModel> GetBasketItem(HttpContextBase httpcontext)
        {
            Basket basket = getBasket(httpcontext);
            if (basket != null)
            {
                var result = (from b in basket.BasketItems
                              join p in productContext.DisplayAll() on b.productId equals p.ID
                              select new ItemListViewModel()
                              {
                                  ID = b.ID,
                                  itemQuentity = b.quantity,
                                  itemName = p.Name,
                                  itemImage = p.Image,
                                  itemPrice = p.price
                              }
                              ).ToList();
                return result;
        }
            else
            {
                return new List<ItemListViewModel>();
            }
           

        }

        public void clearBasket(HttpContextBase httpcontext,string id)
        {
            this.removeBasketItem(httpcontext,id);
        }
    }
}
