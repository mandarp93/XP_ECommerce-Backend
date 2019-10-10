using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels
{
    [Table("T_Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
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
        [Required]
        [ForeignKey("Categories")]
        public int CategId { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
