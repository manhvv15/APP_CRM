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

namespace AppCRM
{
    /// <summary>
    /// Interaction logic for frmTrangChu2.xaml
    /// </summary>
    public partial class frmTrangChu2 : Window
    {
        public frmTrangChu2()
        {
            InitializeComponent();
        }

        private void btnKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.NhomKhachHang.frmNhomKhachHang frm = new Views.KhachHang.NhomKhachHang.frmNhomKhachHang();
            //frm.ShowDialog();
            //pnlHienThi.Children.Clear();

        }

        private void btnAnHienThanhMenu_Click(object sender, RoutedEventArgs e)
        {
            //if(pnlMenuDoc.Visibility == Visibility.Collapsed)
            //{
            //    pnlMenuDoc.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    pnlMenuDoc.Visibility = Visibility.Collapsed;
            //}
        }

        private void btnTrangChu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmTrangChu2 frm = new frmTrangChu2();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnTest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.TinhTrangKhachHang.frmTinhTrangKhachHang frm = new Views.KhachHang.TinhTrangKhachHang.frmTinhTrangKhachHang(null, null);
            //pnlHienThi2.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi2.Children.Add(content as UIElement);
        }

        private void btnDSNKH_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDSNKH.Foreground = Brushes.YellowGreen;
        }

        private void btnDSNKH_MouseLeave(object sender, MouseEventArgs e)
        {
            btnDSNKH.Foreground = Brushes.White;
        }

        private void btnDanhSachKH_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDanhSachKH.Foreground = Brushes.YellowGreen;
        }

        private void btnDanhSachKH_MouseLeave(object sender, MouseEventArgs e)
        {
            btnDanhSachKH.Foreground = Brushes.White;
        }

        private void btnDSNKH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.NhomKhachHang.frmNhomKhachHang frm = new Views.KhachHang.NhomKhachHang.frmNhomKhachHang();
            //pnlHienThi2.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi2.Children.Add(content as UIElement);
        }

        private void btnDanhSachKH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.DanhSachKhachHang.frmCustomer frm = new Views.KhachHang.DanhSachKhachHang.frmCustomer(null, null,null, null, null, null, null,null,null,null,null,null,null, null, null, null);
            //pnlHienThi2.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi2.Children.Add(content as UIElement);
        }

        private void btnDangNhap_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDangNhap.Foreground = Brushes.YellowGreen;
        }

        private void btnDangNhap_MouseLeave(object sender, MouseEventArgs e)
        {
            btnDangNhap.Foreground = Brushes.White;
        }

        private void btnMatKhau_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMatKhau.Foreground = Brushes.YellowGreen;
        }

        private void btnMatKhau_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMatKhau.Foreground = Brushes.White;
        }

        private void btnTest_MouseLeave(object sender, MouseEventArgs e)
        {
            btnTest.Foreground = Brushes.White;
        }

        private void btnTest_MouseEnter(object sender, MouseEventArgs e)
        {
            btnTest.Foreground = Brushes.YellowGreen;
        }

        private void btnDangNhap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            Login.MainWindow frm = new Login.MainWindow();
            frm.Show();
            //pnlHienThi2.Height = 300;
            //pnlHienThi2.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi2.Children.Add(content as UIElement);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
