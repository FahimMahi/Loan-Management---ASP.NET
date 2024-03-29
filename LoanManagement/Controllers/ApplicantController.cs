using LoanManagement.DTOs;
using LoanManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult ApplicantDashboard()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["Role"] != null && Session["Role"].ToString() != "Applicant")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public ActionResult ApplicantProfiles()
        {
            LoanManagementEntities db = new LoanManagementEntities();
            if (Session["userID"] == null || Session["Role"].ToString() != "Loan Officer")
            {
                return RedirectToAction("Login", "Home"); 
            }

            var applicants = db.Users
                               .Select(user => new UserProfileDTO
                               {
                                   userID = user.userID,
                                   username = user.username,
                                   FullName = user.FullName,
                                   Email = user.Email,
                                   ContactNumber = user.ContactNumber,
                               })
                               .ToList();

            return View(applicants);
        }

    }
}