using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang
{
    public class clsTinhThanh
    {
        public class Datum
        {
            public string cit_id { get; set; }
            public string cit_name { get; set; }
            public string cit_order { get; set; }
            public string cit_parent { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
