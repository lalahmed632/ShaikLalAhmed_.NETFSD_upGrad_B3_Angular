namespace WebApplication3.Models
{
    public class Courses
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public List<Students> Students { get; set; } = new List<Students>();
    }
}
