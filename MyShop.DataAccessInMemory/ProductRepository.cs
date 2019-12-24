using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccessInMemory
{
    public class ProductRepository:BaseEntity
    {
        public List<Product> Products;
        ObjectCache cache = MemoryCache.Default;

        public ProductRepository()
        {
            Products = cache["products"] as List<Product>;
            if (Products == null)
            {
                Products = new List<Product>();
            }
        }

        public void Insert(Product product)
        {
            Products.Add(product);
        }

        public void Commit()
        {
            cache["products"] = Products;
        }

        public IQueryable<Product> DisplayAll()
        {
            return Products.AsQueryable<Product>();
        }

        public void Delete(string id)
        {
            Product producttodelete = Find(id) as Product;
            if (producttodelete != null)
            {
                Products.Remove(producttodelete);
            }
        }

        public void Edit(Product product,string id)
        {
            Product producttoedit = Find(id) as Product;
            if (producttoedit != null)
            {
                producttoedit = product;
            }
        }

        public Object Find(string id)
        {
            Product item = Products.Find(p => p.ID == id);
            if (item != null)
            {
                return item;
            }
            return new Exception("Not Found Product");
        }

    }
}
