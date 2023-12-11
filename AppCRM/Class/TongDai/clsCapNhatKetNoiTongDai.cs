using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    public class clsCapNhatKetNoiTongDai
    {
        public class Data
        {
            public string access_token_call { get; set; }
            public int set_time_api { get; set; }
            public int expires { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }

    }
}
