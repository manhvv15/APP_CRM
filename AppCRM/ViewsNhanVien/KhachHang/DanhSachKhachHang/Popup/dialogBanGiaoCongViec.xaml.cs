using RestSharp;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien.Popup
{
    /// <summary>
    /// Interaction logic for dialogBanGiaoCongViec.xaml
    /// </summary>
    public partial class dialogBanGiaoCongViec : UserControl
    {
        private string IdKH = "";
        private string IdNhanVienPhuTrach = "";
        private frmCustomerNhanVien frmKH;
        private Model.APIEntity.DataLogin_Employee data;
        public dialogBanGiaoCongViec(frmCustomerNhanVien frm,Model.APIEntity.DataLogin_Employee dt, List<NhomKhachHang.clsNhanVien.Item> lstNhanVien, string IdNhanVienPT, string IdKhachHang)
        {
            InitializeComponent();
            IdKH = IdKhachHang;
            frmKH = frm;
            data = dt;
            foreach (NhomKhachHang.clsNhanVien.Item nhanvien in lstNhanVien)
            {
                cboNguoiNhanCV.Items.Add(nhanvien.ep_id + "-" + nhanvien.ep_name + "-" + nhanvien.dep_name);
            }
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
            using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/handingOverWork")))
            {
                try
                {
                    RestRequest request = new RestRequest();
                    request.Method = Method.Post;
                    request.AlwaysMultipartFormData = true;
                    request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                    request.AddParameter("listIdCustomer", IdKH);
                    request.AddParameter("type", "1");
                    string[] NhanVien = cboNguoiNhanCV.Text.Split(Convert.ToChar("-"));
                    string IdNhanVienNhanViec = NhanVien[0];
                    request.AddParameter("empWork", IdNhanVienNhanViec);
                    RestResponse resAlbum = restclient.Execute(request);
                    var b = resAlbum.Content;
                    this.Visibility = Visibility.Collapsed;
                    frmKH.LoadLaiDuLieuKhachHang(data);
                }
                catch
                {
                }
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
