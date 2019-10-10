using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.SharedModels
{
    public class CartView
    {
        public int productId { get; set; }
        public string emailId { get; set; }
        public double price { get; set; }
        public double totalprice { get; set; }
        public int quantity { get; set; }
    }
}
