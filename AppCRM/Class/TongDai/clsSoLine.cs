using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    public class clsSoLine
    {
        public class Datum
        {
            public string stt { get; set; }
            public string extension_number { get; set; }
            public string emp_id { get; set; }
            public string emp_name { get; set; }
            public string status { get; set; }
            public string password { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }

    }
}
