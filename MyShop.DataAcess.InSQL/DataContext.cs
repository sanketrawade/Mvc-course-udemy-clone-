using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAcess.InSQL
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {
  
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> category { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<BasketItem> basketitems { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
    }
}
