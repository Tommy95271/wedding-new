using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjWedding.Areas.Backend.Models;

namespace prjWedding.Areas.Backend.ViewModels
{
    public class ManageViewModel
    {
        public List<MyEnum> folderName { get; set; }
        public List<tPhoto> tPhoto { get; set; }
    }
}