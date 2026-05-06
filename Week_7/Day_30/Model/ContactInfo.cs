using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(15, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(15, MinimumLength = 5)]
        public string LastName { get; set; }

        public string CompanyName { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        //[Required(ErrorMessage = "Mobile Number is required.")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]

        public long MobileNo { get; set; }

        public string Designation { get; set; }
    }
}