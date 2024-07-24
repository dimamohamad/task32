using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace task32.Controllers
{
    public class AccountController : Controller
    {
        // Array of valid users
        private readonly (string Email, string Password)[] validUsers = new[]
        {
            (Email: "dima@gmail.com", Password: "123123"),
            (Email: "lujain@gmail.com", Password: "123")
            // Add other valid users as needed
        };

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string password)
        {
            bool isValidUser = validUsers.Any(X => X.Email == Email && X.Password == password);

            if (isValidUser)
            {
                Session["User"] = Email;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid Email or password.";
            return View();
        }

        // GET: Login/Logout
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        // Logout action
      

        // Profile page, requires authorization
        [Authorize]
        public ActionResult Profile()
        {
            return View();
        }
    }
}
