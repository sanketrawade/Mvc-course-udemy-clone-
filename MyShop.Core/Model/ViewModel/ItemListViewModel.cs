using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model.ViewModel
{
    public class ItemListViewModel:BaseEntity
    {
        public string itemName { get; set; }
        public decimal itemPrice { get; set; }
        public int itemQuentity { get; set; }
        public string itemImage { get; set; }
        public int productID { get; set; }
    }
}
