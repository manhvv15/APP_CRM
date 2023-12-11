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

namespace AppCRM.Views.CaiDat.CaiDatTongDaiDienThoai
{
    /// <summary>
    /// Interaction logic for dialogKetNoiLaiTongDai.xaml
    /// </summary>
    public partial class dialogKetNoiLaiTongDai : Window
    {
        private Model.APIEntity.DataLogin_Employee DataEmp;
        public dialogKetNoiLaiTongDai(string TieuDe, Model.APIEntity.DataLogin_Employee dtE)
        {
            InitializeComponent();
            DataEmp = dtE;
            tb_TieuDe.Text = TieuDe;
            if (TieuDe == "Kết nối tổng đài")
            {
                tb_NoiDung.Text = "Bạn có chắc chắn muốn kết nối lại tổng đài không?";
            }
            else
            {
                tb_NoiDung.Text = "Bạn có chắc chắn muốn huỷ kết nối tổng đài không?";
            }
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(tb_TieuDe.Text=="Kết nối tổng đài")
            {
                using (WebClient httpClient = new WebClient())
                {
                    try
                    {
                        httpClient.Headers.Add("Authorization", DataEmp.token);
                        httpClient.QueryString.Add("switchboard", "fpt");
                        httpClient.QueryString.Add("status", "1");
                        httpClient.UploadValuesCompleted += (sender1, e1) =>
                        {
                            this.Close();
                        };
                        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "connectSwitchboard"), "POST", httpClient.QueryString);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                using (WebClient httpClient = new WebClient())
                {
                    try
                    {
                        httpClient.Headers.Add("Authorization", DataEmp.token);
                        httpClient.QueryString.Add("switchboard", "fpt");
                        httpClient.QueryString.Add("status", "0");
                        httpClient.UploadValuesCompleted += (sender1, e1) =>
                        {
                            this.Close();
                        };
                        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "connectSwitchboard"), "POST", httpClient.QueryString);
                    }
                    catch
                    {
                    }
                }
            }
            DialogResult = true;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
