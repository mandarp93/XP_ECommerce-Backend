using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    [Table("T_Customers")]
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //[Required]
        //public String Address { get; set; }
        //[Required]
        //public String City { get; set; }
        //[Required]
        //public String Pincode { get; set; }
        //[Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MobileNo { get; set; }
        //[Required]
        //public DateTime RegisteredOn { get; set; }
        //[Required]
        // public bool IsOnline { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public virtual Roles Roles { get; set; } //OneToOne Mapping
    }
}
