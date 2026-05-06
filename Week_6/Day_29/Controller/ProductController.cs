using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Category = "Electronics", Price = 60000 },
            new Product { ProductId = 2, ProductName = "Mobile", Category = "Electronics", Price = 25000},
            new Product { ProductId = 3, ProductName = "Headphones", Category = "Accessories", Price = 2000},
            new Product { ProductId = 4, ProductName = "Keyboard", Category = "Accessories", Price = 1500},
            new Product { ProductId = 5, ProductName = "Chair", Category = "Furniture", Price = 5000 }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product empObj = products.FirstOrDefault(item => item.ProductId == id);
            return View(empObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                products.Add(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(x => x.ProductId == p.ProductId);

                product.ProductName = p.ProductName;
                product.Category = p.Category;
                product.Price = p.Price;

                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product != null)
                products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}