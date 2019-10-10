using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.SharedModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
        //[Required]
        //public string Size { get; set; }
        //[Required]
        //public string Color { get; set; }
        //[Required]
        //public DateTime EntryDate { get; set; }
        //[Required]
        //public string Image1 { get; set; }
        //[Required]
        public string Image { get; set; }
        public int CategId { get; set; }
    }
}
