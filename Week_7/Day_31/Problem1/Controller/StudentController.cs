using Microsoft.AspNetCore.Mvc;
using MyWebApplication3.Models;

namespace MyWebApplication3.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(Student s)
        {
            return RedirectToAction("Display", s);
        }

        [HttpGet("display")]
        public IActionResult Display(Student s)
        {
            return View(s);
        }
    }
}