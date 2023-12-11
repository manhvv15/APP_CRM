using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Class
{
    public class clsNhanVienThuocCongTy
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public bool result { get; set; }
            public string message { get; set; }
            public string com_id { get; set; }
            public string com_name { get; set; }
            public List<UserInfo> user_info { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
            public object error { get; set; }
        }

        public class UserInfo
        {
            public string ep_id { get; set; }
            public string ep_email { get; set; }
            public string ep_name { get; set; }
            public string ep_phone { get; set; }
            public string ep_image { get; set; }
            public string ep_address { get; set; }
            public string ep_education { get; set; }
            public string ep_exp { get; set; }
            public string ep_birth_day { get; set; }
            public string ep_married { get; set; }
            public string ep_gender { get; set; }
            public string role_id { get; set; }
            public string position_id { get; set; }
            public string ep_status { get; set; }
            public string update_time { get; set; }
            public string allow_update_face { get; set; }
            public string com_id { get; set; }
            public string com_name { get; set; }
            public string com_logo { get; set; }
            public string dep_id { get; set; }
            public string dep_name { get; set; }
            public string create_time { get; set; }
            public string group_id { get; set; }
        }


    }
}
