using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model.ViewModel
{
    public class ProductListViewModel
    {
        public IQueryable<Product> product;
        public IQueryable<ProductCategory> category;
    }
}
