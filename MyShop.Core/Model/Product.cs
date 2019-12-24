using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model
{
   public class Product:BaseEntity
    {
        [StringLength(20)]
        [DisplayName("Enter Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(10, 100)]
        public decimal price { get; set; }
        public string cateogory { get; set; }
        public string Image { get; set; }
    }
}
