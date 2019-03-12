using QuizAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class HomeController : Controller
    {

        [Route("sitemap.xml")]
        public ActionResult SitemapXml()
        {
            UrlSitenodes urlnodes = new UrlSitenodes();
            var sitemapNodes = urlnodes.GetSitemapNodes(this.Url);
            string xml = urlnodes.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, System.Net.Mime.MediaTypeNames.Text.Xml, Encoding.UTF8);
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Online Interview Tips-Mock Exams-Mock PSC-Bank-Job -General Knowledge Sample Questions";
            ViewBag.MetaDescription = "Handpicked interview questions and Free online interviews and Exam,PSC and Bank Test Samples and Mock Test,Study General Knowledge ";
            ViewBag.MetaKeywords = "Dummy ,Mock Interview,PSC Test Online,Mock PSC,Bank Test";


            return View();
            //return RedirectPermanent("~/Pages/index.html");
        }

        public ActionResult Test()
        {
            ViewBag.Title = "Home Page";


            return View();
            //return RedirectPermanent("~/Pages/index.html");
        }






    }
}
