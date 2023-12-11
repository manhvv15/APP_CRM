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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCRM.Views.HopDong
{
    /// <summary>
    /// Interaction logic for PageDSHopDong.xaml
    /// </summary>
    public partial class PageDSHopDong : Page
    {
        private Model.APIEntity.DataLogin_Company data;
        private List<clsHopDong.Datum> _lstHD = new List<clsHopDong.Datum>();

        public List<clsHopDong.Datum> lstHopDong { get => _lstHD; set => _lstHD = value; }
        private int TongSoTrang;
        frmTrangChuSauDangNhapCongTy frmMain;
        public PageDSHopDong(frmTrangChuSauDangNhapCongTy main, List<clsHopDong.Datum> LstHopDong, Model.APIEntity.DataLogin_Company dt, string TongSoDong)
        {
            InitializeComponent();
            textTongSoDong.Text = TongSoDong;
            lstHopDong = LstHopDong;
            dgv.ItemsSource = LstHopDong;
            data = dt;
            btnPage1.Background = Brushes.BlueViolet;
            frmMain = main;
            frmMain.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
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
            lstHopDong = new List<clsHopDong.Datum>();
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
                        string url = Properties.Resources.URL + $"listContract?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page=1&limit=20";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page=1&limit=30";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page=1&limit=40";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page=1&limit=50";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
            lstHopDong = new List<clsHopDong.Datum>();
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=20";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=1&limit=20";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=30";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=1&limit=30";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=40";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=1&limit=40";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=50";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=1&limit=50";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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

        private void btnPage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstHopDong = new List<clsHopDong.Datum>();
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=2&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=20";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=2&limit=20";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=30";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=2&limit=30";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=40";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=2&limit=40";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=50";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=2&limit=50";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
            lstHopDong = new List<clsHopDong.Datum>();
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
                                string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=3&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=20";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=20";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=3&limit=20";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=30";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=30";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=3&limit=30";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=40";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=40";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=3&limit=40";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong.ToList();
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
                                string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=50";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                                string url = Properties.Resources.URL + $"listContract?page={textPage2.Text}&limit=50";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        
                                        lstHopDong.Add(item);
                                        for (int i = 1; i <= lstHopDong.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstHopDong;
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
                            string url = Properties.Resources.URL + $"listContract?page=3&limit=50";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    
                                    lstHopDong.Add(item);
                                    for (int i = 1; i <= lstHopDong.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstHopDong;
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
            lstHopDong = new List<clsHopDong.Datum>();
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
                        string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=20";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=30";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=40";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
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
                        string url = Properties.Resources.URL + $"listContract?page={TongSoTrang}&limit=50";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                
                                lstHopDong.Add(item);
                                for (int i = 1; i <= lstHopDong.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstHopDong;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnThemMoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ThemMoiHopDong frm = new ThemMoiHopDong(IdHopDong, frmMain, data, LinkFile, TenFile);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnXoa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new Popup.dialogXoaHopDong(IdHD, this));
            //Popup.dialogXoaHopDong dialog = new Popup.dialogXoaHopDong(IdHD);
            //dialog.ShowDialog();
            //LoadDLHopDong();
        }
        private string IdHD = "";
        private string TenFile = "";
        private string LinkFile = "";
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsHopDong.Datum hd = (clsHopDong.Datum)dgv.SelectedItem;
            if (hd != null)
            {
                IdHD = hd.id;
                TenFile = hd.name;
                IdHopDong = hd.id;
                //string[] ten = hd.path_file.Split(Convert.ToChar("/"));
                //string aa = "";
                //for(int i = 1; i < ten.Count(); i++)
                //{
                //    aa = aa + ten[i] + "/";
                //}
                //aa = aa.Remove(aa.Length - 1);
                LinkFile = "https://crm.timviec365.vn/" + hd.path_file;
            }
        }
        public void LoadDLHopDong()
        {
            lstHopDong = new List<clsHopDong.Datum>();
            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listContract";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            textTongSoDong.Text = api.total.ToString();
                            lstHopDong.Add(item);
                            for (int i = 1; i <= lstHopDong.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = lstHopDong;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void textHopDongNV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChiTietHopDong cthdnv = new ChiTietHopDong(IdHopDong, data, frmMain, LinkFile, TenFile, this);
            pnlHienThi.Children.Clear();
            object content = cthdnv.Content;
            cthdnv.Content = null;
            //cthdnv.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            frmMain.scrollMain.ScrollToVerticalOffset(frmMain.scrollMain.VerticalOffset - e.Delta);
        }
        private string IdHopDong = "";
        private string IdFile = "";
        private string DuongDanHD = "";
        private void btnSua_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsHopDong.Datum hd = (clsHopDong.Datum)dgv.SelectedItem;
            if (hd != null)
            {
                IdHopDong = hd.id;
                //IdFile = hd.id_file;
                ThemMoiHopDong frm = new ThemMoiHopDong(hd.id, frmMain, data, LinkFile, TenFile);
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                //frm.Close();
                pnlHienThi.Children.Add(content as UIElement);
            }
        }
    }
}
