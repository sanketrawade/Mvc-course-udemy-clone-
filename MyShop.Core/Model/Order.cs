using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model
{
    public class Order:BaseEntity
    {
        public Order()
        {
            this.orderItems = new List<OrderItem>();
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string status { get; set; }
        public virtual ICollection<OrderItem> orderItems { get; set; }
    }
}
