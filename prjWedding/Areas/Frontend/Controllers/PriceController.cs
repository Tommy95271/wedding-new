using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWedding.Areas.Frontend.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        public ActionResult Price()
        {
            return View();
        }
        public ActionResult Secretary_Price()
        {
            return View();
        }
        public ActionResult Photo_Price()
        {
            return View();
        }
    }
}