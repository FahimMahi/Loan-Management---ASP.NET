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
        public ActionResult List() {
            var db = new LoanManagementEntities();
            var users = (from u in db.Users
                         select u).ToList();
            return View(users);
        }
    }
}