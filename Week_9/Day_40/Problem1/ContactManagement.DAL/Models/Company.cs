using System.Collections.Generic;

namespace ContactManagement.DAL.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public ICollection<ContactInfo> Contacts { get; set; } = new List<ContactInfo>();
    }
}
