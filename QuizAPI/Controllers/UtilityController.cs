using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class UtilityController : Controller
    {
        // GET: Utility
        public ActionResult Index()
        {
            return View();
        }
        [Route("Utility/PassWordStrengthCheck")]
        [Route("Password-strength-Analyzer")]
        public ActionResult PassWordStrengthCheck()
        {
            ViewBag.Title = "Password strength Analyzer";
            ViewBag.MetaDescription = "Check the strength of your password and whether hackers can hack it easily:Check facebook gmail,twitter or any password strenth";
            ViewBag.MetaKeywords = "Password Strong,Strength of password,Password Strenth checker,Weak Password";
            return View();
        }
    }
}