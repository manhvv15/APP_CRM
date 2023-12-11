using AppCRM.Views.KhachHang.DanhSachKhachHang;
using AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien;
using AppCRM.Views.KhachHang.NhomKhachHang;
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

namespace AppCRM.Views.KhachHang.NhapLieuNhanVien
{
    /// <summary>
    /// Interaction logic for frmThemKhachHangNhanVien.xaml
    /// </summary>
    public partial class frmThemKhachHangNhanVien : Page
    {
        private List<clsNhomKhachHangMacDinh.Datum> _lstNhomKHCha = new List<clsNhomKhachHangMacDinh.Datum>();
        public List<clsNhomKhachHangMacDinh.Datum> LstNhomKHCha { get => _lstNhomKHCha; set => _lstNhomKHCha = value; }
        private List<clsNhomKHConMacDinh.Datum> _lstNhomKHCon = new List<clsNhomKHConMacDinh.Datum>();
        public List<clsNhomKHConMacDinh.Datum> LstNhomKHCon { get => _lstNhomKHCon; set => _lstNhomKHCon = value; }

        private List<clsNguonKhachHang.Datum> _lstNguonKH = new List<clsNguonKhachHang.Datum>();
        public List<clsNguonKhachHang.Datum> LstNguonKH { get => _lstNguonKH; set => _lstNguonKH = value; }


        private List<clsNhanVien.Item> _lstNV = new List<clsNhanVien.Item>();
        public List<clsNhanVien.Item> LstNV { get => _lstNV; set => _lstNV = value; }


