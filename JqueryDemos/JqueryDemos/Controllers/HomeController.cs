using System;  
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryDemos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        public ActionResult IndexTraversing()
        {
            return View();
        }
        public ActionResult IndexTraversingNew()
        {
            return View();
        }
        public ActionResult MouseEvents()
        {
            return View();
        }
        public ActionResult Attributes()
        {
            return View();
        }
        public ActionResult Accordian()
        {
            return View();
        }
        public ActionResult Manupulation()
        {
            return View();
        }
    }
}
