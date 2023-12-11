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

namespace AppCRM.Views.HopDong
{
    /// <summary>
    /// Interaction logic for ChiTietHopDongNhanVien.xaml
    /// </summary>
    public partial class ChiTietHopDongNhanVien : Page
    {
        public ChiTietHopDongNhanVien()
        {
            InitializeComponent();
        }
        private void LoadFileHD()
        {
            //using (WebClient httpClient = new WebClient())
            //{
            //    try
            //    {
            //        httpClient.Headers.Add("Authorization", Dt.token);
            //        httpClient.QueryString.Add("name", tb_TenTinhTrang.Text);

            //        httpClient.UploadValuesCompleted += (sender1, e1) =>
            //        {

            //            this.Close();
            //            //APIRequestContact receiveInfo = JsonConvert.DeserializeObject(UnicodeEncoding.UTF8.GetString(e.Result));
            //            //if (receiveInfo.data != null)
            //            //{
            //            //    DataChat.Socket.DeleteContact(contactId, userId);
            //            //}
            //        };
            //        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "addStatusCustomer"), "POST", httpClient.QueryString);
            //    }
            //    catch
            //    {
            //    }
            //}
        }
    }
}
