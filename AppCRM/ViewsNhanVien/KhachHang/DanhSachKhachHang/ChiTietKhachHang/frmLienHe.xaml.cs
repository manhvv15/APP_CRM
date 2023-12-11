using AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien.ChiTietKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmLienHeNhanVien.xaml
    /// </summary>
    public partial class frmLienHeNhanVien : Page
    {
        private clsLienHe.Datum _TTLH = new clsLienHe.Datum();
        private List<clsLienHe.Datum> _lstLienHe = new List<clsLienHe.Datum>();
        public List<clsLienHe.Datum> LstLienHe { get => _lstLienHe; set => _lstLienHe = value; }
        public clsLienHe.Datum TTLH { get => _TTLH; set => _TTLH = value; }
        public List<string> Stt { get => _Stt; set => _Stt = value; }

        public List<clsLienHe.Datum> lstLienHe2 = new List<clsLienHe.Datum>();
        private string IdMaKhachHang = "";
        private int TongSoTrang = 0;
        private List<int> LietKeTrang = new List<int>();
        private Model.APIEntity.DataLogin_Employee data;
        private frmThanhMenuDoc frmMain;
        public frmLienHeNhanVien(string IdKhachHang, Model.APIEntity.DataLogin_Employee dt, frmThanhMenuDoc frm)
        {
            InitializeComponent();
            this.DataContext = this;
            frmMain = frm;
            data = dt;
            IdMaKhachHang = IdKhachHang;
            LoadDuLieuLienHe();
            btnPage1.Background = Brushes.BlueViolet;
            clsBien.listMangXaHoi.Clear();
        }
        private async void LoadDuLieuLienHe()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    string url = Properties.Resources.URL + $"listContactCustomer?id_customer={IdMaKhachHang}";

                    var kq = await httpClient.GetAsync(url);
                    clsLienHe.Root receiveInfo = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        textTongSoDong.Text = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            LstLienHe.Add(item);
                            lstLienHe2.Add(item);
                            for (int i = 1; i <= lstLienHe2.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }

                        dgv.ItemsSource = LstLienHe.ToList();
                    }

                }
                catch
                {
                }
            }
        }
        private void btnThemMoiLienHe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsBien.listSDT.Clear();
            clsBien.listMangXaHoi.Clear();
            clsBien.listIDMangXaHoi.Clear();
            frmThemMoiLienHeNhanVien frm = new frmThemMoiLienHeNhanVien("Thêm mới liên hệ", TTLH, IdMaKhachHang, data, frmMain);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
        public string IDLienHe = "";
        private void textHoVaTen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsLienHe.Datum cls = (clsLienHe.Datum)dgv.SelectedItem;
            //if (cls != null)
            //{
            //    IDLienHe = cls.contact_id;

            //}
            frmChiTietLienHeNhanVien frm = new frmChiTietLienHeNhanVien(cls);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
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
            lstLienHe2 = new List<clsLienHe.Datum>();
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=10&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=20&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=30&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=40&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=50&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
            lstLienHe2 = new List<clsLienHe.Datum>();
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=10&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2}&limit=20&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=20&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=30&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=30&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=40&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=40&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=50&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=1&limit=50&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
            lstLienHe2 = new List<clsLienHe.Datum>();
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=10&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=2&limit=10&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=20&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=2&limit=20&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=30&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=2&limit=30&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=40&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=2&limit=40&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=50&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=2&limit=50&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
            lstLienHe2 = new List<clsLienHe.Datum>();
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=10&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=10&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=3&limit=10&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=20&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=20&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=3&limit=20&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=30&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=30&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=3&limit=30&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=40&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=40&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=3&limit=40&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page=3&limit=50&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                                string url = Properties.Resources.URL + $"listContactCustomer?page={textPage2.Text}&limit=50&id_customer={IdMaKhachHang}";
                                httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                                var kq = httpClient.GetAsync(url);
                                clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {

                                    foreach (var item in api.data)
                                    {
                                        lstLienHe2.Add(item);
                                        for (int i = 1; i <= lstLienHe2.Count; i++)
                                        {
                                            item.stt = i.ToString();
                                        }
                                    }
                                    dgv.ItemsSource = lstLienHe2;
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
                            string url = Properties.Resources.URL + $"listContactCustomer?page=3&limit=50&id_customer={IdMaKhachHang}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    lstLienHe2.Add(item);
                                    for (int i = 1; i <= lstLienHe2.Count; i++)
                                    {
                                        item.stt = i.ToString();
                                    }
                                }
                                dgv.ItemsSource = lstLienHe2;
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
            lstLienHe2 = new List<clsLienHe.Datum>();
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=10&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=20&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=30&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=40&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
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
                        string url = Properties.Resources.URL + $"listContactCustomer?page={TongSoTrang}&limit=50&id_customer={IdMaKhachHang}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsLienHe.Root api = JsonConvert.DeserializeObject<clsLienHe.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {

                            foreach (var item in api.data)
                            {
                                lstLienHe2.Add(item);
                                for (int i = 1; i <= lstLienHe2.Count; i++)
                                {
                                    item.stt = i.ToString();
                                }
                            }
                            dgv.ItemsSource = lstLienHe2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnTimKiem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstLienHe2.Clear();
            if (tbSearch.Text.Equals(""))
            {
                lstLienHe2.AddRange(LstLienHe);
            }
            else
            {
                foreach (clsLienHe.Datum anim in LstLienHe)
                {

                    if (anim.fullname.Contains(tbSearch.Text))
                    {
                        lstLienHe2.Add(anim);
                    }
                }
            }

            dgv.ItemsSource = lstLienHe2.ToList();
        }

        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            clsBien.listSDT.Clear();
            clsBien.listMangXaHoi.Clear();
            clsBien.listIDMangXaHoi.Clear();
            foreach (clsLienHe.Datum lh in LstLienHe)
            {
                if (IDLienHe == lh.contact_id)
                {
                    string[] tt = lh.personal_phone.Split(Convert.ToChar(","));
                    clsBien.listSDT.Clear();
                    foreach (string ff in tt)
                    {
                        clsBien.listSDT.Add(ff);
                    }
                }
            }
            foreach (clsLienHe.Datum lh in LstLienHe)
            {
                if (IDLienHe == lh.contact_id)
                {
                    string[] tt = lh.social.Split(Convert.ToChar(","));
                    clsBien.listMangXaHoi.Clear();
                    foreach (string ff in tt)
                    {
                        if (ff == "1")
                        {
                            clsBien.listMangXaHoi.Add("Zalo");
                        }
                        else if (ff == "2")
                        {
                            clsBien.listMangXaHoi.Add("Facebook");
                        }
                        else if (ff == "3")
                        {
                            clsBien.listMangXaHoi.Add("Telegram");
                        }
                        else if (ff == "4")
                        {
                            clsBien.listMangXaHoi.Add("Twitter");
                        }
                        else if (ff == "5")
                        {
                            clsBien.listMangXaHoi.Add("Skype");
                        }
                        else if (ff == "6")
                        {
                            clsBien.listMangXaHoi.Add("Instagram");
                        }
                        else if (ff == "7")
                        {
                            clsBien.listMangXaHoi.Add("Linkedin");
                        }
                        else if (ff == "8")
                        {
                            clsBien.listMangXaHoi.Add("Youtube");
                        }
                        clsBien.listIDMangXaHoi.Add(ff);
                    }
                }
            }
            frmThemMoiLienHeNhanVien frm = new frmThemMoiLienHeNhanVien("Chỉnh sửa liên hệ", TTLH, IdMaKhachHang, data, frmMain);
            pnlHienThi.Children.Clear();
            object Content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(Content as UIElement);
        }

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TTLH = new clsLienHe.Datum();
            clsLienHe.Datum lh = (clsLienHe.Datum)dgv.SelectedItem;
            TTLH = lh;
            //IDLienHe = lh.contact_id;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", data.token);
                httpClient.QueryString.Add("contact_id", TTLH.contact_id);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteContactCustomer"), "POST", httpClient.QueryString);
            }
            LstLienHe.Clear();
            LoadDuLieuLienHe();
        }
        private List<string> _Stt = new List<string>();
        public string rr;
        private void dgv_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            rr = (e.Row.GetIndex() + 1).ToString();
            //e.Row.VerticalAlignment = VerticalAlignment.Center;
            //e.Row.HorizontalAlignment = HorizontalAlignment.Center;
            //e.Row.FontSize = 15;
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            frmMain.scrollMain.ScrollToVerticalOffset(frmMain.scrollMain.VerticalOffset - e.Delta);
        }
    }
}
