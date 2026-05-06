using System.Collections.Generic;

namespace ContactManagement.DAL.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public ICollection<ContactInfo> Contacts { get; set; } = new List<ContactInfo>();
    }
}
