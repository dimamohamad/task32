using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task32.Models;

namespace task32.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        private static List<ContactFormEntry> submittedContacts = new List<ContactFormEntry>();

        // GET: Contact
        public ActionResult Contact()
        {
            // Pass the submitted contacts to the view using ViewBag
            ViewBag.SubmittedContacts = submittedContacts;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name, string email, string message)
        {
            if (ModelState.IsValid)
            {
                var entry = new ContactFormEntry
                {
                    Name = name,
                    Email = email,
                    Message = message
                };

                // Add the new entry to the static list
                submittedContacts.Add(entry);

                // Clear the form fields after submission
                ViewBag.Name = string.Empty;
                ViewBag.Email = string.Empty;
                ViewBag.Message = string.Empty;

                // Pass the updated list back to the view
                ViewBag.SubmittedContacts = submittedContacts;

                return View();
            }

            // If model state is invalid, return the view with the form data
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Message = message;
            ViewBag.SubmittedContacts = submittedContacts;
            return View();
        }
    }
}
