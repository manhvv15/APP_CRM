using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    public class clsGhiAm
    {
        public class Item
        {
            public string id { get; set; }
            public string filename { get; set; }
            public string filepath { get; set; }
            public string caller { get; set; }
            public string callee { get; set; }
            public string start_time { get; set; }
            public string end_time { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
        }

        public class Root
        {
            public List<Item> items { get; set; }
        }

    }
}
