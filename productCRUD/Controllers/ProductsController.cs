using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productCRUD.Models;
using System.Reflection.Metadata.Ecma335;

namespace productCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List <Product> products = new List<Product>
        {
            new Product { Id = 1, Name="Laptop", Description="This is laptop"},
            new Product { Id = 2, Name="Iphine 11", Description="This is Iphone 11"},
            new Product { Id = 3, Name="Iphine 12", Description="This is Iphone 12"}
        };
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(products);
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var product = products.Find(product=>product.Id==id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        
        public ActionResult Add( Product Request)
        {
            if (Request == null)
            {
                return BadRequest();
            }
            var product = new Product {
                Id= Request.Id, Name= Request.Name, Description= Request.Description
            };
            products.Add(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public ActionResult update(int id ,Product Request) {
            var currentProduct=products.FirstOrDefault(product=>product.Id==id);
            if (currentProduct is null)
            {
                return NotFound();
            }
            currentProduct.Id= Request.Id;
            currentProduct.Name= Request.Name;
            currentProduct.Description= Request.Description;
            return Ok(currentProduct);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            var product = products.FirstOrDefault(product=>product.Id==id);
            if(product ==null) { 
                return NotFound();
            }
            products.Remove(product);
            return Ok();
        }
    }
}
