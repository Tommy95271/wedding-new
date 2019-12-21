using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWedding.Areas.Backend.Models;

namespace prjWedding.Areas.Backend.Controllers
{
    public class LoginController : Controller
    {
        dbWeddingDressEntities db = new dbWeddingDressEntities();
        // GET: Backend/Login

        public ActionResult Login()
        {
            //若Session["Member"]不為空，表示登入
            if(Session["Member"] != null)
            {
                //進入 Create 頁面
                return RedirectToAction("Index","Admin");
            }
            else
            {
                //未登入狀態
                //顯示Login
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(string fUserName, string fPassword)
        {
            var admin = db.tAdmin.Where(m => m.UserName == fUserName && m.Password == fPassword).FirstOrDefault();
            if(admin == null)
            {
                ViewBag.Message = "帳號或密碼錯誤，登入失敗，請重新輸入...";
                return View();
            }
            Session["Welcome"] = admin.UserName + "歡迎登入";
            Session["Member"] = admin;
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session["Welcome"] = "歡迎下次再登入";
            return RedirectToAction("Login", "Login");
        }

    }
}