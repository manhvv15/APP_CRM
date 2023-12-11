using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Class
{
    public class clsNhanVienThuocPhongBan
    {
        private string m_TenNhanVien = "";
        private string m_PhongBan = "";

        public string TenNhanVien { get => m_TenNhanVien; set => m_TenNhanVien = value; }
        public string PhongBan { get => m_PhongBan; set => m_PhongBan = value; }
    }
}
