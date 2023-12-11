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

namespace AppCRM.Views.KhachHang.TinhTrangKhachHang
{
    /// <summary>
    /// Interaction logic for frmMessageXoaTTKH.xaml
    /// </summary>
    public partial class frmMessageXoaTTKH : Window
    {
        private string MaTinhTrang = "";
        public frmMessageXoaTTKH(string MaTT)
        {
            InitializeComponent();
            MaTinhTrang = MaTT;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                httpClient.QueryString.Add("id", MaTinhTrang);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteStatusCustomer"), "POST", httpClient.QueryString);
            }
            this.Close();
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
