using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccessInMemory
{
    public class GenericInMemory<T> where T:BaseEntity
    {
        public string classname { get; set; }
        public List<T> items { get; set; }
        ObjectCache catche = MemoryCache.Default;

        public GenericInMemory()
        {
            classname = typeof(T).Name;
            items = catche[classname] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }

        }

        public void Insert(T insertProduct)
        {
            items.Add(insertProduct);
            Commit();
        }

        public void Commit()
        {
            catche[classname] = items;
        }

        public void Delete(string id)
        {
            T producttoDelete = items.Find(p => p.ID == id);
            items.Remove(producttoDelete);
        }

        public void Update(T Item, string id)
        {
            T producttoUpdate = items.Find(p => p.ID == id);
            if (producttoUpdate != null)
            {
                producttoUpdate = Item;
            }
        }

        public IQueryable<T> DisplayAll()
        {
            return items.AsQueryable();
        }

        public T Find(string id)
        {
            T item = items.Find(p => p.ID == id);
            if (items != null)
            {
                return item;
            }
            throw new Exception("Product Not Found");
        }

    }
}
