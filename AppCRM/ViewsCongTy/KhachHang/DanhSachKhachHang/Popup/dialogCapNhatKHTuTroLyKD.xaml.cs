using AppCRM.Views.KhachHang.NhomKhachHang;
using AppCRM.Views.KhachHang.TinhTrangKhachHang;
using Newtonsoft.Json;
using RestSharp;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.Popup
{
    /// <summary>
    /// Interaction logic for dialogCapNhatKHTuTroLyKD.xaml
    /// </summary>
    public partial class dialogCapNhatKHTuTroLyKD : UserControl
    {
        private List<clsTinhTrangKhachHang.Datum> _lstTT = new List<clsTinhTrangKhachHang.Datum>();
        public List<clsTinhTrangKhachHang.Datum> lstTT { get => _lstTT; set => _lstTT = value; }
        private List<clsNguonKhachHang.Datum> _lstNguonKH = new List<clsNguonKhachHang.Datum>();
        public List<clsNguonKhachHang.Datum> lstNguonKH { get => _lstNguonKH; set => _lstNguonKH = value; }
        private List<clsNhomKhachHangMacDinh.Datum> _lstNhomKH = new List<clsNhomKhachHangMacDinh.Datum>();
        public List<clsNhomKhachHangMacDinh.Datum> lstNhomKH { get => _lstNhomKH; set => _lstNhomKH = value; }
        private List<clsNhomKHConMacDinh.Datum> _lstNhomKHCon = new List<clsNhomKHConMacDinh.Datum>();
        public List<clsNhomKHConMacDinh.Datum> lstNhomKHCon { get => _lstNhomKHCon; set => _lstNhomKHCon = value; }
        private DanhSachKhachHang.ChiTietKhachHang.clsThongTinKHKinhDoanh.Item _KhachHang = new DanhSachKhachHang.ChiTietKhachHang.clsThongTinKHKinhDoanh.Item();
        public DanhSachKhachHang.ChiTietKhachHang.clsThongTinKHKinhDoanh.Item KhachHang { get => _KhachHang; set => _KhachHang = value; }
        private Model.APIEntity.DataLogin_Company data;
        private string IdKhachHang = "";
        private frmCustomer frmKH;
        public dialogCapNhatKHTuTroLyKD(frmCustomer frm, string IdKH, List<clsTinhTrangKhachHang.Datum> lstTinhTrang, List<clsNguonKhachHang.Datum> lstNguon, List<clsNhomKhachHangMacDinh.Datum> lstNhom, List<clsNhomKHConMacDinh.Datum> lstNhomCon, Model.APIEntity.DataLogin_Company dt)
        {
            InitializeComponent();
            frmKH = frm;
            data = dt;
            IdKhachHang = IdKH;
            lstTT = lstTinhTrang;
            lstNguonKH = lstNguon;
            lstNhomKH = lstNhom;
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                cboNguonKhachHang.Items.Add(nguon.value);
            }
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                cboTinhTrangKhachHang.Items.Add(tt.stt_name);
            }
            foreach (clsNhomKhachHangMacDinh.Datum nhom in lstNhomKH)
            {
                cboNhomKHCha.Items.Add(nhom.gr_name);
            }
            LoadThongTinKhachHangTuTLKD();
        }


        private async void LoadThongTinKhachHangTuTLKD()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    string url = Properties.Resources.URL + $"infoCustomerForAssistant?cusId={IdKhachHang}";
                    var kq = await httpClient.GetAsync(url);
                    DanhSachKhachHang.ChiTietKhachHang.clsThongTinKHKinhDoanh.Root receiveInfo = JsonConvert.DeserializeObject<DanhSachKhachHang.ChiTietKhachHang.clsThongTinKHKinhDoanh.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data.item != null)
                    {
                        KhachHang = receiveInfo.data.item;
                        tb_SoDienThoai.Text = KhachHang.phone_number;
                        tb_TenKhachHang.Text = KhachHang.name;
                        tb_EmailKH.Text = KhachHang.email;
                        tb_MoTaKhachHang.Text = KhachHang.description;
                        foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
                        {
                            if (KhachHang.resoure == nguon.id.ToString())
                            {
                                cboNguonKhachHang.Text = nguon.value;
                            }
                        }
                        foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                        {

                            if (KhachHang.status == tt.stt_id.ToString())
                            {
                                cboTinhTrangKhachHang.Text = tt.stt_name;
                            }
                        }
                        foreach (clsNhomKhachHangMacDinh.Datum nhom in lstNhomKH)
                        {
                            if (KhachHang.group_id == nhom.gr_id)
                            {
                                cboNhomKHCha.Text = nhom.gr_name;
                            }
                        }
                        dtpTuNgay.Text = KhachHang.start_date_schedule;
                        dtpDenNgay.Text = KhachHang.end_date_schedule;
                        lsv.ItemsSource = receiveInfo.data.appointment_content_call;
                    }
                }
                catch
                {
                }
            }
        }
        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;

        }

        private void btnPhongTo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pnlTroLyKD.Visibility = Visibility.Collapsed;
            pnlNoiDungLSChamSoc.Width = pnlNoiDungLSChamSoc.Width * 2;
            btnPhongTo.Visibility = Visibility.Collapsed;
            btnThuNho.Visibility = Visibility.Visible;

        }

        private void btnThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pnlTroLyKD.Visibility = Visibility.Visible;
            pnlNoiDungLSChamSoc.Width = pnlNoiDungLSChamSoc.Width / 2;
            btnPhongTo.Visibility = Visibility.Visible;
            btnThuNho.Visibility = Visibility.Collapsed;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/updateCustomerForAssistant")))
            {
                try
                {
                    RestRequest request = new RestRequest();
                    request.Method = Method.Post;
                    request.AlwaysMultipartFormData = true;
                    request.AddHeader("Authorization", data.token);
                    //request.AddParameter("id", IdKH);
                    request.AddParameter("cusId", IdKhachHang);
                    request.AddParameter("name", tb_TenKhachHang.Text);
                    request.AddParameter("email", tb_EmailKH.Text);
                    request.AddParameter("description", tb_MoTaKhachHang.Text);
                    request.AddParameter("content_call", tb_NoiDungCuocGoi.Text);

                    foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
                    {
                        if (cboNguonKhachHang.Text == nguon.value)
                        {
                            request.AddParameter("resoure", nguon.id);
                        }
                    }
                    foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                    {
                        if (cboTinhTrangKhachHang.Text == tt.stt_name)
                        {
                            request.AddParameter("status", tt.stt_id);
                        }
                    }
                    foreach (clsNhomKHConMacDinh.Datum nhom in lstNhomKHCon)
                    {
                        if (cboNhomKHCon.Text == nhom.gr_name)
                        {
                            request.AddParameter("group", nhom.gr_id);
                        }
                    }
                    request.AddParameter("start_date", dtpTuNgay.Text);
                    request.AddParameter("end_date", dtpDenNgay.Text);
                    RestResponse resAlbum = restclient.Execute(request);
                    var b = resAlbum.Content;
                    this.Visibility = Visibility.Collapsed;
                    frmKH.LoadDataKhachHang(data);
                }
                catch
                {
                }
            }


        }

        private void btnGoiDien_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", data.token);
                    httpClient.QueryString.Add("phone", tb_SoDienThoai.Text);
                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {

                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "callCustomer"), "POST", httpClient.QueryString);
                }
                catch
                {
                }
            }
        }

        private void cboNhomKHCha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string IdCha = "";
            if (cboNhomKHCha.SelectedValue.ToString() == "Chọn nhóm khách hàng")
            {
                cboNhomKHCon.Items.Clear();
                //cboNhomKHCon.Items.Add("Tất cả");
                cboNhomKHCon.Text = "Chọn nhóm khách hàng";
            }
            else
            {
                cboNhomKHCon.Items.Clear();
                cboNhomKHCon.Items.Add("Chọn nhóm khách hàng");
                foreach (clsNhomKhachHangMacDinh.Datum nhomcha in lstNhomKH)
                {
                    try
                    {
                        //cboNhomKhachHangCon.Items.Clear();
                        if (cboNhomKHCha.SelectedValue.ToString() == nhomcha.gr_name)
                        {
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
                                        cboNhomKHCon.Items.Add(item.gr_name);

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
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
