using Microsoft.AspNetCore.Mvc;
using MyWebApplication3.Models;

namespace MyWebApplication3.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(Calculator c)
        {
            c.Result = c.Num1 + c.Num2;
            return View(c);
        }
    }
}