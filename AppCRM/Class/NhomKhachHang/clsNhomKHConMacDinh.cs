using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.NhomKhachHang
{
    public class clsNhomKHConMacDinh
    {
        public class Datum
        {
            public string gr_id { get; set; }
            public string gr_name { get; set; }
            public string group_parent { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
