using AppCRM.Class.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.HopDong
{
    public class clsTruongThayDoi
    {
        public class Data
        {
            public string IdTruong { get; set; }
            public string TenTruong { get; set; }
            public string TuTK { get; set; }
            public string ViTriThayDoi { get; set; }
            public List<clsViTri> lstViTri { get; set; }
            public string TruongMacDinh { get; set; }
        }
    }
}
