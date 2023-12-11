using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang
{
    public class clsKhachHang
    {
        public class KhachHang
        {
            public string cus_id { get; set; }
            public string email { get; set; }
            public string name { get; set; }
            public string phone_number { get; set; }
            public string resoure { get; set; }
            public List<string> DanhSachNguonKH { get; set; }
            public string birthday { get; set; }
            public string status { get; set; }
            public List<string> DanhSachTinhTrang { get; set; }
            public string description { get; set; }
            public string group_id { get; set; }
            public List<string> DanhSachNhomKH { get; set; }
            public string emp_id { get; set; }
            public string company_id { get; set; }
            public string is_delete { get; set; }
            public string type { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object cus_from { get; set; }
            public string user_handing_over_work { get; set; }
            public string user_create_id { get; set; }
            public string linhvuc { get; set; }
            public object link { get; set; }
            public string count_call { get; set; }
            public List<string> lstNoiDungLichSuChamSoc { get; set; }
        }
        
        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<KhachHang> data { get; set; }
            public int total { get; set; }
        }
    }
}
