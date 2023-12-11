using AppCRM.Views.KhachHang.NhomKhachHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
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

namespace AppCRM.Views.KhachHang.NhomKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmThemMoiNhomKhachHangNhanVien.xaml
    /// </summary>
    public partial class frmThemMoiNhomKhachHangNhanVien : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Tool.SelectionBox Slb { get; set; }
        private Model.APIEntity.DataLogin_Employee dt;
        private List<clsNhomKhachHang> lstNhomKH = new List<clsNhomKhachHang>();
        private string MaNhomKhachHang = "";
        private List<Item> lstPhongBan = new List<Item>();
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        private ObservableCollection<string> _listEmployee = new ObservableCollection<string>();
        public ObservableCollection<string> listEmployee { get => _listEmployee; set { _listEmployee = value; OnPropertyChanged(); } }
        frmThanhMenuDoc frmMain;
        //Thêm mới nhóm khách hàng
        public frmThemMoiNhomKhachHangNhanVien(Model.APIEntity.DataLogin_Employee data, string TieuDe, frmThanhMenuDoc frm)
        {
            InitializeComponent();
            this.DataContext = this;
            dt = data;
            tb_TieuDe.Text = TieuDe;
            //selectBox.cpn = data;
            LoadDataNhomKH(data);
            LoadDataPhongBan();
            LoadDataNhanVien();
            clsBien.listIDNhanVien.Clear();
            clsBien.listIDPhongBan.Clear();
            clsBien.listPhongBan.Clear();
            clsBien.listNhanVien.Clear();
        }
        public frmThemMoiNhomKhachHangNhanVien(Model.APIEntity.DataLogin_Employee data, string MaNhomKHCha, string TenNhomKhachHangCha, string MoTaCha, string IdCha1, string TieuDe, clsNhomKhachHang nhomKHCha)
        {
            InitializeComponent();
            this.DataContext = this;
            dt = data;
            //this.DataNhomKH = nhomKH;
            tb_TenNhomKhachHang.Text = TenNhomKhachHangCha;
            tb_MoTa.Text = MoTaCha;
            IdNhomKhachHangCha = IdCha1;
            MaNhomKhachHang = MaNhomKHCha;
            tb_TieuDe.Text = TieuDe;
            //selectBox.cpn = data;
            LoadDataNhomKH(data);
            LoadDataPhongBan();
        }
        public class NhanVien
        {
            public string TenNhanVien { get; set; }
            public string Phongban { get; set; }
        }

        private void bd_Luu_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void bd_Luu_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void bd_Huy_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void bd_Huy_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private string IdNhomKhachHangCha = "";



        private void bd_Luu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (clsNhomKhachHang kh in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == kh.gr_name)
                {
                    IdNhomKhachHangCha = kh.gr_id;
                }
            }
            if (tb_TieuDe.Text == "Thêm mới nhóm khách hàng")
            {
                if (cboNhomKhachHangCha.Text == "Chọn nhóm khách hàng cha")
                {
                    using (WebClient httpClient = new WebClient())
                    {
                        try
                        {
                            httpClient.Headers.Add("Authorization", dt.token);
                            httpClient.QueryString.Add("name", tb_TenNhomKhachHang.Text);
                            httpClient.QueryString.Add("description", tb_MoTa.Text);
                            //httpClient.QueryString.Add("listIdDep", "576,577");
                            foreach (string idPB in clsBien.listIDPhongBan)
                            {
                                httpClient.QueryString.Add("listIdDep", idPB);
                            }
                            foreach (string idNV in clsBien.listIDNhanVien)
                            {
                                httpClient.QueryString.Add("listIdEpl", idNV);
                            }
                            httpClient.UploadValuesCompleted += (sender1, e1) =>
                            {
                                frmNhomKhachHangNhanVien frm = new frmNhomKhachHangNhanVien(dt, frmMain);
                                pnlHienThi.Children.Clear();
                                object content = frm.Content;
                                frm.Content = null;
                                //frm.Close();
                                pnlHienThi.Children.Add(content as UIElement);
                                //APIRequestContact receiveInfo = JsonConvert.DeserializeObject(UnicodeEncoding.UTF8.GetString(e.Result));
                                //if (receiveInfo.data != null)
                                //{
                                //    DataChat.Socket.DeleteContact(contactId, userId);
                                //}
                            };
                            httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "addGroupCustomer"), "POST", httpClient.QueryString);
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
                            httpClient.Headers.Add("Authorization", dt.token);
                            httpClient.QueryString.Add("name", tb_TenNhomKhachHang.Text);
                            httpClient.QueryString.Add("description", tb_MoTa.Text);
                            httpClient.QueryString.Add("groupParent", IdNhomKhachHangCha);
                            //httpClient.QueryString.Add("groupParent", null);
                            //httpClient.QueryString.Add("listIdDep", null);
                            //httpClient.QueryString.Add("listIdEpl", null);

                            httpClient.UploadValuesCompleted += (sender1, e1) =>
                            {
                                frmNhomKhachHangNhanVien frm = new frmNhomKhachHangNhanVien(dt, frmMain);
                                pnlHienThi.Children.Clear();
                                object content = frm.Content;
                                frm.Content = null;
                                //frm.Close();
                                pnlHienThi.Children.Add(content as UIElement);
                                //APIRequestContact receiveInfo = JsonConvert.DeserializeObject(UnicodeEncoding.UTF8.GetString(e.Result));
                                //if (receiveInfo.data != null)
                                //{
                                //    DataChat.Socket.DeleteContact(contactId, userId);
                                //}
                            };
                            httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "addGroupCustomer"), "POST", httpClient.QueryString);

                        }
                        catch
                        {
                        }
                    }
                }
            }
            else if (tb_TieuDe.Text == "Chỉnh sửa nhóm khách hàng")
            {
                using (WebClient httpClient = new WebClient())
                {
                    try
                    {
                        httpClient.Headers.Add("Authorization", dt.token);
                        httpClient.QueryString.Add("id", MaNhomKhachHang);
                        httpClient.QueryString.Add("name", tb_TenNhomKhachHang.Text);
                        httpClient.QueryString.Add("description", tb_MoTa.Text);
                        httpClient.QueryString.Add("groupParent", IdNhomKhachHangCha);
                        //httpClient.QueryString.Add("listIdDep", null);
                        //httpClient.QueryString.Add("listIdEpl", null);

                        httpClient.UploadValuesCompleted += (sender1, e1) =>
                        {
                            frmNhomKhachHangNhanVien frm = new frmNhomKhachHangNhanVien(dt, frmMain);
                            pnlHienThi.Children.Clear();
                            object content = frm.Content;
                            frm.Content = null;
                            //frm.Close();
                            pnlHienThi.Children.Add(content as UIElement);
                            //APIRequestContact receiveInfo = JsonConvert.DeserializeObject(UnicodeEncoding.UTF8.GetString(e.Result));
                            //if (receiveInfo.data != null)
                            //{
                            //    DataChat.Socket.DeleteContact(contactId, userId);
                            //}
                        };
                        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateGroupCustomer"), "POST", httpClient.QueryString);

                    }
                    catch
                    {
                    }
                }
            }
        }
        public void LoadDataNhomKH(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listGroupCustomer";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    RootCustomer api = JsonConvert.DeserializeObject<RootCustomer>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            lstNhomKH.Add(item);
                            cboNhomKhachHangCha.Items.Add(item.gr_name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }

        }

        public void LoadDataPhongBan(/*Model.APIEntity.DataLogin_Company data*/)
        {
            try
            {
                //cbx.Items.Clear();
                using (WebClient webClient = new WebClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://chamcong.24hpay.vn/service/list_department.php";
                    webClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = webClient.UploadValues(new Uri(url), webClient.QueryString);
                    Root api = JsonConvert.DeserializeObject<Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            lstPhongBan.Add(item);
                        }
                        //lst = lst.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }

        }
        public void LoadDataNhanVien(/*Model.APIEntity.DataLogin_Company data*/)
        {
            try
            {
                //cbx.Items.Clear();
                using (WebClient webClient = new WebClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://chamcong.24hpay.vn/service/list_all_employee_of_company.php";
                    webClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = webClient.UploadValues(new Uri(url), webClient.QueryString);
                    clsNhanVien.Root api = JsonConvert.DeserializeObject<clsNhanVien.Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            lstNhanVien.Add(item);
                        }
                        //lst = lst.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }

        }

        private void selectBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //cboNhanVien.Items.Clear();

            //foreach (string ss in clsBien.listPhongBan)
            //{

            //    cboNhanVien.Items.Add(ss);
            //}
        }
        private List<string> test = new List<string>();

        private void cboNhanVien_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void ComboboxNhanVienThuocPhongBan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }



        //private List<clsPhongBan> _listPhongBan = new List<clsPhongBan>();
        //public List<clsPhongBan> listPhongBan { get => _listPhongBan; set { _listPhongBan = value; OnPropertyChanged("listPhongBan"); } }
        //public void loadDataPhongBan()
        //{
        //    try
        //    {
        //        //cbx.Items.Clear();
        //        using (HttpClient httpClient = new HttpClient())
        //        {
        //            //string url = Properties.Resources.URL + "listGroupCustomer";
        //            string url = "https://crm.timviec365.vn/ApiWinform/listDepartment";
        //            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
        //            var kq = httpClient.GetAsync(url);
        //            RootPhongBan api = JsonConvert.DeserializeObject<RootPhongBan>(kq.Result.Content.ReadAsStringAsync().Result);
        //            if (api != null)
        //            {
        //                foreach (var item in api.data)
        //                {
        //                    listPhongBan.Add(item);
        //                    //cbx.Items.Add(item);
        //                }
        //                listPhongBan = listPhongBan.ToList();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var check = ex.Message;
        //    }
        //}
    }
}
