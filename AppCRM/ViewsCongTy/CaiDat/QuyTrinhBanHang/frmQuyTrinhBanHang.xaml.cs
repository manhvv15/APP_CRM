using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace AppCRM.Views.CaiDat.QuyTrinhBanHang
{
    /// <summary>
    /// Interaction logic for frmQuyTrinhBanHang.xaml
    /// </summary>
    public partial class frmQuyTrinhBanHang : Window
    {
        private List<clsQuyTrinhBanHang.Datum> _lst = new List<clsQuyTrinhBanHang.Datum>();
        public List<clsQuyTrinhBanHang.Datum> lst { get => _lst; set => _lst = value; }
        public frmQuyTrinhBanHang()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadDLieuQuyTrinhBanHang();
            //List<string> lstLoaiDB = new List<string>() { "Mở", "Kết thúc thắng", "Kết thúc thua" };
            //List<string> lstPhanLoaiDB = new List<string>() { "Đang thực hiện", "Cơ hội cao", "Cam kết", "Kết thúc thắng", "Đã mất" };
            //List<QTBH> lst = new List<QTBH>();
            //lst.Add(new QTBH { STT = "1", TenQuyTrinh = "Mở đầu", TyLeThanhCong = "10", LoaiDuBao = "Mở", DanhSachLoaiDuBao = lstLoaiDB, PhanLoaiDuBao = "Đang thực hiện", DanhSachPhanLoaiDuBao = lstPhanLoaiDB });
            //lst.Add(new QTBH { STT = "1", TenQuyTrinh = "Đàm phán thương lượng", TyLeThanhCong = "40", LoaiDuBao="Kết thúc thắng", DanhSachLoaiDuBao = lstLoaiDB, PhanLoaiDuBao = "Cơ hội cao", DanhSachPhanLoaiDuBao = lstPhanLoaiDB });
            //dgv.ItemsSource = lst;
        }
        private async void LoadDLieuQuyTrinhBanHang()
        {
            try
            {
                lst = new List<clsQuyTrinhBanHang.Datum>();
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + "listSalesProcess";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsQuyTrinhBanHang.Root api = JsonConvert.DeserializeObject<clsQuyTrinhBanHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            //dgv.ItemsSource = ListCustomer;
                            if (item.forecast_type == "2")
                            {
                                item.forecast_type = "Kết thúc thắng";
                            }
                            else if(item.forecast_type == "1")
                            {
                                item.forecast_type = "Mở";
                            }
                            else
                            {
                                item.forecast_type = "Kết thúc thua";
                            }
                            if (item.forecast_classification == "1")
                            {
                                item.forecast_classification = "Đang thực hiện";
                            }
                            else if(item.forecast_classification == "2")
                            {
                                item.forecast_classification = "Cơ hội cao";
                            }
                            else if (item.forecast_classification == "3")
                            {
                                item.forecast_classification = "Cam kết";
                            }
                            else if (item.forecast_classification == "4")
                            {
                                item.forecast_classification = "Kết thúc thắng";
                            }
                            else if (item.forecast_classification == "5")
                            {
                                item.forecast_classification = "Đã mất";
                            }
                            lst.Add(item);
                            for(int i = 1; i <= lst.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = lst;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void btnThemDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsQuyTrinhBanHang.Datum item = (sender as TextBlock).DataContext as clsQuyTrinhBanHang.Datum;
            //int index = dgv.Items.IndexOf();
            dgv.Items.Insert(2, item);
        }

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //public class QTBH
        //{
        //    public string STT { get; set; }
        //    public string TenQuyTrinh { get; set; }
        //    public string TyLeThanhCong { get; set; }
        //    public string LoaiDuBao { get; set; }
        //    public List<string> DanhSachLoaiDuBao { get; set; }
        //    public string PhanLoaiDuBao { get; set; }
        //    public List<string> DanhSachPhanLoaiDuBao { get; set; }
        //}

    }
}
