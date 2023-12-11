using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang.Popup
{
    /// <summary>
    /// Interaction logic for dialogXoaGhiChu.xaml
    /// </summary>
    public partial class dialogXoaGhiChu : UserControl
    {
        private string IdXoaGC = "";
        private string IdKH = "";
        private frmGhiChu frmGC;
        public dialogXoaGhiChu(string IdGC, string IdKhachHang, frmGhiChu frm)
        {
            InitializeComponent();
            frmGC = frm;
            IdXoaGC = IdGC;
            IdKH = IdKhachHang;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                httpClient.QueryString.Add("noteId", IdXoaGC);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteNoteCus"), "POST", httpClient.QueryString);
            }
            frmGC.LoadDLGhiChu();
            //frmGhiChu frm = new frmGhiChu(IdKH);
            //LoadDLGhiChu(frm.textTongSoDong.Text, frm.dgv, frm.lstGhiChu);
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
            this.Visibility = Visibility.Collapsed;
        }
        private async void LoadDLGhiChu(string tongsodong, DataGrid dgv, List<clsGhiChu.Datum> lstGhiChu)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listNoteCus?customerId={IdKH}";

                    var kq = await httpClient.GetAsync(url);
                    clsGhiChu.Root receiveInfo = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        tongsodong = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            if (item.user_created_id == "0")
                            {
                                item.user_created_id = "Công ty";
                            }
                            lstGhiChu.Add(item);
                        }
                        dgv.ItemsSource = lstGhiChu;
                    }
                }
                catch
                {
                }
            }
        }
        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility=Visibility.Collapsed;
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
