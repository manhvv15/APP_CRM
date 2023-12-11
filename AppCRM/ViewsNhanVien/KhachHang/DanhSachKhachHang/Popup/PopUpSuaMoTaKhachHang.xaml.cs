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

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien.Popup
{
    /// <summary>
    /// Interaction logic for PopUpSuaMoTaKhachHang.xaml
    /// </summary>
    public partial class PopUpSuaMoTaKhachHang : UserControl
    {
        private string MaKhachHang = "";
        private string MoTaKH = "";
        private Model.APIEntity.DataLogin_Employee data;
        private frmCustomerNhanVien frmKH;
        public PopUpSuaMoTaKhachHang(frmCustomerNhanVien frm, string MaKH, string MoTa, Model.APIEntity.DataLogin_Employee dt)
        {
            InitializeComponent();
            MaKhachHang = MaKH;
            tbMoTa.Text = MoTa;
            data = dt;
            frmKH = frm;
        }
        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                try
                {
                    httpClient.Headers.Add("Authorization", data.token);
                    httpClient.QueryString.Add("id", MaKhachHang);
                    httpClient.QueryString.Add("description", tbMoTa.Text);

                    //httpClient.QueryString.Add("listIdDep", null);
                    //httpClient.QueryString.Add("listIdEpl", null);

                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {
                        this.Visibility = Visibility.Collapsed;
                        frmKH.LoadDataKhachHang(data);
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateDescustomerList"), "POST", httpClient.QueryString);
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
