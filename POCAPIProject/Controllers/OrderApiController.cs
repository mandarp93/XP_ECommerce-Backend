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
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderBL orderBL;
        public OrderApiController(IOrderBL order)
        {
            orderBL = order;
        }
        // GET: api/OrderApi
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            return orderBL.GetOrderDetailsBL();
        }

        // GET: api/OrderApi/5
        [HttpGet("GetOrder/{uname}")]
        public object GetOrder(string uname)
        {
            return orderBL.GetOrdersByUser(uname);
        }

        // POST: api/OrderApi
        [HttpPost]
        //[Route("saveaddress")]
        public Orders Post(OrderView value)
        {
            if (value != null)
            {
                return orderBL.PostOrder(value);
            }
            return null;
        }

        [HttpGet("{value}")]
        public Object BuyModel(OrderModel value)
        {
            return orderBL.GetBuyDetailsBL(value);
        }

        // PUT: api/OrderApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
