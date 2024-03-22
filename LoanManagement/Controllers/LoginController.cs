using LoanManagement.DTOs;
using LoanManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class LoginController : Controller
    {
        LoanManagementEntities db = new LoanManagementEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO l)
        {
            var User = (from u in db.Users
                        where u.username == l.username
                        && u.password == l.password
                        select u).SingleOrDefault();
            if (User != null)
            {
                Session["User"] = User;
                if (User.Role.Equals("LoanManager"))
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Login");
            }
            TempData["Msg"] = "Invalid username and password";
            return RedirectToAction("Index");
        }
        public ActionResult Registration(User u)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}