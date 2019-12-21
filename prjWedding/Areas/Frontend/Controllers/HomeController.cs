using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWedding.Areas.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Price()
        {
            return View();
        }
        public ActionResult Other_Services()
        {
            return View();
        }
        public ActionResult Photo()
        {
            return View();
        }
    }
}
