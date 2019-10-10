using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.SharedModels
{
    public class OrderModel
    {
        public string Email { get; set; }
        public string Product { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int ProdId { get; set; }

    }
}
