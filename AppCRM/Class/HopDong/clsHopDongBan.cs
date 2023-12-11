using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Class.HopDong
{
    public class clsHopDongBan
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Datum
        {
            public string stt { get; set; }
            public string id { get; set; }
            public string id_customer { get; set; }
            public string user_created { get; set; }
            public string id_form_contract { get; set; }
            public string status { get; set; }
            public string emp_id { get; set; }
            public string comp_id { get; set; }
            public string path_download { get; set; }
            public string is_delete { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string id_form { get; set; }
            public string name { get; set; }
            public string id_file { get; set; }
            public string text_new { get; set; }
            public string text_old { get; set; }
            public string text_index { get; set; }
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
