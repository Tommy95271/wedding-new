using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWedding.Areas.Backend.Models;
using PagedList;

namespace prjWedding.Areas.Backend.Controllers
{
    public class ManageController : Controller
    {
        dbWeddingDressEntities db = new dbWeddingDressEntities();
        // GET: Backend/Manage
        private int pageSize = 6;
        public ActionResult Manage(int page =1)
        {
            int currentPage = (page < 1) ? 1 : page;
            var allPhotos = db.tPhoto.OrderBy(m => m.Date);
            var result = allPhotos.ToPagedList(currentPage,pageSize);
            if(Session["Member"] == null)
            {
                //重新導回 Login頁面
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //登入狀態
                //顯示Create
                return View(result);
            }
        }

        public ActionResult Order()
        {
            if(Session["Member"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return Redirect("https://docs.google.com/forms/d/13amuu6O1K07qU28FoaRsH0lH-DgxSYKbKbsVjAlaC0I/edit#responses");
        }
        public ActionResult Order_Detail()
        {
            if(Session["Member"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return Redirect("https://docs.google.com/spreadsheets/d/1VQ2ghiW7D3TV-9WUwJFGwJsjm5Ij-x2-msOF5JmzBmA/edit#gid=2138248164");
        }
    }
}