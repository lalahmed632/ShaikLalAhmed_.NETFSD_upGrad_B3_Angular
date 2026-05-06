using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    //[Route("Student")]
    public class StudentController : Controller
    {
        private readonly IStudentCourse _repo;

        public StudentController(IStudentCourse repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult ShowStudents()
        {
            var students = _repo.GetAllStudents();
            return View(students);
        }

        [HttpGet("Courses")]
        public IActionResult ShowCourses()
        {
            var courses = _repo.GetAllCoursesWithStudents();
            return View(courses);
        }

        [HttpGet("AllCourses")]
        public IActionResult ShowAllCourses()
        {
            var courses = _repo.GetAllCourses();
            return View(courses);
        }
    }
}