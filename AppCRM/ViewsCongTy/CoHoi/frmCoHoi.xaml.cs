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
    /// Interaction logic for frmCoHoi.xaml
    /// </summary>
    public partial class frmCoHoi : Page
    {
        //List<test> lst = new List<test>();
        public frmCoHoi()
        {
            InitializeComponent();
            //lst.Add(new test { TenCH = "Cơ hội", KhachHang = "Hoàng", GiaiDoan = "Đầu", NgayKV = "10/10/0000", SoTien = "50.000.000", NguoiTH = "Hoàng", NgayTao = "333" });
            //lst.Add(new test { TenCH = "ghh", KhachHang = "3333", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //lst.Add(new test { TenCH = "111", KhachHang = "222", GiaiDoan = "333", NgayKV = "333", SoTien = "333", NguoiTH = "333", NgayTao = "333" });
            //dgv.ItemsSource = lst;
            //txtTongSoDong.Text = lst.Count.ToString();
        }
        //public class test
        //{
        //    public string TenCH { get; set; }
        //    public string KhachHang { get; set; }
        //    public string GiaiDoan { get; set; }
        //    public string NgayKV { get; set; }
        //    public string SoTien { get; set; }
        //    public string NguoiTH { get; set; }
        //    public string NgayTao { get; set; }
        //}

        private void btnThemMoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
