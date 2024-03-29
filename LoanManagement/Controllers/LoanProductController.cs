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

        public ActionResult ManageLoanProducts()
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

            LoanManagementEntities db = new LoanManagementEntities();
            var loanProducts = db.LoanProducts.ToList();
            return View(loanProducts);
        }
        public ActionResult CreateLoanProduct()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoanProduct(LoanProductDTO dto)
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

            LoanManagementEntities db = new LoanManagementEntities();
            if (ModelState.IsValid)
            {
                var loanProduct = new LoanProduct
                {
                    ProductName = dto.ProductName,
                    InterestRate = dto.InterestRate,
                    TermMonths = dto.TermMonths,
                    EligibilityCriteria = dto.EligibilityCriteria
                };

                db.LoanProducts.Add(loanProduct);
                db.SaveChanges();
                TempData["Msg"] = "Created Succesfully";
                return RedirectToAction("ManageLoanProducts"); 
            }
            return View(dto);
        }
        [HttpGet]
        public ActionResult EditLoanProduct(int id)
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
            LoanManagementEntities db = new LoanManagementEntities();
            var loanProduct = db.LoanProducts.Find(id);
            if (loanProduct == null)
            {
                return HttpNotFound();
            }

            var loanProductDto = new LoanProductDTO
            {
                ProductID = loanProduct.ProductID,
                ProductName = loanProduct.ProductName,
                InterestRate = loanProduct.InterestRate,
                TermMonths = loanProduct.TermMonths,
                EligibilityCriteria = loanProduct.EligibilityCriteria
            };

            return View(loanProductDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLoanProduct(LoanProductDTO loanProductDto)
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

            LoanManagementEntities db = new LoanManagementEntities();
            if (ModelState.IsValid)
            {
                var loanProduct = db.LoanProducts.Find(loanProductDto.ProductID);
                if (loanProduct == null)
                {
                    return HttpNotFound();
                }

                loanProduct.ProductName = loanProductDto.ProductName;
                loanProduct.InterestRate = loanProductDto.InterestRate;
                loanProduct.TermMonths = loanProductDto.TermMonths;
                loanProduct.EligibilityCriteria = loanProductDto.EligibilityCriteria;

                db.SaveChanges();
                TempData["Msg"] = "Edited Succesfully";
                return RedirectToAction("ManageLoanProducts");
            }

            return View(loanProductDto);
        }
        [HttpGet]
        public ActionResult DeleteLoanProduct(int id)
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

            LoanManagementEntities db = new LoanManagementEntities();
            var loanProduct = db.LoanProducts.Find(id);
            if (loanProduct == null)
            {
                return HttpNotFound();
            }

            return View(loanProduct);
        }

        [HttpPost, ActionName("DeleteLoanProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

            LoanManagementEntities db = new LoanManagementEntities();
            var loanProduct = db.LoanProducts.Find(id);
            if (loanProduct != null)
            {
                db.LoanProducts.Remove(loanProduct);
                db.SaveChanges();
            }

            TempData["Msg"] = "Deleted Succesfully";
            return RedirectToAction("ManageLoanProducts");
        }

    }
}