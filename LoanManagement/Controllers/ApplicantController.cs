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
        public ActionResult Index()
        {
            return View();
        }
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

    }
}