        private List<clsKhachHang.KhachHang> _lstKH = new List<clsKhachHang.KhachHang>();
        public List<clsKhachHang.KhachHang> LstKH { get => _lstKH; set => _lstKH = value; }
        private List<TinhTrangKhachHang.clsTinhTrangKhachHang.Datum> _lstTT = new List<TinhTrangKhachHang.clsTinhTrangKhachHang.Datum>();
        public List<TinhTrangKhachHang.clsTinhTrangKhachHang.Datum> LstTT { get => _lstTT; set => _lstTT = value; }
        private string TSD = "";
        private Model.APIEntity.DataLogin_Employee data;
        private frmThanhMenuDoc frmMain;
        public frmThemKhachHangNhanVien(frmThanhMenuDoc frm, List<clsNguonKhachHang.Datum> lstNguonKH,List<clsNhomKHConMacDinh.Datum> lstNhomCon, List<clsNhomKhachHangMacDinh.Datum> lstNhomKH, List<clsNhanVien.Item> lstNhanVien, List<TinhTrangKhachHang.clsTinhTrangKhachHang.Datum> lstTinhTrang, Model.APIEntity.DataLogin_Employee dt)
        {
            InitializeComponent();
            frmMain = frm;
            frmMain.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            LstNhomKHCha = lstNhomKH;
            LstNguonKH = lstNguonKH;
            LstNV = lstNhanVien;
            LstTT = lstTinhTrang;
            data = dt;
            cboNhomKhachHangCha.Text = "Chọn nhóm khách hàng cha";
            cboNhomKhachHangCha.Items.Add("Chọn nhóm khách hàng cha");
            cboNhomKhachHangCon.Text = "Chọn nhóm khách hàng con";
            cboNhomKhachHangCon.Items.Add("Chọn nhóm khách hàng con");
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                cboNguonKhachHang.Items.Add(nguon.value);
            }
            foreach (clsNhomKhachHangMacDinh.Datum nhom in lstNhomKH)
            {
                cboNhomKhachHangCha.Items.Add(nhom.gr_name);
            }
            foreach (clsNhanVien.Item nv in lstNhanVien)
            {
                cboNhanVien.Items.Add(nv.ep_id + "-" + nv.ep_name + "-" + nv.dep_name);
            }
        }
        private void cboNhomKhachHangCha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string IdCha = "";
            if (cboNhomKhachHangCha.SelectedValue.ToString() == "Chọn nhóm khách hàng cha")
            {
                cboNhomKhachHangCon.Items.Clear();
                cboNhomKhachHangCon.Items.Add("Chọn nhóm khách hàng con");
                cboNhomKhachHangCon.Text = "Chọn nhóm khách hàng con";
            }
            else
            {
                cboNhomKhachHangCon.Items.Clear();
                cboNhomKhachHangCon.Items.Add("Chọn nhóm khách hàng con");
                foreach (clsNhomKhachHangMacDinh.Datum nhomcha in LstNhomKHCha)
                {

                    //cboNhomKhachHangCon.Items.Clear();
                    if (cboNhomKhachHangCha.SelectedValue.ToString() == nhomcha.gr_name)
                    {
                        IdCha = nhomcha.gr_id;
                        IdCha = nhomcha.gr_id;
                        using (HttpClient httpClient = new HttpClient())
                        {
                            //string url = Properties.Resources.URL + "listGroupCustomer";
                            string url = $"https://crm.timviec365.vn/ApiWinform/listGroup?groupId={IdCha}";
                            httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                            var kq = httpClient.GetAsync(url);
                            clsNhomKHConMacDinh.Root api = JsonConvert.DeserializeObject<clsNhomKHConMacDinh.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                foreach (var item in api.data)
                                {
                                    cboNhomKhachHangCon.Items.Add(item.gr_name);

                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnLuu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addCustomerByInput")))
            {
                try
                {
                    RestRequest request = new RestRequest();
                    request.Method = Method.Post;
                    request.AlwaysMultipartFormData = true;
                    request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                    //request.AddParameter("id", IdKH);
                    request.AddParameter("name", tbTenKhachHang.Text);


                    if (tbSDTKhachHang.Text == "")
                    {
                        request.AddParameter("phone_number", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("phone_number", tbSDTKhachHang.Text);
                    }
                    if (tbEmailKH.Text == "")
                    {
                        request.AddParameter("email", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("email", tbEmailKH.Text);
                    }
                    foreach (clsNguonKhachHang.Datum nguon in LstNguonKH)
                    {
                        if (cboNguonKhachHang.Text == nguon.value)
                        {
                            request.AddParameter("resoure", nguon.id);
                        }
                    }
                    foreach (clsNhomKhachHangMacDinh.Datum nhomcha in LstNhomKHCha)
                    {
                        if (cboNhomKhachHangCha.Text == nhomcha.gr_name)
                        {
                            request.AddParameter("parent_group", nhomcha.gr_id);
                        }
                        
                    }
                    foreach (clsNhomKHConMacDinh.Datum nhomcon in LstNhomKHCon)
                    {
                        if (cboNhomKhachHangCon.Text == nhomcon.gr_name)
                        {
                            request.AddParameter("child_group", nhomcon.gr_id);
                        }
                    }
                    foreach (clsNhanVien.Item item in LstNV)
                    {
                        string[] tt = cboNhanVien.Text.Split(Convert.ToChar("-"));
                        string gg = tt[0];
                        request.AddParameter("user_create_id", item.ep_id);
                        //if (gg == item.ep_name)
                        //{

                        //}
                    }
                    request.AddParameter("description", tbMoTa.Text);
                    request.AddParameter("user_create_type", "0");
                    RestResponse resAlbum = restclient.Execute(request);
                    var b = resAlbum.Content;
                    //LoadDataKhachHang(dt);
                    LoadDataKhachHang(data);
                    frmCustomerNhanVien frm = new frmCustomerNhanVien(data, LstKH, TSD, LstNguonKH, LstNhomKHCha,LstNhomKHCon, LstTT, LstNV, null, null, null, null, null, null, null, null, null);
                    pnlHienThi.Children.Clear();
                    object Content = frm.Content;
                    frm.Content = null;
                    //frm.Close();
                    pnlHienThi.Children.Add(Content as UIElement);

                }
                catch
                {
                }
            }
        }
        private void LoadDataKhachHang(Model.APIEntity.DataLogin_Employee data)
        {
            LstKH = new List<clsKhachHang.KhachHang>();

            try
            {
                //dgv.Items.Clear();
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + "listCustomer";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        TSD = api.total.ToString();

                        foreach (var item in api.data)
                        {
                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum lst in LstNhomKHCon)
                            {
                                if (item.group_id == lst.gr_id)
                                {
                                    item.group_id = lst.gr_name;
                                }
                                
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in LstTT)
                            {
                                if (item.status == lst.stt_id)
                                {
                                    item.status = lst.stt_name;
                                }
                                else if (item.status == "0")
                                {
                                    item.status = "Chưa cập nhật";
                                }
                            }
                            foreach (clsNguonKhachHang.Datum lst in LstNguonKH)
                            {
                                if (lst.id.ToString() == item.resoure)
                                {
                                    item.resoure = lst.value;
                                }
                                else if (item.resoure == "0")
                                {
                                    item.resoure = "Chưa cập nhật";
                                }
                            }
                            item.DanhSachNguonKH = new List<string>();
                            item.DanhSachNhomKH = new List<string>();
                            item.DanhSachTinhTrang = new List<string>();
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in LstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum khcon in LstNhomKHCon)
                            {
                                item.DanhSachNhomKH.Add(khcon.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in LstNguonKH)
                            {
                                item.DanhSachNguonKH.Add(nguonKH.value);
                            }
                            foreach (clsNhanVien.Item lstnv in LstNV)
                            {
                                if (item.user_create_id == lstnv.ep_id)
                                {
                                    item.user_create_id = lstnv.ep_name;
                                }

                                if (item.user_handing_over_work == lstnv.ep_id)
                                {
                                    item.user_handing_over_work = lstnv.ep_name;
                                }

                                if (item.emp_id == lstnv.ep_id)
                                {
                                    item.emp_id = lstnv.ep_name;
                                }

                            }
                            LstKH.Add(item);
                            //dgv.ItemsSource = lst;
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
}
