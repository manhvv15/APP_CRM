using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    public class clsLienHe
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Datum
        {
            public string stt { get; set; }
            public string contact_id { get; set; }
            public string id_customer { get; set; }
            public string middle_name { get; set; }
            public string name { get; set; }
            public string fullname { get; set; }
            public string vocative { get; set; }
            public string logo { get; set; }
            public string contact_type { get; set; }
            public string titles { get; set; }
            public string department { get; set; }
            public string office_phone { get; set; }
            public string office_email { get; set; }
            public string personal_phone { get; set; }
            public string personal_email { get; set; }
            public string social { get; set; }
            public string social_detail { get; set; }
            public string source { get; set; }
            public string country_contact { get; set; }
            public string city_contact { get; set; }
            public string district_contact { get; set; }
            public string ward_contact { get; set; }
            public string street_contact { get; set; }
            public string address_contact { get; set; }
            public string area_code_contact { get; set; }
            public string country_ship { get; set; }
            public string city_ship { get; set; }
            public string district_ship { get; set; }
            public string ward_ship { get; set; }
            public string street_ship { get; set; }
            public string address_ship { get; set; }
            public string area_code_ship { get; set; }
            public string description { get; set; }
            public string share_all { get; set; }
            public string accept_phone { get; set; }
            public string accept_email { get; set; }
            public string user_create_id { get; set; }
            public string user_create_type { get; set; }
            public string user_edit_id { get; set; }
            public string user_edit_type { get; set; }
            public string is_delete { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string facebook { get; set; }
            public string zalo { get; set; }
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
