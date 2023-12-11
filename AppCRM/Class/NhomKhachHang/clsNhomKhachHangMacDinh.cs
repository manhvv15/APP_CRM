using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.NhomKhachHang
{
    public class clsNhomKhachHangMacDinh
    {
        public class Datum
        {
            public string gr_id { get; set; }
            public string gr_name { get; set; }
            public string gr_description { get; set; }
            public string group_parent { get; set; }
            public string company_id { get; set; }
            public string dep_id { get; set; }
            public string emp_id { get; set; }
            public string count_customer { get; set; }
            public string is_delete { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
