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
    /// Interaction logic for dialogXoaHopDongNhanVien.xaml
    /// </summary>
    public partial class dialogXoaHopDongNhanVien : UserControl
    {
        private string IdHD = "";
        private Model.APIEntity.DataLogin_Employee data;
        private PageDSHopDongNhanVien frmDSHD;
        public dialogXoaHopDongNhanVien(string IdHopDong, Model.APIEntity.DataLogin_Employee dt, PageDSHopDongNhanVien DSHD)
        {
            InitializeComponent();
            frmDSHD = DSHD;
            IdHD = IdHopDong;
            data = dt;
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
                httpClient.Headers.Add("Authorization", data.token);
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
