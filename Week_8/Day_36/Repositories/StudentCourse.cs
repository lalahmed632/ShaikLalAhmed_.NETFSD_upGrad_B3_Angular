using WebApplication3.Models;
using Dapper;
using WebApplication3.Data;

namespace WebApplication3.Repositories
{
    public class StudentCourse : IStudentCourse
    {
        private readonly DapperContext _context;

        public StudentCourse(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Students> GetAllStudents()
        {
            var sql = @"SELECT s.StudentId, s.StudentName, s.CourseId, c.CourseName
                        FROM Student s
                        LEFT JOIN Course c ON s.CourseId = c.CourseId";

            using var db = _context.CreateConnection();
            return db.Query<Students>(sql);
        }

        public IEnumerable<Courses> GetAllCoursesWithStudents()
        {
            var sql = @"SELECT c.CourseId, c.CourseName,
                               s.StudentId, s.StudentName, s.CourseId
                        FROM Course c
                        LEFT JOIN Student s ON c.CourseId = s.CourseId";

            var courseDict = new Dictionary<int, Courses>();

            using var db = _context.CreateConnection();
            db.Query<Courses, Students, Courses>(sql,
                (course, student) =>
                {
                    if (!courseDict.TryGetValue(course.CourseId, out var existing))
                    {
                        existing = course;
                        courseDict[course.CourseId] = existing;
                    }
                    if (student != null && student.StudentId != 0)
                        existing.Students.Add(student);

                    return existing;
                },
                splitOn: "StudentId"
            );

            return courseDict.Values;
        }

        public IEnumerable<Courses> GetAllCourses()
        {
            using var db = _context.CreateConnection();
            return db.Query<Courses>("SELECT * FROM Course");
        }
    }
}