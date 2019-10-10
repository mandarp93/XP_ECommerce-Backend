using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.SharedModels
{
    public class OrderView
    {
        public string Email { get; set; }
        public int ProdId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }
        public string State { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
    }
}
