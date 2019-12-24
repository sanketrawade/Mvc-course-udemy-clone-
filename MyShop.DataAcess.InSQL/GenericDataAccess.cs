using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAcess.InSQL
{
    public class GenericDataAccess<T> where T:BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> Model;
        public GenericDataAccess(DataContext context)
        {
            this.context = context;
            Model = context.Set<T>();
        }

        public void Insert(T insertProduct)
        {
            Model.Add(insertProduct);
            Commit();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var t = Find(id);
            if(context.Entry(t).State == EntityState.Detached)
            {
                Model.Attach(t);
            }
            Model.Remove(t);
        }

        public void Update(T Item, string id)
        {
            Model.Attach(Item);
            context.Entry(Item).State = EntityState.Modified;
        }

        public IQueryable<T> DisplayAll()
        {
            return Model;
        }

        public T Find(string id)
        {
            return Model.Find(id);
        }

    }
}
