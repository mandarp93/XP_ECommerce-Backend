using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels
{
    [Table("T_PaymentDetails")]
    public class PaymentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        //[Required]
        //public virtual OrdersEF OrderId { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime PayDate { get; set; }
    }
}
