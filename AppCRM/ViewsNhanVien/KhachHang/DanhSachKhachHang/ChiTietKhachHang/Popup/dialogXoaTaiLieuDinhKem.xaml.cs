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

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien.ChiTietKhachHangNhanVien.Popup
{
    /// <summary>
    /// Interaction logic for dialogXoaTaiLieuDinhKemNhanVien.xaml
    /// </summary>
    public partial class dialogXoaTaiLieuDinhKemNhanVien : UserControl
    {
        private string IdFileTaiLieu = "";
        private Model.APIEntity.DataLogin_Employee data;
        private frmTaiLieuDinhKemNhanVien frmTL;
        public dialogXoaTaiLieuDinhKemNhanVien(frmTaiLieuDinhKemNhanVien frm, string IdFile, string TenFile, Model.APIEntity.DataLogin_Employee dt)
        {
            InitializeComponent();
            data = dt;
            frmTL = frm;
            textTenTaiLieu.Text = "Bạn có chắc chắn muốn xoá tài liệu đính kèm " + TenFile + " không?";
            IdFileTaiLieu = IdFile;
        }
        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                httpClient.QueryString.Add("fileId", IdFileTaiLieu);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteFileCus"), "POST", httpClient.QueryString);
            }
            this.Visibility = Visibility.Collapsed;
            frmTL.LoadDLTaiLieuDinhKem();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
