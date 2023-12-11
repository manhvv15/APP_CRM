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

namespace AppCRM.Views.ChamSocKhachHang.LichChamSocKhachHang
{
    /// <summary>
    /// Interaction logic for frmLichChamSocKH.xaml
    /// </summary>
    public partial class frmLichChamSocKH : Window
    {
        //List<test> lst = new List<test>();
        public frmLichChamSocKH()
        {
            InitializeComponent();
            //lst.Add(new test { TenLichChamSoc = "1", NguoiTao = "Đỗ Văn Hoàng hoàng hoàng", TongKhachHang = "Đầu", TongChamSoc = "10/10/0000" });
            //lst.Add(new test { TenLichChamSoc = "3", NguoiTao = "Hoàng", TongKhachHang = "Đầu", TongChamSoc = "10/10/0000" });
            //lst.Add(new test { TenLichChamSoc = "4", NguoiTao = "Hoàng", TongKhachHang = "Đầu", TongChamSoc = "10/10/0000" });
            //lst.Add(new test { TenLichChamSoc = "5", NguoiTao = "Hoàng", TongKhachHang = "Đầu", TongChamSoc = "10/10/0000" });
            //dgv.ItemsSource = lst;
        }
        //public class test
        //{
        //    public string TenLichChamSoc { get; set; }
        //    public string NguoiTao { get; set; }
        //    public string TongKhachHang { get; set; }
        //    public string TongChamSoc { get; set; }
        //    public string ChucNang { get; set; }
            
        //}

        private void textTenLichChamSoc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmChiTietLichChamSocKhachHang frm = new frmChiTietLichChamSocKhachHang();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnThemMoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemLichChamSocKH frm = new frmThemLichChamSocKH();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
