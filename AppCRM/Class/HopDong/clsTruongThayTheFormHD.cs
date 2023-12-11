using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Class.HopDong
{
    public class clsTruongThayTheFormHD
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public string id_file { get; set; }
            public string path { get; set; }
            public List<List> lists { get; set; }
        }

        public class List
        {
            public string id { get; set; }
            public string id_form_contract { get; set; }
            public string index_field { get; set; }
            public string new_field { get; set; }
            public string old_field { get; set; }
            public string default_field { get; set; }
            public string tuthaythe { get; set; }
            public string trangthai { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }


    }
}
