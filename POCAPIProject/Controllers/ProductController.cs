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
    public class ProductController : ControllerBase
    {
        private readonly IProductBL productBL;
        public ProductController(IProductBL pBL)
        {
            productBL = pBL;
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return productBL.GetProduct();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public Products Get(int id)
        {
            return productBL.GetById(id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] Products value)
        {
            if (value != null)
                productBL.AddProductBL(value);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Products value)
        {
            if (value != null)
                productBL.UpdateProduct(value);
        }

        [HttpGet("ProductByCategory/{id}")]
        public List<Products> ProductByCategory(int id)
        {
            var data = productBL.ProductByCategoryBL(id);
            return data;
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productBL.DeleteProduct(id);
        }
    }
}
