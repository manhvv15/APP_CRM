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
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien.Popup
{
    /// <summary>
    /// Interaction logic for dialogSuaMoTaKhachHang.xaml
    /// </summary>
    public partial class dialogSuaMoTaKhachHang : Window
    {
        private string MaKhachHang = "";
        private string MoTaKH = "";
        private Model.APIEntity.DataLogin_Employee data;
        public dialogSuaMoTaKhachHang(string MaKH, string MoTa, Model.APIEntity.DataLogin_Employee dt)
        {
            InitializeComponent();
            MaKhachHang = MaKH;
            tbMoTa.Text = MoTa;
            data = dt;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
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
                        this.Close();
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateDescustomerList"), "POST", httpClient.QueryString);
                }
                catch
                {
                }
            }
            DialogResult = true;
        }
    }
}
