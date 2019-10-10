using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels
{
    [Table("T_Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int PID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public virtual Products Products { get; set; }
        [Required]
        [ForeignKey("Customers")]
        public int CustomerID { get; set; }
        public virtual Customers Customers { get; set; }

    }
}
