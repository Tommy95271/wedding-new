using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWedding.Areas.Frontend.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Other_Services()
        {
            return View();
        }
        public ActionResult Process()
        {
            return View();
        }
        public ActionResult Rent_Description()
        {
            return View();
        }
    }
}