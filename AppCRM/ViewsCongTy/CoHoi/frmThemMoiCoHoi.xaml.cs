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

namespace AppCRM.Views.CoHoi
{
    /// <summary>
    /// Interaction logic for frmThemMoiCoHoi.xaml
    /// </summary>
    public partial class frmThemMoiCoHoi : Page
    {
        public frmThemMoiCoHoi()
        {
            InitializeComponent();
            List<HangHoa> lstHH = new List<HangHoa>();
            lstHH.Add(new HangHoa { STT = "1", MaHH = "hh1", TenHH = "22", DonVi = "33", SoLuong = "44", DonGia = "55", ThanhTien = "66", TyLeChietKhau = "77", TienChietKhau = "88", ThueXuat = "99", TienThue = "111", TongTien = "222", ChucNang = "3333" });
            lstHH.Add(new HangHoa { STT = "2", MaHH = "hh1", TenHH = "22", DonVi = "33", SoLuong = "44", DonGia = "55", ThanhTien = "66", TyLeChietKhau = "77", TienChietKhau = "88", ThueXuat = "99", TienThue = "111", TongTien = "222", ChucNang = "3333" });
            lstHH.Add(new HangHoa { STT = "3", MaHH = "hh1", TenHH = "22", DonVi = "33", SoLuong = "44", DonGia = "55", ThanhTien = "66", TyLeChietKhau = "77", TienChietKhau = "88", ThueXuat = "99", TienThue = "111", TongTien = "222", ChucNang = "3333" });
            lstHH.Add(new HangHoa { STT = "4", MaHH = "hh1", TenHH = "22", DonVi = "33", SoLuong = "44", DonGia = "55", ThanhTien = "66", TyLeChietKhau = "77", TienChietKhau = "88", ThueXuat = "99", TienThue = "111", TongTien = "222", ChucNang = "3333" });
            dgv.ItemsSource = lstHH;
        }
        public class HangHoa
        {
            public string STT { get; set; }
            public string MaHH { get; set; }
            public string TenHH { get; set; }
            public string DonVi { get; set; }
            public string SoLuong { get; set; }
            public string DonGia { get; set; }
            public string ThanhTien { get; set; }
            public string TyLeChietKhau { get; set; }
            public string TienChietKhau { get; set; }
            public string ThueXuat { get; set; }
            public string TienThue { get; set; }
            public string TongTien { get; set; }
            public string ChucNang { get; set; }
        }
    }
}
