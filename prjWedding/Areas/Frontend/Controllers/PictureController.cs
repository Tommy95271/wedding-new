using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWedding.Areas.Backend.Models;
using PagedList;

namespace prjWedding.Areas.Frontend.Controllers
{
    public class PictureController : Controller
    {
        dbWeddingDressEntities db = new dbWeddingDressEntities();
        private int pageSize = 6;
        public ActionResult Photos(int page = 1)
        {
            var currentPage = (page < 1) ? 1 : page;
            var photo = db.tPhoto.Where(m => m.FolderName == "Photo").OrderBy(m => m.Id);
            var result = photo.ToPagedList(currentPage, pageSize);
            return View(result);
        }

        public ActionResult Wedding_Dress(int page =1)
        {
            var currentPage = (page < 1) ? 1 : page;
            var WD = db.tPhoto.Where(m => m.FolderName == "WD").OrderBy(m => m.Id);
            var result = WD.ToPagedList(currentPage, pageSize);
            return View(result);
        }
        public ActionResult Indoor_Filming(int page =1)
        {
            var currentPage = (page < 1) ? 1 : page;
            var IF = db.tPhoto.Where(m => m.FolderName == "IF").OrderBy(m => m.Id);
            var result = IF.ToPagedList(currentPage, pageSize);
            return View(result);
        }
    }
}