using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }

        // GET api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = GenerateProductId();
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // PUT api/products/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return NoContent();
        }

        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }

        private int GenerateProductId()
        {
            // Generate a unique product ID (You can replace this with your own logic)
            return new Random().Next(1000, 9999);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
 /*  ---------------------        

 In this example, we have a 'ProductController' that handles various HTTP methods 
 for the '/api/products' route. It includes the following API endpoints:

GET api/products            : Retrieves all products.
GET api/products/{id}       : Retrieves a specific product by its ID.
POST api/products           : Creates a new product.
PUT api/products/{id}       : Updates an existing product.
DELETE api/products/{id}    : Deletes a product.

The 'Product' class represents the structure of a product, including properties 
like 'Id', 'Name', and 'Price'.

Please note that this is a simplified example to demonstrate the basic structure
of a C# .NET API. In a real-world scenario, you would typically have more robust 
error handling, validation, authentication/authorization, and a database integration 
layer.

Typical JSON object : 

[{
  "id": 1,
  "name": "Sample Product",
  "price": 9.99
}]


    -----------------------  */