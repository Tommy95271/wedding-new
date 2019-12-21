using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWedding.Areas.Backend.Models;

namespace prjWedding.Areas.Backend.Controllers
{
    public class AdminController : Controller
    {
        dbWeddingDressEntities db = new dbWeddingDressEntities();
        
        // GET: Backend/Admin
        public ActionResult Index()
        {
            //若Session["Member"]為空，表示未登入
            if(Session["Member"] == null)
            {
                //重新導回 Login頁面
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //登入狀態
                //顯示Index
                return View();
            }
        }

        public ActionResult Create()
        {
            //若Session["Member"]為空，表示未登入
            if(Session["Member"] == null)
            {
                //重新導回 Login頁面
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //登入狀態
                //顯示Create
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photos, string folderName, string description)
        {
            string typeCheck = TypeCheck(folderName);              //判斷相片類型，呼叫TypeCheck方法
            Random random = new Random();                   //實作Random方法
            foreach(var photo in photos)
            {
                //如果photo有值且photo長度>0
                if(photo != null && photo.ContentLength > 0)
                {
                    int randomNum = random.Next(1000, 9999);              //定義一個變數，取得亂數值
                    var date = DateTime.Now;                //給日期
                    var fileName = Path.GetFileName(photo.FileName);        //傳回檔案名稱及副檔名
                    var path = Server.MapPath("~/Picture/" + folderName);      //傳回檔案的資料夾路徑
                    if(!Directory.Exists(path))             //確認資料夾是否存在，如果不存在，建一個
                    {
                        Directory.CreateDirectory(path);
                    }
                    var newName = string.Format("{0}{1}{2}"
                    , folderName
                    , randomNum.ToString()
                    , Path.GetExtension(fileName));         //定義一個變數，將傳進來的檔案重新命名
                    var newPath = Path.Combine(path, newName);           //合併完整路徑
                    photo.SaveAs(newPath);                    //儲存檔案內容
                    bool check = SaveData(newName, description, folderName, newPath, typeCheck, date);      //呼叫SaveData方法，在資料庫儲存新檔名、描述、資料夾名稱、路徑、日期
                    if(check)
                    {
                        ViewBag.check = "上傳成功";
                    }
                    else
                    {
                        ViewBag.check = "上傳失敗";
                    }
                }
            }
            return View();
        }

        public ActionResult Delete(int mId)
        {
            var photo = db.tPhoto.Where(m => m.Id == mId).FirstOrDefault();
            db.tPhoto.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Manage", "Manage");
        }

        public ActionResult Edit(int mId)
        {
            var photo = db.tPhoto.Where(m => m.Id == mId).FirstOrDefault();
            return View(photo);
        }

        [HttpPost]
        public ActionResult Edit(tPhoto postback)
        {
            if(ModelState.IsValid)
            {
                var photo = db.tPhoto.Where(m => m.Id == postback.Id).FirstOrDefault();
                photo.Image = postback.Image;
                photo.Description = postback.Description;
                photo.FolderName = postback.FolderName;
                photo.Path = postback.Path;
                photo.Type = postback.Type;
                MoveFile(photo.FolderName, postback.Image, photo.OriginalPath);
                photo.OriginalPath = postback.Path;
                db.SaveChanges();
                return RedirectToAction("Manage", "Manage");
            }
            else
            {
                return View(postback);
            }
        }

        #region Helper
        public bool SaveData(string dbImage, string dbDescription, string dbFolderName, string dbPath, string dbType, DateTime dbDate)
        {
            tPhoto photo = new tPhoto();
            photo.Image = dbImage;
            photo.Description = dbDescription;
            photo.FolderName = dbFolderName;
            photo.OriginalPath = dbPath;
            photo.Path = dbPath;
            photo.Type = dbType;
            photo.Date = dbDate;
            db.tPhoto.Add(photo);
            db.SaveChanges();
            if(photo == null)
            {
                return false;
            }
            return true;
        }

        public string TypeCheck(string type)         //確認相片類型
        {
            if(type == "IF")
                return "0";
            else if(type == "Photo")
                return "1";
            else if(type == "WD")
                return "2";
            else
                return "Wrong data";
        }

        public void MoveFile(string folderName, string Image, string originalFile)
        {
            string destinationFile = Server.MapPath("~/Picture/" + folderName + "/" + Image);
            // To move a file or folder to a new location:
            System.IO.File.Move(originalFile, destinationFile);
            // To move an entire directory. To programmatically modify or combine
            // path strings, use the System.IO.Path class.
        }
        #endregion
    }
}













//給日期
//var date = DateTime.Now;
//描述
//var des = "Good";
//var type = 1;
//合併完整路徑
//path = Path.Combine(path, newName);
//Sql 取得連線字串
//string mainconn = ConfigurationManager.ConnectionStrings["dbWeddingDressEntities"].ConnectionString;
//Sql 連接資料庫
//SqlConnection sqlconn = new SqlConnection(mainconn);
//要對資料庫執行的動作
//SqlCommand sqlcomm = new SqlCommand("Insert", sqlconn);
//執行動作的類別
//sqlcomm.CommandType = CommandType.StoredProcedure;
//資料庫開啟
//sqlconn.Open();
//傳回值到資料庫
//sqlcomm.Parameters.AddWithValue("@Image", newName);
//sqlcomm.Parameters.AddWithValue("@Description", des);
//sqlcomm.Parameters.AddWithValue("@Path", path);
//sqlcomm.Parameters.AddWithValue("@Type", type);
//sqlcomm.Parameters.AddWithValue("@Date", date);
//執行SQL語法的動作
//sqlcomm.ExecuteNonQuery();
//關閉資料庫
//sqlconn.Close();
