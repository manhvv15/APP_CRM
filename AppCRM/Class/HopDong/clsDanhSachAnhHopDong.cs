using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.HopDong
{
    public class clsDanhSachAnhHopDong
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class DataDanhSachAnhHopDong
        {
            public List<string> lists_image { get; set; }
            public string id_file { get; set; }
            public string path { get; set; }
        }

        public class RootDanhSachAnhHopDong
        {
            public bool result { get; set; }
            public string message { get; set; }
            public DataDanhSachAnhHopDong data { get; set; }
        }


    }
}
