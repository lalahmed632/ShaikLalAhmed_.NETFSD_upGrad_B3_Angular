using Microsoft.AspNetCore.Mvc;
using MyWebApplication3.Models;
using System.Collections.Generic;

namespace MyWebApplication3.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View(products);
        }

        [HttpPost("add")]
        public IActionResult Add(Product p)
        {
            products.Add(p);
            return View("Index", products);
        }
    }
}