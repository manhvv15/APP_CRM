using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang
{
    public class clsPhuongXa
    {
        public class Datum
        {
            public string ward_id { get; set; }
            public string ward_name { get; set; }
            public string district_id { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
