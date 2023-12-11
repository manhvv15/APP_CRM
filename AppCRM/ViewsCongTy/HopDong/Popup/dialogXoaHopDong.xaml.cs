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

namespace AppCRM.Views.HopDong.Popup
{
    /// <summary>
    /// Interaction logic for dialogXoaHopDong.xaml
    /// </summary>
    public partial class dialogXoaHopDong : UserControl
    {
        private string IdHD = "";
        private PageDSHopDong frmDSHD;
        public dialogXoaHopDong(string IdHopDong, PageDSHopDong page)
        {
            InitializeComponent();
            IdHD = IdHopDong;
            frmDSHD = page;
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
                httpClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                httpClient.QueryString.Add("id", IdHD);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteContract"), "POST", httpClient.QueryString);
            }
            frmDSHD.LoadDLHopDong();
            this.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
