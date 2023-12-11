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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmTaiLieuDinhKem.xaml
    /// </summary>
    public partial class frmTaiLieuDinhKem : Page
    {
        private List<clsTaiLieuDinhKem.Datum> _lstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
        public List<clsTaiLieuDinhKem.Datum> LstTaiLieuDinhKem { get => _lstTaiLieuDinhKem; set => _lstTaiLieuDinhKem = value; }

        private string TongSoDong = "";
        private string IdKhachHang = "";
        private int TongSoTrang = 0;
        private List<string> _lstSTT = new List<string>();
        public List<string> lstSTT { get => _lstSTT; set => _lstSTT = value; }
        private frmTrangChuSauDangNhapCongTy frmMain;
        public frmTaiLieuDinhKem(string IdKH, List<clsTaiLieuDinhKem.Datum> listTLDK, string TongSD, frmTrangChuSauDangNhapCongTy frm)
        {
            InitializeComponent();
            this.DataContext = this;
            frmMain = frm;
            TongSoDong = TongSD;
            IdKhachHang = IdKH;
            textTongSoDong.Text = TongSD;
            LstTaiLieuDinhKem = listTLDK;
            //dgv.ItemsSource = listTLDK;
            
            LoadDLTaiLieuDinhKem();
            btnPage1.Background = Brushes.BlueViolet;
        }

        

        public async void LoadDLTaiLieuDinhKem()
        {
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listFileCus?customerId={IdKhachHang}";

                    var kq = await httpClient.GetAsync(url);
                    clsTaiLieuDinhKem.Root receiveInfo = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        textTongSoDong.Text = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            if (item.user_created_id == "0")
                            {
                                item.user_created_id = "Công ty";
                            }
                            LstTaiLieuDinhKem.Add(item);
                            for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = LstTaiLieuDinhKem.ToList();
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
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
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
                        string url = Properties.Resources.URL + $"listFileCus?page=1&limit=10&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page=1&limit=20&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page1=&limit=30&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page=1&limit=40&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page=1&limit=50&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=10&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=1&limit=10&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit20=&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=1&limit=20&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=30&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=1&limit=30&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=30&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=1&limit=40&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=50&customerId=695630";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=1&limit=50&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=10&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=2&limit=10&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=20&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=2&limit=20&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=30&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=2&limit=30&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=40&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=2&limit=40&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=50&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=2&limit=50&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
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
                                string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=10&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=10&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=3&limit=10&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=20&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=20&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=3&limit=20&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=30&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=30&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=3&limit=30&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=40&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=40&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=3&limit=40&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=50&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                                string url = Properties.Resources.URL + $"listFileCus?page={textPage2.Text}&limit=50&customerId={IdKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                                var kq = httpClient.GetAsync(url);
                                clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        if (item.user_created_id == "0")
                                        {
                                            item.user_created_id = "Công ty";
                                        }
                                        LstTaiLieuDinhKem.Add(item);
                                        for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = LstTaiLieuDinhKem;
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
                            string url = Properties.Resources.URL + $"listFileCus?page=3&limit=50&customerId={IdKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                            var kq = httpClient.GetAsync(url);
                            clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    if (item.user_created_id == "0")
                                    {
                                        item.user_created_id = "Công ty";
                                    }
                                    LstTaiLieuDinhKem.Add(item);
                                    for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = LstTaiLieuDinhKem;
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
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
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
                        string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=10&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=20&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=30&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=40&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
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
                        string url = Properties.Resources.URL + $"listFileCus?page={TongSoTrang}&limit=50&customerId={IdKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                        var kq = httpClient.GetAsync(url);
                        clsTaiLieuDinhKem.Root api = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                if (item.user_created_id == "0")
                                {
                                    item.user_created_id = "Công ty";
                                }
                                LstTaiLieuDinhKem.Add(item);
                                for (int i = 1; i <= LstTaiLieuDinhKem.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = LstTaiLieuDinhKem;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnThemMoiTaiLieu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new Popup.dialogThemMoiTaiLieuDinhKem(IdKhachHang, this));
            //Popup.dialogThemMoiTaiLieuDinhKem dialog = new Popup.dialogThemMoiTaiLieuDinhKem(IdKhachHang);
            //dialog.ShowDialog();
            //LoadDLTaiLieuDinhKem();
        }
        //private async void LoadDL()
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        try
        //        {
        //            httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
        //            string url = Properties.Resources.URL + $"infoCustomer?id={}";
        //            var kq = await httpClient.GetAsync(url);
        //            clsThongTinKH receiveInfo = JsonConvert.DeserializeObject<clsThongTinKH>(kq.Content.ReadAsStringAsync().Result);
        //            if (receiveInfo.data != null)
        //            {

        //                //DuongDanAnh = "https://crm.timviec365.vn/" + dataThongTinKH.logo;
        //                var DuongDan = new Uri("https://crm.timviec365.vn/" + dataThongTinKH.logo);
                        
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}

        private void btnTaiXuong_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            string[] hh = DuongDanAnhAPI.Split(Convert.ToChar("/"));
            save.FileName = hh[hh.Length - 1];
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                WebClient client = new WebClient();
                client.DownloadFileAsync(new Uri(DuongDanAnhAPI), save.FileName);
                //client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler();
            }
            
        }
        private string idFile = "";
        private string TenFile = "";
        private string DuongDanAnhAPI = "";
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsTaiLieuDinhKem.Datum tl = (clsTaiLieuDinhKem.Datum)dgv.SelectedItem;
            if (tl != null)
            {
                DuongDanAnhAPI = "https://crm.timviec365.vn" + tl.link;
                idFile = tl.id;
                TenFile = tl.file_name;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new Popup.dialogXoaTaiLieuDinhKem(idFile, TenFile, this));
            //Popup.dialogXoaTaiLieuDinhKem dialog = new Popup.dialogXoaTaiLieuDinhKem(idFile, TenFile);
            //dialog.ShowDialog();
            //LoadDLTaiLieuDinhKem();
        }
        public List<clsTaiLieuDinhKem.Datum> listTaiLieu2 = new List<clsTaiLieuDinhKem.Datum>();
        private void btnTimKiem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            listTaiLieu2 = new List<clsTaiLieuDinhKem.Datum>();
            if (tbSearch.Text.Equals(""))
            {
                listTaiLieu2.AddRange(LstTaiLieuDinhKem);
            }
            else
            {
                foreach (clsTaiLieuDinhKem.Datum anim in LstTaiLieuDinhKem)
                {

                    if (anim.file_name.Contains(tbSearch.Text))
                    {
                        listTaiLieu2.Add(anim);
                    }
                }
            }

            dgv.ItemsSource = listTaiLieu2.ToList();
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            frmMain.scrollMain.ScrollToVerticalOffset(frmMain.scrollMain.VerticalOffset - e.Delta);
        }
    }
}
