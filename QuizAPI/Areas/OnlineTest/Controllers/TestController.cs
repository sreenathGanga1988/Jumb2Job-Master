using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Areas.OnlineTest.Controllers
{
    public class TestController : Controller
    {
        // GET: OnlineTest/Test
        public ActionResult Index()
        {
            return View();
        }







        [Authorize]
        public ActionResult TestEngine()
        {
            return View();
        }



    }
}