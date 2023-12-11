using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    public class clsThongTinLienHe
    {
        public class AddressContact
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class AddressShip
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class AreaCodeContact
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class AreaCodeShip
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class CityContact
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class CityShip
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class ContactType
        {
            public string info { get; set; }
            public List<string> detail { get; set; }
        }

        public class Data
        {
            public string contact_id { get; set; }
            public string id_customer { get; set; }
            public MiddleName middle_name { get; set; }
            public string name { get; set; }
            public string fullname { get; set; }
            public Vocative vocative { get; set; }
            public string logo { get; set; }
            public ContactType contact_type { get; set; }
            public Titles titles { get; set; }
            public Department department { get; set; }
            public OfficePhone office_phone { get; set; }
            public OfficeEmail office_email { get; set; }
            public PersonalPhone personal_phone { get; set; }
            public PersonalEmail personal_email { get; set; }
            public Social social { get; set; }
            public string social_detail { get; set; }
            public Source source { get; set; }
            public string country_contact { get; set; }
            public CityContact city_contact { get; set; }
            public DistrictContact district_contact { get; set; }
            public WardContact ward_contact { get; set; }
            public StreetContact street_contact { get; set; }
            public AddressContact address_contact { get; set; }
            public AreaCodeContact area_code_contact { get; set; }
            public string country_ship { get; set; }
            public CityShip city_ship { get; set; }
            public DistrictShip district_ship { get; set; }
            public WardShip ward_ship { get; set; }
            public StreetShip street_ship { get; set; }
            public AddressShip address_ship { get; set; }
            public AreaCodeShip area_code_ship { get; set; }
            public Description description { get; set; }
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
            public string Zalo { get; set; }
            public string Facebook { get; set; }
            public string user_create_name { get; set; }
            public string user_edit_name { get; set; }
        }

        public class Department
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class Description
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class DistrictContact
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class DistrictShip
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class MiddleName
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class OfficeEmail
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class OfficePhone
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class PersonalEmail
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class PersonalPhone
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }

        public class Social
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class Source
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class StreetContact
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class StreetShip
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class Titles
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class Vocative
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class WardContact
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

        public class WardShip
        {
            public string info { get; set; }
            public string detail { get; set; }
        }

    }
}
