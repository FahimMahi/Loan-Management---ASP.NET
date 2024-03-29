using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class LoanOfficerController : Controller
    {
        // GET: LoanManager
        public ActionResult LoanOfficerDashboard()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["Role"] != null && Session["Role"].ToString() != "Loan Officer")
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

    }
}