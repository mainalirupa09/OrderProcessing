﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
   public  class ProductStock
    {
        
        public ProductStock()
        {

        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
    }
}
