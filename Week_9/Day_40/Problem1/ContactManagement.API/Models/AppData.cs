namespace WebApplication3.Models
{
    public static class AppData
    {
        public static List<User> Users = new List<User>()
        {
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin123",
                Role = "Admin"
            },
            new User
            {
                Id = 2,
                Username = "user",
                Password = "user123",
                Role = "User"
            }
        };

        public static List<ContactInfo> Contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Rahul",
                LastName = "Sharma",
                EmailId = "rahul.sharma@example.com",
                MobileNo = 9876543210,
                Designation = "Manager",
                CompanyName = "ABC Pvt Ltd",
                DepartmentName = "Sales"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Priya",
                LastName = "Iyer",
                EmailId = "priya.iyer@example.com",
                MobileNo = 9123456780,
                Designation = "Developer",
                CompanyName = "XYZ Technologies",
                DepartmentName = "IT"
            }
        };
    }
}
