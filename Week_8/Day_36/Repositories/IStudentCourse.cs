using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public interface IStudentCourse
    {
        IEnumerable<Students> GetAllStudents();

        IEnumerable<Courses> GetAllCoursesWithStudents();

        IEnumerable<Courses> GetAllCourses();
    }
}
