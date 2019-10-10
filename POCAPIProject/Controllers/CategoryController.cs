using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POCAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBL catBL;
        public CategoryController(ICategoryBL category)
        {
            catBL = category;
        }
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Categories> Get()
        {
            return catBL.GetCategories();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Category/5
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
