using System;

namespace WebApplication2.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        // For JOIN (display purpose)
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
    }
}
