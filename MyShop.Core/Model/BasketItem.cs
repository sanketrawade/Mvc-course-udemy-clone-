﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model
{
    public class BasketItem : BaseEntity
    {
        public string basketId { get; set; }
        public string productId { get; set; }
        public int quantity { get; set; }
    }
}
