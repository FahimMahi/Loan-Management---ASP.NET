using LoanManagement.DTOs;
using LoanManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        [HttpGet]
        public ActionResult ApplyApplication()
        {
            LoanManagementEntities db = new LoanManagementEntities();
            if (Session["userID"] == null || Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["Role"] != null && Session["Role"].ToString() != "Applicant")
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.ProductID = new SelectList(db.LoanProducts, "ProductID", "ProductName");
            var loanApplication = new LoanDTO();
            return View(loanApplication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyApplication(LoanDTO application)
        {
            LoanManagementEntities db = new LoanManagementEntities();
            if (Session["userID"] == null || Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["Role"] != null && Session["Role"].ToString() != "Applicant")
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                var newApplication = new LoanApplication
                {
                    LoanAmount = application.LoanAmount,
                    ApplicantID = (int)Session["userID"],
                    ProductID = application.ProductID,
                    ApplicationStatus = "Pending", 
                    AppliedDate = DateTime.Now, 
                };

                db.LoanApplications.Add(newApplication);
                db.SaveChanges();

                return RedirectToAction("MyApplications");
            }

            ViewBag.ProductID = new SelectList(db.LoanProducts, "ProductID", "ProductName", application.ProductID);
            return View(application);
        }
        public ActionResult MyApplications()
        {
            LoanManagementEntities db = new LoanManagementEntities();
            if (Session["userID"] == null || Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["Role"] != null && Session["Role"].ToString() != "Applicant")
            {
                return RedirectToAction("Login", "Home");
            }

            var currentUserId = Convert.ToInt32(Session["userID"]);

            var applications = db.LoanApplications
                .Where(a => a.ApplicantID == currentUserId)
                .Select(a => new LoanApplicationDTO
                {
                    ApplicationID = a.ApplicationID,
                    LoanAmount = (double)a.LoanAmount,
                    AppliedDate = a.AppliedDate,
                    DecisionDate = a.DecisionDate,
                    ApplicationStatus = a.ApplicationStatus,
                    ProductID = a.ProductID
                })
                .ToList();

            return View(applications);
        }

        public ActionResult ReviewApplications()
        {
            if (Session["userID"] == null || Session["username"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["Role"] != null && Session["Role"].ToString() != "Loan Officer")
            {
                return RedirectToAction("Login", "Home");
            }

            LoanManagementEntities db = new LoanManagementEntities();
            var applications = db.LoanApplications
                                 .Select(a => new LoanApplicationDTO
                                 {
                                     ApplicationID = a.ApplicationID,
                                     LoanAmount = a.LoanAmount,
                                     AppliedDate = a.AppliedDate,
                                     DecisionDate = a.DecisionDate,
                                     ApplicationStatus = a.ApplicationStatus,
                                     ApplicantID = a.ApplicantID,
                                     ProductID = a.ProductID
                                 })
                                 .ToList();

            return View(applications);
        }
        public ActionResult ApproveApplication(int applicationID)
        {
            LoanManagementEntities db = new LoanManagementEntities();
            var application = db.LoanApplications.Find(applicationID);
            if (application != null)
            {
                application.ApplicationStatus = "Approved";
                application.DecisionDate = DateTime.Now; 
                db.SaveChanges();
            }
            TempData["Msg"] = "Approved";
            return RedirectToAction("ReviewApplications"); 
        }

        public ActionResult RejectApplication(int applicationID)
        {
            LoanManagementEntities db = new LoanManagementEntities();
            var application = db.LoanApplications.Find(applicationID);
            if (application != null)
            {
                application.ApplicationStatus = "Rejected";
                application.DecisionDate = DateTime.Now;
                db.SaveChanges();
            }

            TempData["Msg"] = "Rejected";
            return RedirectToAction("ReviewApplications");
        }



    }
}