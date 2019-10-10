using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels
{
    [Table("T_Orders")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public virtual Customers Customers { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int ProductID { get; set; }
        public virtual Products Products { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Status { get; set; }
        [Required]
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
