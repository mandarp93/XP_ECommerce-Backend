using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DomainModels;
using DomainModels.SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POCAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerBL customerBL;

        public CustomersController(ICustomerBL cBL)
        {
            customerBL = cBL;
        }
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return customerBL.GetCustomerDetails();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            customerBL.CustomerById(id);
            return "success";
        }

        [HttpGet("GetByName/{uname}")]
       // [Route("/api/Customers/GetByName")]
        public Customers GetByName(string uname)
        {
             return customerBL.CustomerByName(uname);
            
        }
        // POST: api/Customers
        [HttpPost]
        public string Post([FromBody] Customers value)
        {
            if (value != null)
            customerBL.Register(value);
            return "success";
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put([FromBody] Customers value)
        {
            customerBL.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerBL.DeleteUser(id);
        }

        [HttpPost()]
        [Route("/api/Customers/Login")]
        public Object Login([FromBody] LoginModel customer)
        {
            ResponseController response = new ResponseController();
            if (customer != null)
            {
                var user = customerBL.LoginUser(customer);
                if (user != null)
                {
                    response.Status = "success";
                    return user;
                }
                else
                    response.Status = "User not Valid";
            }
            else
            {
                response.Status = "Error";
            }
            return response;
        }
    }
}
