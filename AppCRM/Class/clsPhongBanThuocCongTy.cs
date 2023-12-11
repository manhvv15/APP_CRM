using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Class
{
    public class clsPhongBanThuocCongTy
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public int itemsPerPage { get; set; }
            public string totalItems { get; set; }
            public List<Item> items { get; set; }
        }

        public class Item
        {
            public string dep_id { get; set; }
            public string com_id { get; set; }
            public string dep_name { get; set; }
            public string dep_create_time { get; set; }
            public List<object> manager { get; set; }
            public List<object> deputy { get; set; }
            public string total_emp { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
            public object error { get; set; }
        }


    }
}
