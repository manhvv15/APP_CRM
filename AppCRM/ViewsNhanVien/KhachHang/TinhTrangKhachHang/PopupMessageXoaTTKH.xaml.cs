using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AppCRM.Views.KhachHang.TinhTrangKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for PopupMessageXoaTTKHNhanVien.xaml
    /// </summary>
    public partial class PopupMessageXoaTTKHNhanVien : UserControl
    {
        private string MaTinhTrang = "";
        private Model.APIEntity.DataLogin_Employee dt;
        private frmTinhTrangKhachHangNhanVien frmTT;
        public PopupMessageXoaTTKHNhanVien(frmTinhTrangKhachHangNhanVien frm, string MaTT, Model.APIEntity.DataLogin_Employee data)
        {
            InitializeComponent();
            frmTT = frm;
            MaTinhTrang = MaTT;
            dt = data;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", dt.token);
                httpClient.QueryString.Add("id", MaTinhTrang);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteStatusCustomer"), "POST", httpClient.QueryString);
            }
            this.Visibility = Visibility.Collapsed;
            frmTT.LoadLaiDanhSachTinhTrangKhachHang();
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
