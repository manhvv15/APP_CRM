using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.HopDong
{
    public class clsHopDong
    {
        public class Datum
        {
            public string stt { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string path_file { get; set; }
            public string com_id { get; set; }
            public string ep_id { get; set; }
            public string id_file { get; set; }
            public string is_delete { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string creator { get; set; }
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
