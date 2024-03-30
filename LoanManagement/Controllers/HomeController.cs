using LoanManagement.DTOs;
using LoanManagement.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO r)
        {
            LoanManagementEntities db = new LoanManagementEntities();
            var user = (from d in db.Users
                        where d.username == r.username && d.password == r.password
                        select d).SingleOrDefault();

            if (user != null)
            {
                Session["username"] = user.username;
                Session["Role"] = user.Role;
                Session["userID"] = user.userID;
                switch (user.Role)
                {
                    case "Admin":
                        return RedirectToAction("AdminDashboard", "Admin");
                    case "Loan Officer":
                        return RedirectToAction("LoanOfficerDashboard", "LoanOfficer");
                    case "Applicant":
                        return RedirectToAction("ApplicantDashboard", "Applicant");
                    default:
                        TempData["Msg"] = "Invalid Role";
                        break;
                }
            }
            else
            {
                TempData["Msg"] = "Username or Password Invalid";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDTO l)
        {
            LoanManagementEntities db = new LoanManagementEntities();
            if (ModelState.IsValid)
            {
                var userExists = db.Users.Any(u => u.username == l.username || u.Email == l.Email);
                if (userExists)
                {
                    ModelState.AddModelError("", "Username or Email already exists.");
                    return View(l);
                }


                var user = new User
                {
                    username = l.username,
                    password = l.password,
                    FullName = l.FullName,
                    Email = l.Email,
                    ContactNumber = l.ContactNumber,
                    Role = "Applicant",
                    DateCreated = DateTime.Now
                };

                db.Users.Add(user);
                db.SaveChanges();

                TempData["Msg"] = "Applicant Registered Succesfully";

                return RedirectToAction("Login");
            }

            return View(l);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            LoanManagementEntities db = new LoanManagementEntities();
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int currentUserId = Convert.ToInt32(Session["userID"]);
            var user = db.Users.Find(currentUserId);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userProfileDto = new UserProfileDTO
            {
                userID = user.userID,
                username = user.username,
                FullName = user.FullName,
                Email = user.Email,
                ContactNumber = user.ContactNumber
            };

            return View(userProfileDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(UserProfileDTO userDto)
        {
            LoanManagementEntities db = new LoanManagementEntities();
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                var user = db.Users.Find(userDto.userID);

                if (user == null)
                {
                    return HttpNotFound();
                }

                user.username = userDto.username;
                user.FullName = userDto.FullName;
                user.Email = userDto.Email;
                user.ContactNumber = userDto.ContactNumber;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Msg"] = "Profile Edited Succesfully";

                switch (user.Role)
                {
                    case "Admin":
                        return RedirectToAction("AdminDashboard", "Admin");
                    case "Loan Officer":
                        return RedirectToAction("LoanOfficerDashboard", "LoanOfficer");
                    case "Applicant":
                        return RedirectToAction("ApplicantDashboard", "Applicant");
                    default:
                        TempData["Msg"] = "Invalid Role";
                        break;
                    }
                }

            return View(userDto);
        }


    }
}