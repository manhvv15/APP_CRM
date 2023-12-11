using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Class.HopDong
{
    public class clsChiTietHopDong
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public List<string> img_org_base64 { get; set; }
            public List<DetailFormContract> detail_form_contract { get; set; }
            public string path { get; set; }
        }

        public class DetailFormContract
        {
            public string id { get; set; }
            public string name { get; set; }
            public string path_file { get; set; }
            public string com_id { get; set; }
            public string ep_id { get; set; }
            public string id_file { get; set; }
            public string is_delete { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string id_form_contract { get; set; }
            public string new_field { get; set; }
            public string old_field { get; set; }
            public string index_field { get; set; }
            public string default_field { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }


    }
}
