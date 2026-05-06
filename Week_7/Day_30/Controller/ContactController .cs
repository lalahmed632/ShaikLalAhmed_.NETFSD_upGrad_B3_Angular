using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        static List<ContactInfo> contacts = new List<ContactInfo>
{
    new ContactInfo
    {
        ContactId = 1, FirstName = "Amit",LastName = "Sharma", CompanyName = "ABC Pvt Ltd",
        EmailId = "amit@gmail.com", MobileNo = 9876543210, Designation = "Manager"
    },
    new ContactInfo
    {
        ContactId = 2, FirstName = "Priya", LastName = "Verma", CompanyName = "XYZ Ltd",
        EmailId = "priya@gmail.com", MobileNo = 9123456780, Designation = "HR"
    },
    new ContactInfo
    {
        ContactId = 3, FirstName = "Rahul", LastName = "Mehta", CompanyName = "TechSoft",
        EmailId = "rahul@gmail.com", MobileNo = 9988776655, Designation = "Developer"
    },
    new ContactInfo
    {
        ContactId = 4, FirstName = "Sneha", LastName = "Kapoor", CompanyName = "Global Corp",
        EmailId = "sneha@gmail.com", MobileNo = 9090909090, Designation = "Analyst"
    }
};

        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);


            return View(contact);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                if (contacts.Any(c => c.ContactId == contactInfo.ContactId))
                {
                    ModelState.AddModelError("ContactId", "Contact ID already exists");
                    return View(contactInfo);
                }
                else {
                    contacts.Add(contactInfo);
                    return RedirectToAction("ShowContacts");

                }
               
            }
            return View(contactInfo);
        }
    }
}