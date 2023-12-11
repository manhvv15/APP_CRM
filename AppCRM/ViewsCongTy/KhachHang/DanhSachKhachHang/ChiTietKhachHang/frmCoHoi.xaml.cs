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
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmCoHoi.xaml
    /// </summary>
    public partial class frmCoHoi : Page
    {
        //List<test> lst = new List<test>();
        public frmCoHoi()
        {
            InitializeComponent();
            //lst.Add(new test {STT="1", TenCH = "Cơ hội", GiaiDoan = "Đầu", NgayKV = "10/10/0000", SoTien = "50.000.000", NguoiTH = "Hoàng",TyLeThanhCong="66",DoanhSoKyVong="77"});
            //lst.Add(new test { STT = "2", TenCH = "ghh", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", TyLeThanhCong = "66", DoanhSoKyVong = "77" });
            //lst.Add(new test { STT = "3", TenCH = "111", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", TyLeThanhCong = "66", DoanhSoKyVong = "77" });
            //lst.Add(new test { STT = "4", TenCH = "111", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", TyLeThanhCong = "66", DoanhSoKyVong = "77" });
            //dgv.ItemsSource = lst;
            //txtTongSoDong.Text = lst.Count.ToString();

        }
        //public class test
        //{
        //    public string STT { get; set; }
        //    public string TenCH { get; set; }
        //    public string GiaiDoan { get; set; }
        //    public string TyLeThanhCong { get; set; }
        //    public string DoanhSoKyVong { get; set; }
        //    public string NgayKV { get; set; }
        //    public string SoTien { get; set; }
        //    public string NguoiTH { get; set; }
           
        //}

        private void btnThemMoiCoHoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemMoiCoHoi frm = new frmThemMoiCoHoi();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

    }
}
