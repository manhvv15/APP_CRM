using AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang;
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

namespace AppCRM.ViewsCongTy.KhachHang.DanhSachKhachHang.ChiTietKhachHang.Popup
{
    /// <summary>
    /// Interaction logic for PopUpXoaHopDong.xaml
    /// </summary>
    public partial class PopUpXoaHopDong : UserControl
    {
        private string IdHopDong = "";
        private Model.APIEntity.DataLogin_Company data;
        private frmHopDongBan frmHD;
        private string IdKhachHang = "";
        public PopUpXoaHopDong(string IdHD, Model.APIEntity.DataLogin_Company dt, frmHopDongBan frm, string IdKH)
        {
            InitializeComponent();
            IdHopDong = IdHD;
            data = dt;
            frmHD = frm;
            IdKhachHang = IdKH;
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", data.token);
                httpClient.QueryString.Add("contractId", IdHopDong);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteContractCus"), "POST", httpClient.QueryString);
            }
            frmHD.LoadDLHopDongBan(IdKhachHang);
            this.Visibility = Visibility.Collapsed;

        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
