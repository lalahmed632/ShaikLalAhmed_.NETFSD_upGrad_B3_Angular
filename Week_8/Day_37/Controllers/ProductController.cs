using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;


namespace WebApplication26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()   
        {
            new Product { Id = 1, Name = "Laptop", Price= 75000, Category = "Electronics"},
            new Product { Id = 2, Name = "Mobile", Price= 65000, Category = "Electronics"},
            new Product { Id = 3, Name = "Tablet", Price= 55000, Category = "Electronics"}
        };


        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.Find(item => item.Id == id);

            if(product == null)
            {
                return NotFound("Requested product does not exists");
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);
         
            // Customize the response :  data, status codes 
            return Ok(new { product, status = "New product successfully added to server..!" });
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var oldProduct = products.Find(item => item.Id == id);

            if (oldProduct == null)
            {
                return NotFound("Requested product does not exists");
            }
            else
            {
                oldProduct.Name = product.Name;
                oldProduct.Category = product.Category;
                oldProduct.Price = product.Price;
                return Ok(new { updatedProduct=  oldProduct, status = "Product details are updated successfully in server..!" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.Find(item => item.Id == id);

            if (product == null)
            {
                return NotFound("Requested product does not exists");
            }
            else
            {
                products.Remove(product);
                return Ok(new { product, status = "Product details are deleted successfully in server..!" });
            }
        }
    }
}
