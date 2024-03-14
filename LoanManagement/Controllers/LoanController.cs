using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class LoanController : Controller
    {
        // GET: LoanManager
        public ActionResult Index()
        {
            return View();
        }
    }
}