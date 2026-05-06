using Microsoft.AspNetCore.Mvc;
using MyWebApplication3.Models;

namespace MyWebApplication3.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(Feedback f)
        {
            if (f.Rating >= 4)
                f.Message = "Thank You for your feedback!";
            else
                f.Message = "We will improve based on your feedback.";

            return View("Form", f);
        }
    }
}