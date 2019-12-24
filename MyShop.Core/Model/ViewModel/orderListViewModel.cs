using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model.ViewModel
{
    public class orderListViewModel:BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public ICollection<OrderItem> orderItms { get; set; }
    }
}
