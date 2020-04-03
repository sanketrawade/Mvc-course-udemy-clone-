using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model
{
    public class OrderItem:BaseEntity
    {
        
        public string orderId { get; set; }
        [DisplayName("Item Name")]
        public string itemName { get; set; }
        [DisplayName("Item Price")]
        public decimal itemPrice { get; set; }
        [DisplayName("Item Quentity")]
        public int itemQuentity { get; set; }
        [DisplayName("Item Image")]
        public string itemImage { get; set; }
    }
}
