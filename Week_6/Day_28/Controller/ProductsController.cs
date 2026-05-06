using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult prod()
        {

          List < Products > values = new List<Products>()
          {
                new Products { Id = 1, Name = "Laptop", CategoryId=100 },
                new Products { Id = 2, Name = "Headphones", CategoryId = 102 },
                new Products { Id = 3, Name = "PS4", CategoryId = 103 }
          };
            return View(values);
        }
    }
}
