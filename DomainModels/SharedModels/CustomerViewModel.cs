using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.SharedModels
{
    public class CustomerViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Required]
        //public string Address { get; set; }
        //[Required]
        //public String City { get; set; }
        //[Required]
        //public String Pincode { get; set; }
        //[]
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        //[]
        //public DateTime RegisteredOn { get; set; }
        //[]
        // public bool IsOnline { get; set; }
        public int RoleId { get; set; }
        //public virtual Roles Roles { get; set; } //OneToOne Mapping
    }
}
