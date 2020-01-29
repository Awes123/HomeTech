using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechVibes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string Contact(string name, int number, string mail, string msg)
        {
            string rtnmsg = "hello";

            return rtnmsg;
        }
    }

}