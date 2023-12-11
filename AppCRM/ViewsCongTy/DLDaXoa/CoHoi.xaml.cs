using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCRM.Views.DLDaXoa
{
    /// <summary>
    /// Interaction logic for CoHoi.xaml
    /// </summary>
    public partial class CoHoi : Page
    {
        public CoHoi()
        {
            this.DataContext = this;
            InitializeComponent();
            List<test> lst = new List<test>();
            lst.Add(new test { TenCH="111",KhachHang="222",GiaiDoan="333", NgayKV = "333" , SoTien = "333" , NguoiTH = "333" , NgayTao = "333" });
            lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            datagrid1.Items.Add(lst);
        }
        public class test
        {
            public string TenCH { get; set; }
            public string KhachHang { get; set; }
            public string GiaiDoan { get; set; }
            public string NgayKV { get; set; }
            public string SoTien { get; set; }
            public string NguoiTH { get; set; }
            public string NgayTao { get; set; }
        }
        //public List<string> LayDuLieu { get; set; } = new List<string>()
        //{
        //    "1111111111","2222222222222","3333333333","444444444444","5","6","6"
        //    "1111111111","2222222222222","3333333333","444444444444","5","6","6"
        //};
    }
}
