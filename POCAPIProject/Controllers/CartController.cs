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
    public class CartController : ControllerBase
    {
        private readonly ICartBL cbl;
        public CartController(ICartBL cart)
        {
            cbl = cart;
        }
        // GET: api/Cart
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return cbl.GetCartDetails().ToList();
        }

        // GET: api/Cart/5
        [HttpGet("{uname}")]
        public Object Get(string uname)
        {
            var cartdetails = cbl.GetCartByName(uname);
            return cartdetails;
        }

        // POST: api/Cart
        [HttpPost]
        public void Post([FromBody] CartView model)
        {
            if (model != null)
            cbl.AddToCart(model);
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public Cart Put(int id)
        {
            return null;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cbl.DeleteCartItem(id);
        }
    }
}
