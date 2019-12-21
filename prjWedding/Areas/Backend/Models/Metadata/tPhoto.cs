using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjWedding.Areas.Backend.Models
{
    [MetadataType(typeof(tPhoto_Metadata))]
    public partial class tPhoto
    {
        public partial class tPhoto_Metadata
        {
            public int Id { get; set; }

            [DisplayName("相片名稱")]
            public string Image { get; set; }

            [DisplayName("相片描述")]
            public string Description { get; set; }

            [DisplayName("資料夾名稱")]
            public string FolderName { get; set; }

            [DisplayName("原始路徑")]
            public string OriginalPath { get; set; }

            [DisplayName("更改路徑")]
            public string Path { get; set; }

            [DisplayName("相片類型")]
            public string Type { get; set; }

            [DisplayName("相片日期")]
            public DateTime Date { get; set; }
        }
    }
}