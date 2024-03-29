using LoanManagement.DTOs;
using LoanManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class LoanProductController : Controller
    {
        // GET: LoanProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewLoanProduct()
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

            LoanManagementEntities db = new LoanManagementEntities();

            var loanProducts = db.LoanProducts
                                 .Select(lp => new LoanProductDTO
                                 {
                                     ProductID = lp.ProductID,
                                     ProductName = lp.ProductName,
                                     InterestRate = lp.InterestRate,
                                     TermMonths = lp.TermMonths,
                                     EligibilityCriteria = lp.EligibilityCriteria
                                 })
                                 .ToList();

            return View(loanProducts); 
        }


    }
}