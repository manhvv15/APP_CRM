using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmDanhSachTinDang.xaml
    /// </summary>
    public partial class frmDanhSachTinDang : Page
    {
        private List<clsDanhSachTinDang.Datum> _lstDSTinDang = new List<clsDanhSachTinDang.Datum>();
        public List<clsDanhSachTinDang.Datum> LstDSTinDang { get => _lstDSTinDang; set => _lstDSTinDang = value; }
        private string IdKhachHang = "";
        private frmTrangChuSauDangNhapCongTy frmMain;
        public frmDanhSachTinDang(string IdKH, string TongSoDong, List<clsDanhSachTinDang.Datum> lstTinDang, frmTrangChuSauDangNhapCongTy frm)
        {
            InitializeComponent();
            IdKhachHang = IdKH;
            textTongSo.Text = TongSoDong;
            frmMain = frm;
            dgv.ItemsSource = lstTinDang;
            btnPage1.Background = Brushes.BlueViolet;
        }

        

        private void textTieuDeTinDang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new Popup.dialogChiTietTinTuyenDung(IdTinDang, NoiDung));
            //Popup.dialogChiTietTinTuyenDung frm = new Popup.dialogChiTietTinTuyenDung(IdTinDang, NoiDung);
            //frm.ShowDialog();
        }

        private void btnDau_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btnDau.Visibility = Visibility.Collapsed;
            btnLui1.Visibility = Visibility.Collapsed;
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            textPage1.Text = "1";
            textPage2.Text = "2";
            textPage3.Text = "3";
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            LstDSTinDang = new List<clsDanhSachTinDang.Datum>();
            btnDau.Visibility = Visibility.Collapsed;
            btnLui1.Visibility = Visibility.Collapsed;
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"listNew3312?page=1&limit=10&customerId={IdKhachHang}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            
                            LstDSTinDang.Add(item);
                            for (int i = 1; i <= LstDSTinDang.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = LstDSTinDang;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }

        }

        private void btnPage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstDSTinDang = new List<clsDanhSachTinDang.Datum>();
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            if (textPage1.Text != "1")
            {
                textPage1.Text = (int.Parse(textPage1.Text) - 1).ToString();
                textPage2.Text = (int.Parse(textPage2.Text) - 1).ToString();
                textPage3.Text = (int.Parse(textPage3.Text) - 1).ToString();
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.BlueViolet;
                btnPage3.Background = Brushes.White;
                btnDau.Visibility = Visibility.Visible;
                btnLui1.Visibility = Visibility.Visible;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNew3312?page={textPage2.Text}&limit=10&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                
                                LstDSTinDang.Add(item);
                                for (int i = 1; i <= LstDSTinDang.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstDSTinDang;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else
            {
                btnDau.Visibility = Visibility.Collapsed;
                btnLui1.Visibility = Visibility.Collapsed;
                btnPage1.Background = Brushes.BlueViolet;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.White;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNew3312?page=1&limit=10&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                LstDSTinDang.Add(item);
                                for (int i = 1; i <= LstDSTinDang.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstDSTinDang;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnPage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstDSTinDang = new List<clsDanhSachTinDang.Datum>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            if (textPage2.Text != "2")
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.BlueViolet;
                btnPage3.Background = Brushes.White;
                try
                {

                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNew3312?page={textPage2.Text}&limit=10&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                
                                LstDSTinDang.Add(item);
                                for (int i = 1; i <= LstDSTinDang.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstDSTinDang;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.BlueViolet;
                btnPage3.Background = Brushes.White;
                btnLui1.Visibility = Visibility.Visible;
                btnDau.Visibility = Visibility.Visible;
                btnLen1.Visibility = Visibility.Visible;
                btnCuoi.Visibility = Visibility.Visible;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNew3312?page=2&limit=10&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                LstDSTinDang.Add(item);
                                for (int i = 1; i <= LstDSTinDang.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstDSTinDang;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }
        private int TongSoTrang;
        private void btnPage3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstDSTinDang = new List<clsDanhSachTinDang.Datum>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            TongSoTrang = int.Parse(textTongSo.Text) / 10;
            if (int.Parse(textTongSo.Text) % 10 > 0)
            {
                TongSoTrang++;
            }
            if (TongSoTrang > 3)
            {
                if (textPage3.Text == TongSoTrang.ToString())
                {
                    btnCuoi.Visibility = Visibility.Collapsed;
                    btnLen1.Visibility = Visibility.Collapsed;
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.White;
                    btnPage3.Background = Brushes.BlueViolet;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNew3312?page={textTongSo.Text}&limit=10&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    LstDSTinDang.Add(item);
                                    for (int i = 1; i <= LstDSTinDang.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstDSTinDang;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                else
                {
                    textPage1.Text = (int.Parse(textPage1.Text) + 1).ToString();
                    textPage2.Text = (int.Parse(textPage2.Text) + 1).ToString();
                    textPage3.Text = (int.Parse(textPage3.Text) + 1).ToString();
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.BlueViolet;
                    btnPage3.Background = Brushes.White;
                    btnCuoi.Visibility = Visibility.Visible;
                    btnLen1.Visibility = Visibility.Visible;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNew3312?page={textPage2.Text}&limit=10&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    LstDSTinDang.Add(item);
                                    for (int i = 1; i <= LstDSTinDang.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstDSTinDang;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }

            }
            else
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.BlueViolet;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNew3312?page=3&limit=10&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                LstDSTinDang.Add(item);
                                for (int i = 1; i <= LstDSTinDang.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstDSTinDang;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnCuoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textPage1.Text = (TongSoTrang - 2).ToString();
            textPage2.Text = (TongSoTrang - 1).ToString();
            textPage3.Text = TongSoTrang.ToString();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Collapsed;
            btnLen1.Visibility = Visibility.Collapsed;
            btnPage1.Background = Brushes.White;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.BlueViolet;
            LstDSTinDang = new List<clsDanhSachTinDang.Datum>();
            TongSoTrang = int.Parse(textTongSo.Text) / 10;
            if (TongSoTrang % 10 != 0)
            {
                TongSoTrang++;
            }
            textPage3.Text = TongSoTrang.ToString();
            textPage2.Text = (TongSoTrang - 1).ToString();
            textPage1.Text = (TongSoTrang - 2).ToString();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"listNew3312?page={TongSoTrang}&limit=10&customerId={IdKhachHang}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsDanhSachTinDang.Root api = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            
                            LstDSTinDang.Add(item);
                            for (int i = 1; i <= LstDSTinDang.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = LstDSTinDang;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private string IdTinDang = "";
        private string NoiDung = "";
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsDanhSachTinDang.Datum cls = (clsDanhSachTinDang.Datum)dgv.SelectedItem;
            if (cls != null)
            {
                IdTinDang = cls.id;
                NoiDung = cls.content;
            }
        }

        private void btnTimKiem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dtpDenNgay.Text == "dd/MM/yyyy")
            {
                FilterNoteFromDateToDate(dtpTuNgay.Text, DateTime.Now.ToString());
            }
            else if(dtpTuNgay.Text == "dd/MM/yyyy")
            {
                FilterNoteFromDateToDate(dtpDenNgay.Text, DateTime.Now.ToString());
            }
            else
            {
                FilterNoteFromDateToDate(dtpTuNgay.Text, dtpDenNgay.Text);
            }
        }
        private async void FilterNoteFromDateToDate(string dtpFrom, string dtpDate)
        {
            LstDSTinDang = new List<clsDanhSachTinDang.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listNew3312?start_date={dtpFrom}&end_date={dtpDate}&customerId={IdKhachHang}";

                    var kq = await httpClient.GetAsync(url);
                    clsDanhSachTinDang.Root receiveInfo = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        textTongSo.Text = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            LstDSTinDang.Add(item);
                            for(int i = 1; i <= LstDSTinDang.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = LstDSTinDang;
                    }
                }
                catch
                {
                }
            }
        }
    }
}
