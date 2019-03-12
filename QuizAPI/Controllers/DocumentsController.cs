using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        public ActionResult Index()
        {
            return View();
        }
        [Route("Documents/UaeEquivalancyCertificate")]
        [Route("Uae-Certificate-of-Equivalancy")]
        // GET: Documents/UaeEquivalancyCertificate
        public ActionResult UaeEquivalancyCertificate()
        {
            ViewBag.Title = "UAE Certificate of Equivalency and Genuinity Certificate";
            ViewBag.MetaDescription = "Step By step description of how to obtain equivalency certificate for indians in UAE and also cover Genuinity Certificate ,";
            ViewBag.MetaKeywords = "Genuinity Certificate , Equivalency Certificate, UAE,Indians,Embassy,plus two/Higher secondary certificate,Arabic Transalation,IVS global";
            return View();
        }
    }
}