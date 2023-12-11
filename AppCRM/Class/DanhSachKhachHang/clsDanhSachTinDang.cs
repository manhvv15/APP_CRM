using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    public class clsDanhSachTinDang
    {
        public class Datum
        {
            public string stt { get; set; }
            public string id { get; set; }
            public string com_id { get; set; }
            public string cus_id { get; set; }
            public string id_new { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string link { get; set; }
            public string resoure { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
            public int total { get; set; }
        }
    }
}
