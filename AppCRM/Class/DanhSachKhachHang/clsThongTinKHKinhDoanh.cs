using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    public class clsThongTinKHKinhDoanh
    {
        public class AppointmentContentCall
        {
            public string content_call { get; set; }
            public string created_at { get; set; }
        }

        public class Data
        {
            public Item item { get; set; }
            public List<AppointmentContentCall> appointment_content_call { get; set; }
        }

        public class Item
        {
            public string cus_id { get; set; }
            public string phone_number { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string description { get; set; }
            public string group_id { get; set; }
            public string status { get; set; }
            public string resoure { get; set; }
            public string emp_id { get; set; }
            public object role { get; set; }
            public string group_parent { get; set; }
            public List<object> lists_group_child { get; set; }
            public string start_date_schedule { get; set; }
            public string end_date_schedule { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }
    }
}
