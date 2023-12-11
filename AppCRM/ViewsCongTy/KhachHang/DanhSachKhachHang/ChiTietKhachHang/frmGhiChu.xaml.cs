using Newtonsoft.Json;
using RestSharp;
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
    /// Interaction logic for frmGhiChu.xaml
    /// </summary>
    public partial class frmGhiChu : Page
    {
        public List<clsGhiChu.Datum> lstGhiChu = new List<clsGhiChu.Datum>();
        public List<clsGhiChu.Datum> lstGhiChu2 = new List<clsGhiChu.Datum>();
        private string IdKh = "";
        private string TongSoDong = "";
        private int TongSoTrang = 0;
        private frmTrangChuSauDangNhapCongTy frmMain;
        public frmGhiChu(List<clsGhiChu.Datum> lstGC, string IdKhachHang, string TongSD, frmTrangChuSauDangNhapCongTy frm)
        {
            InitializeComponent();
            this.DataContext = this;
            frmMain = frm;
            IdKh = IdKhachHang;
            TongSoDong = TongSD;
            textTongSoDong.Text = TongSD;
            lstGhiChu = lstGC;
            //dgv.ItemsSource = lstGC;
            btnPage1.Background = Brushes.BlueViolet;
            LoadDLGhiChu();
        }

        public async void LoadDLGhiChu()
        {
            lstGhiChu = new List<clsGhiChu.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listNoteCus?customerId={IdKh}";

                    var kq = await httpClient.GetAsync(url);
                    clsGhiChu.Root receiveInfo = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        textTongSoDong.Text = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            if (item.user_created_id == "0")
                            {
                                item.user_created_id = "Công ty";
                            }
                            lstGhiChu.Add(item);
                            for (int i = 1; i <= lstGhiChu.Count; i++)
                            {
                                item.stt = i.ToString();
                            }

                        }
                        dgv.ItemsSource = lstGhiChu.ToList();
                    }
                }
                catch
                {
                }
            }
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
            lstGhiChu2 = new List<clsGhiChu.Datum>();
            if (cboPhanTrang.Text == "10 bản ghi trên trang")
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
                        string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=10&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else if (cboPhanTrang.Text == "20 bản ghi trên trang")
            {
                btnPage1.Background = Brushes.BlueViolet;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.White;
                btnLui1.Visibility = Visibility.Collapsed;
                btnDau.Visibility = Visibility.Collapsed;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=20&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else if (cboPhanTrang.Text == "30 bản ghi trên trang")
            {
                btnPage1.Background = Brushes.BlueViolet;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.White;
                btnDau.Visibility = Visibility.Collapsed;
                btnLui1.Visibility = Visibility.Collapsed;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=30&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else if (cboPhanTrang.Text == "40 bản ghi trên trang")
            {
                btnPage1.Background = Brushes.BlueViolet;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.White;
                btnLui1.Visibility = Visibility.Collapsed;
                btnDau.Visibility = Visibility.Collapsed;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=40&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else if (cboPhanTrang.Text == "50 bản ghi trên trang")
            {
                btnPage1.Background = Brushes.BlueViolet;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.White;
                btnDau.Visibility = Visibility.Collapsed;
                btnLui1.Visibility = Visibility.Collapsed;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=50&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnPage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstGhiChu2 = new List<clsGhiChu.Datum>();
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            if (cboPhanTrang.Text == "10 bản ghi trên trang")
            {
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
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                            string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=10&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "20 bản ghi trên trang")
            {
                if (textPage1.Text != "1")
                {
                    textPage1.Text = (int.Parse(textPage1.Text) - 1).ToString();
                    textPage2.Text = (int.Parse(textPage2.Text) - 1).ToString();
                    textPage3.Text = (int.Parse(textPage3.Text) - 1).ToString();
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.BlueViolet;
                    btnPage3.Background = Brushes.White;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2}&limit=20&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    btnPage1.Background = Brushes.BlueViolet;
                    btnPage2.Background = Brushes.White;
                    btnPage3.Background = Brushes.White;
                    btnLui1.Visibility = Visibility.Collapsed;
                    btnDau.Visibility = Visibility.Collapsed;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=20&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "30 bản ghi trên trang")
            {
                if (textPage1.Text != "1")
                {
                    textPage1.Text = (int.Parse(textPage1.Text) - 1).ToString();
                    textPage2.Text = (int.Parse(textPage2.Text) - 1).ToString();
                    textPage3.Text = (int.Parse(textPage3.Text) - 1).ToString();
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.BlueViolet;
                    btnPage3.Background = Brushes.White;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=30&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    btnPage1.Background = Brushes.BlueViolet;
                    btnPage2.Background = Brushes.White;
                    btnPage3.Background = Brushes.White;
                    btnDau.Visibility = Visibility.Collapsed;
                    btnLui1.Visibility = Visibility.Collapsed;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=30&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "40 bản ghi trên trang")
            {
                if (textPage1.Text != "1")
                {
                    textPage1.Text = (int.Parse(textPage1.Text) - 1).ToString();
                    textPage2.Text = (int.Parse(textPage2.Text) - 1).ToString();
                    textPage3.Text = (int.Parse(textPage3.Text) - 1).ToString();
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.BlueViolet;
                    btnPage3.Background = Brushes.White;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=40&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    btnPage1.Background = Brushes.BlueViolet;
                    btnPage2.Background = Brushes.White;
                    btnPage3.Background = Brushes.White;
                    btnLui1.Visibility = Visibility.Collapsed;
                    btnDau.Visibility = Visibility.Collapsed;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=40&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "50 bản ghi trên trang")
            {
                if (textPage1.Text != "1")
                {
                    textPage1.Text = (int.Parse(textPage1.Text) - 1).ToString();
                    textPage2.Text = (int.Parse(textPage2.Text) - 1).ToString();
                    textPage3.Text = (int.Parse(textPage3.Text) - 1).ToString();
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.BlueViolet;
                    btnPage3.Background = Brushes.White;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=50&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    btnPage1.Background = Brushes.BlueViolet;
                    btnPage2.Background = Brushes.White;
                    btnPage3.Background = Brushes.White;
                    btnDau.Visibility = Visibility.Collapsed;
                    btnLui1.Visibility = Visibility.Collapsed;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=1&limit=50&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
        }

        private void textPage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstGhiChu2 = new List<clsGhiChu.Datum>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            if (cboPhanTrang.Text == "10 bản ghi trên trang")
            {
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
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=10&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                            string url = Properties.Resources.URL + $"listNoteCus?page=2&limit=10&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "20 bản ghi trên trang")
            {
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
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=20&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    try
                    {

                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=2&limit=20&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "30 bản ghi trên trang")
            {
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
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=30&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    try
                    {

                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=2&limit=30&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "40 bản ghi trên trang")
            {
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
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=40&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    try
                    {

                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=2&limit=40&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            if (cboPhanTrang.Text == "50 bản ghi trên trang")
            {
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
                            string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=50&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
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
                    try
                    {

                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = Properties.Resources.URL + $"listNoteCus?page=2&limit=50&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
        }

        private void btnPage3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstGhiChu2 = new List<clsGhiChu.Datum>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            if (cboPhanTrang.Text == "10 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 10;
                if (int.Parse(textTongSoDong.Text) % 10 > 0)
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
                                string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=10&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                                string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=10&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                            string url = Properties.Resources.URL + $"listNoteCus?page=3&limit=10&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            else if (cboPhanTrang.Text == "20 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 20;
                if (int.Parse(textTongSoDong.Text) % 20 > 0)
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
                                string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=20&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                        try
                        {
                            using (HttpClient httpClient = new HttpClient())
                            {
                                //string url = Properties.Resources.URL + "listGroupCustomer";
                                string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=20&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                            string url = Properties.Resources.URL + $"listNoteCus?page=3&limit=20&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            else if (cboPhanTrang.Text == "30 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 30;
                if (int.Parse(textTongSoDong.Text) % 30 > 0)
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
                                string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=30&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                        try
                        {
                            using (HttpClient httpClient = new HttpClient())
                            {
                                //string url = Properties.Resources.URL + "listGroupCustomer";
                                string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=30&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                            string url = Properties.Resources.URL + $"listNoteCus?page=3&limit=30&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            else if (cboPhanTrang.Text == "40 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 40;
                if (int.Parse(textTongSoDong.Text) % 40 > 0)
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
                                string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=40&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                        try
                        {
                            using (HttpClient httpClient = new HttpClient())
                            {
                                //string url = Properties.Resources.URL + "listGroupCustomer";
                                string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=40&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                            string url = Properties.Resources.URL + $"listNoteCus?page=3&limit=40&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2.ToList();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
            }
            else if (cboPhanTrang.Text == "50 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 50;
                if (int.Parse(textTongSoDong.Text) % 50 > 0)
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
                                string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=50&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                        try
                        {
                            using (HttpClient httpClient = new HttpClient())
                            {
                                //string url = Properties.Resources.URL + "listGroupCustomer";
                                string url = Properties.Resources.URL + $"listNoteCus?page={textPage2.Text}&limit=50&customerId={IdKh}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        lstGhiChu2.Add(item);
                                        for (int i = 1; i <= lstGhiChu2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstGhiChu2;
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
                            string url = Properties.Resources.URL + $"listNoteCus?page=3&limit=50&customerId={IdKh}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    lstGhiChu2.Add(item);
                                    for (int i = 1; i <= lstGhiChu2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstGhiChu2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
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
            lstGhiChu2 = new List<clsGhiChu.Datum>();
            if (cboPhanTrang.Text == "10 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 10;
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
                        string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=10&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else if (cboPhanTrang.Text == "20 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 20;
                if (TongSoTrang % 20 != 0)
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
                        string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=20&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }

            }
            else if (cboPhanTrang.Text == "30 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 30;
                if (TongSoTrang % 30 != 0)
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
                        string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=30&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }

            }
            else if (cboPhanTrang.Text == "40 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 40;
                if (TongSoTrang % 40 != 0)
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
                        string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=40&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            else if (cboPhanTrang.Text == "50 bản ghi trên trang")
            {
                TongSoTrang = int.Parse(textTongSoDong.Text) / 50;
                if (TongSoTrang % 50 != 0)
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
                        string url = Properties.Resources.URL + $"listNoteCus?page={TongSoTrang}&limit=50&customerId={IdKh}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsGhiChu.Root api = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                lstGhiChu2.Add(item);
                                for (int i = 1; i <= lstGhiChu2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstGhiChu2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnThemMoiGhiChu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new frmThemMoiGhiChu(IdKh, "Thêm mới ghi chú", IdGhiChu, NoiDungGhiChu, this));
            //PopUpThemMoiGhiChu.Visibility = Visibility.Visible;
            //frmThemMoiGhiChu frm = new frmThemMoiGhiChu(IdKh, "Thêm mới ghi chú", IdGhiChu, NoiDungGhiChu);
            //frm.ShowDialog();
            //LoadDLGhiChu();

        }

        private string IdGhiChu = "";
        private string NoiDungGhiChu = "";
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsGhiChu.Datum gc = (clsGhiChu.Datum)dgv.SelectedItem;
            if (gc != null)
            {
                IdGhiChu = gc.id;
                NoiDungGhiChu = gc.content;
            }
        }

        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new frmThemMoiGhiChu(IdKh, "Thêm mới ghi chú", IdGhiChu, NoiDungGhiChu, this));
            //    frmThemMoiGhiChu frm = new frmThemMoiGhiChu(IdKh, "Chỉnh sửa ghi chú", IdGhiChu, NoiDungGhiChu);
            //    frm.ShowDialog();
            //    LoadDLGhiChu();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new Popup.dialogXoaGhiChu(IdGhiChu, IdKh, this));
            //Popup.dialogXoaGhiChu mesXoaGC = new Popup.dialogXoaGhiChu(IdGhiChu, IdKh);
            //mesXoaGC.ShowDialog();
            //LoadDLGhiChu();
        }
        private async void FilterNoteFromDateToDate(string dtpFrom,string dtpDate)
        {
            lstGhiChu = new List<clsGhiChu.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listNoteCus?startTime={dtpFrom}&endTime={dtpDate}&customerId={IdKh}";

                    var kq = await httpClient.GetAsync(url);
                    clsGhiChu.Root receiveInfo = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        textTongSoDong.Text = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            if (item.user_created_id == "0")
                            {
                                item.user_created_id = "Công ty";
                            }
                            lstGhiChu.Add(item);
                            for(int i = 1; i <= lstGhiChu.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = lstGhiChu;
                    }
                }
                catch
                {
                }
            }
        }

        private void dtpTuNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtpDenNgay.Text == "dd/MM/yyyy")
            {
                FilterNoteFromDateToDate(dtpTuNgay.Text, DateTime.Now.ToString());
            }
            else
            {
                FilterNoteFromDateToDate(dtpTuNgay.Text, dtpDenNgay.Text);
            }
        }

        private void dtpDenNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtpTuNgay.Text == "dd/MM/yyyy")
            {
                FilterNoteFromDateToDate(dtpDenNgay.Text, DateTime.Now.ToString());
            }
            else
            {
                FilterNoteFromDateToDate(dtpTuNgay.Text, dtpDenNgay.Text);
            }
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            frmMain.scrollMain.ScrollToVerticalOffset(frmMain.scrollMain.VerticalOffset - e.Delta);
        }
    }
}
