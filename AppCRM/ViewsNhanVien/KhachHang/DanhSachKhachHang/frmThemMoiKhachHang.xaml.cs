using AppCRM.Model.APIEntity;
using AppCRM.Views.KhachHang.DanhSachKhachHang;
using AppCRM.Views.KhachHang.NhomKhachHang;
using AppCRM.Views.KhachHang.TinhTrangKhachHang;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmThemMoiKhachHangNhanVien.xaml
    /// </summary>
    public partial class frmThemMoiKhachHangNhanVien : Page,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string IdKH = "";
        public DataLogin_Employee dt;
        private List<clsKhachHang.KhachHang> _lstKhachHang = new List<clsKhachHang.KhachHang>();
        public List<clsKhachHang.KhachHang> LstKhachHang { get => _lstKhachHang; set => _lstKhachHang = value; }
        private List<clsNguonKhachHang.Datum> lstNguonKH = new List<clsNguonKhachHang.Datum>();
        public List<clsNguonKhachHang.Datum> LstNguonKH { get => lstNguonKH; set => lstNguonKH = value; }
        private List<clsNhanVien.Item> _listNhanVien = new List<clsNhanVien.Item>();

        public List<clsNhanVien.Item> ListNhanVien { get => _listNhanVien; set => _listNhanVien = value; }

        private List<clsTinhThanh.Datum> _listTinhThanh = new List<clsTinhThanh.Datum>();
        public List<clsTinhThanh.Datum> ListTinhThanh { get => _listTinhThanh; set => _listTinhThanh = value; }
        private List<clsQuanHuyen.Datum> _listQuanHuyen = new List<clsQuanHuyen.Datum>();
        public List<clsQuanHuyen.Datum> ListQuanHuyen { get => _listQuanHuyen; set => _listQuanHuyen = value; }
        private List<clsPhuongXa.Datum> _listPhuongXa = new List<clsPhuongXa.Datum>();
        public List<clsPhuongXa.Datum> ListPhuongXa { get => _listPhuongXa; set => _listPhuongXa = value; }
        private List<clsLoaiHinhKhachHang.Datum> _listLoaiHinhKH = new List<clsLoaiHinhKhachHang.Datum>();
        public List<clsLoaiHinhKhachHang.Datum> ListLoaiHinhKH { get => _listLoaiHinhKH; set => _listLoaiHinhKH = value; }
        private List<clsPhanLoaiKhachHang.Datum> _listPhanLoaiKH = new List<clsPhanLoaiKhachHang.Datum>();
        public List<clsPhanLoaiKhachHang.Datum> ListPhanLoaiKH { get => _listPhanLoaiKH; set => _listPhanLoaiKH = value; }
        private List<clsLinhVucKH.Datum> _listLinhVuc = new List<clsLinhVucKH.Datum>();
        public List<clsLinhVucKH.Datum> ListLinhVuc { get => _listLinhVuc; set => _listLinhVuc = value; }
        private List<clsNganhNgheKH.Datum> _listNganhNghe = new List<clsNganhNgheKH.Datum>();
        public List<clsNganhNgheKH.Datum> ListNganhNghe { get => _listNganhNghe; set => _listNganhNghe = value; }
        private List<clsNhomKhachHangMacDinh.Datum> _lstNhomKHCha = new List<clsNhomKhachHangMacDinh.Datum>();
        public List<clsNhomKhachHangMacDinh.Datum> LstNhomKhachHangCha { get => _lstNhomKHCha; set => _lstNhomKHCha = value; }
        private List<clsNhomKHConMacDinh.Datum> _lstNhomKhachHang = new List<clsNhomKHConMacDinh.Datum>();
        public List<clsNhomKHConMacDinh.Datum> LstNhomKhachHang { get => _lstNhomKhachHang; set => _lstNhomKhachHang = value; }
        private List<clsTinhTrangKhachHang.Datum> _lstTinhTrang = new List<clsTinhTrangKhachHang.Datum>();
        public List<clsTinhTrangKhachHang.Datum> LstTinhTrang { get => _lstTinhTrang; set => _lstTinhTrang = value; }
        private List<clsNganHang.Datum> _lstNganHang = new List<clsNganHang.Datum>();
        public List<clsNganHang.Datum> LstNganHang { get => _lstNganHang; set => _lstNganHang = value; }
        private List<clsDoanhThu.Datum> _lstDoanhThu = new List<clsDoanhThu.Datum>();
        public List<clsDoanhThu.Datum> LstDoanhThu { get => _lstDoanhThu; set => _lstDoanhThu = value; }
        private List<clsQuyMoNhanSu.Datum> _lstQuyMoNhanSu = new List<clsQuyMoNhanSu.Datum>();
        public List<clsQuyMoNhanSu.Datum> LstQuyMoNhanSu { get => _lstQuyMoNhanSu; set => _lstQuyMoNhanSu = value; }
        private List<clsXepHangKhachHang.Datum> _lstXepHangKhachHang = new List<clsXepHangKhachHang.Datum>();
        public List<clsXepHangKhachHang.Datum> LstXepHangKhachHang { get => _lstXepHangKhachHang; set => _lstXepHangKhachHang = value; }
        private List<Class.clsPhongBanThuocCongTy.Item> lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        private string TSD = "";
        private frmThanhMenuDoc Main;
        public frmThemMoiKhachHangNhanVien(frmThanhMenuDoc main, string TieuDe, clsKhachHang.KhachHang khachhang, List<clsNhanVien.Item> listNV, List<clsTinhTrangKhachHang.Datum> listTT, List<clsNhomKHConMacDinh.Datum> listNhomKH,List<clsNhomKhachHangMacDinh.Datum> listNhomCha, DataLogin_Employee data, List<clsNguonKhachHang.Datum> lstNguon, List<clsKhachHang.KhachHang> lstKH, string tongsodong, List<clsNganHang.Datum> listNH, List<clsDoanhThu.Datum> listDT, List<clsQuyMoNhanSu.Datum> listQMNS, List<clsXepHangKhachHang.Datum> listXHKH, List<clsLoaiHinhKhachHang.Datum> listLHKH, List<clsPhanLoaiKhachHang.Datum> listPLKH, List<clsLinhVucKH.Datum> listLVKH, List<clsNganhNgheKH.Datum> listNNKH, List<clsTinhThanh.Datum> listTTH,List<Class.clsPhongBanThuocCongTy.Item> lstPB)
        {
            InitializeComponent();
            this.DataContext = this;
            Main = main;
            textTieuDe.Text = TieuDe;
            ListNhanVien = listNV;
            lstPhongBan = lstPB;
            dt = data;
            LstNguonKH = lstNguon;
            LstNhomKhachHang = listNhomKH;
            LstNhomKhachHangCha = listNhomCha;
            LstTinhTrang = listTT;
            LstKhachHang = lstKH;
            TSD = tongsodong;
            foreach (clsNguonKhachHang.Datum nkh in lstNguon)
            {
                cboNguonKH.Items.Add(nkh.value);
            }
            foreach (clsNhanVien.Item nv in listNV)
            {
                cboNhanVienPhuTrach.Items.Add(nv.ep_name);
            }
            foreach (clsTinhTrangKhachHang.Datum tt in listTT)
            {
                if (tt.status == 1)
                {
                    cboTinhTrangKhachHang.Items.Add(tt.stt_name);
                }
            }
            foreach (clsNhomKHConMacDinh.Datum nhom in listNhomKH)
            {
                cboNhomKhachHang.Items.Add(nhom.gr_name);
                

            }
            LstNganHang = listNH;
            foreach (clsNganHang.Datum nh in listNH)
            {
                cboMoTaiNganHang.Items.Add(nh.value);
            }
            LstDoanhThu = listDT;
            foreach (clsDoanhThu.Datum dt in listDT)
            {
                cboDoanhThu.Items.Add(dt.value);
            }
            LstQuyMoNhanSu = listQMNS;
            foreach (clsQuyMoNhanSu.Datum dt in listQMNS)
            {
                cboQuyMoNhanSu.Items.Add(dt.value);
            }
            LstXepHangKhachHang = listXHKH;
            foreach (clsXepHangKhachHang.Datum xh in listXHKH)
            {
                cboXepHangKhachHang.Items.Add(xh.value);
            }
            ListLoaiHinhKH = listLHKH;
            foreach (clsLoaiHinhKhachHang.Datum xh in listLHKH)
            {
                cboLoaiHinh.Items.Add(xh.value);
            }
            ListPhanLoaiKH = listPLKH;
            foreach (clsPhanLoaiKhachHang.Datum xh in listPLKH)
            {
                cboPhanLoaiKH.Items.Add(xh.value);
            }
            ListLinhVuc = listLVKH;
            foreach (clsLinhVucKH.Datum xh in listLVKH)
            {
                cboLinhVuc.Items.Add(xh.value);
            }
            ListNganhNghe = listNNKH;
            foreach (clsNganhNgheKH.Datum xh in listNNKH)
            {
                cboNganhNghe.Items.Add(xh.value);
            }
            ListTinhThanh = listTTH;
            foreach (clsTinhThanh.Datum xh in listTTH)
            {
                cboTinhThanhPho.Items.Add(xh.cit_name);
                cboTinhThanhPhoGiaoHang.Items.Add(xh.cit_name);
            }
            IdKH = khachhang.cus_id;
            if (textTieuDe.Text == "Chỉnh sửa khách hàng")
            {
                LoadDLKhachHang();
            }
            else
            {
                radioKHDoanhNghiep.IsChecked = true;
            }
            ConnectionSocket();
        }
        private DataThongTinKH dataThongTinKH;
        public DataThongTinKH DataThongTinKH { get => dataThongTinKH; set { dataThongTinKH = value; OnPropertyChanged(); } }

        public ConnectSocket Socket { get; set; }
        public void ConnectionSocket()
        {
            try
            {
                Socket = new ConnectSocket();
                Socket.LoginSuccess(Convert.ToInt32(Properties.Settings.Default.IDChatNV), Convert.ToInt32(dt.com_id), "chat365");
                Socket.WIO.On("SendNotification", response =>
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                });
            }
            catch
            {

            }
        }
        private string DuongDanAnhDD = "";
        private string TenAnh = "";
        private async void LoadDLKhachHang()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    string url = Properties.Resources.URL + $"infoCustomer?id={IdKH}";
                    var kq = await httpClient.GetAsync(url);
                    clsThongTinKH receiveInfo = JsonConvert.DeserializeObject<clsThongTinKH>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        DataThongTinKH = receiveInfo.data;
                        tb_TenKhachHang.Text = DataThongTinKH.name;
                        tb_TenVietTat.Text = dataThongTinKH.stand_name.detail;
                        tb_MaSoThue.Text = dataThongTinKH.tax_code;
                        tb_SoDienThoai.Text = dataThongTinKH.phone_number.detail;
                        tb_Email.Text = dataThongTinKH.email.detail;
                        cboNguonKH.Text = dataThongTinKH.resoure.detail;
                        cboPhanLoaiKH.Text = dataThongTinKH.classify.detail;
                        cboLinhVuc.Text = dataThongTinKH.business_areas.detail;
                        cboLoaiHinh.Text = dataThongTinKH.business_type.detail;
                        cboNganhNghe.Text = dataThongTinKH.category.detail;
                        cboNhomKhachHang.Text = dataThongTinKH.group_id.detail;
                        cboTinhTrangKhachHang.Text = dataThongTinKH.status.detail;
                        cboNhanVienPhuTrach.Text = dataThongTinKH.emp_id.detail;
                        cboQuocGia.Text = "Việt Nam";
                        cboTinhThanhPho.Text = dataThongTinKH.bill_city.detail;
                        cboQuanHuyen.Text = dataThongTinKH.bill_district.detail;
                        cboPhuongXa.Text = dataThongTinKH.bill_ward.detail;
                        tb_SoNhaDuongPho.Text = dataThongTinKH.bill_address.detail;
                        tb_MaVung.Text = dataThongTinKH.bill_area_code.detail;
                        tb_DiaChiHoaDon.Text = dataThongTinKH.bill_invoice_address.detail;
                        //tb_EmailNhanHD.Text = dataThongTinKH.bill_invoice_address_email.ToString();
                        cboQuocGiaGiaoHang.Text = "Việt Nam";
                        cboTinhThanhPhoGiaoHang.Text = dataThongTinKH.cit_id.detail;
                        cboQuanHuyenGiaoHang.Text = dataThongTinKH.district_id.detail;
                        cboPhuongXaGiaoHang.Text = dataThongTinKH.ward.detail;
                        tb_SoNhaDuongPhoGiaoHang.Text = dataThongTinKH.address.detail;
                        tb_MaVungGiaoHang.Text = dataThongTinKH.ship_area.detail;
                        tb_DiaChiGiaoHang.Text = dataThongTinKH.ship_invoice_address.detail;
                        tb_TaiKhoanNganHang.Text = dataThongTinKH.bank_account.detail;
                        cboMoTaiNganHang.Text = dataThongTinKH.bank_id.detail;
                        dtpNgayThanhLap.Text = dataThongTinKH.birthday;
                        dtpLaKhachHangTuNgay.Text = dataThongTinKH.created_at;
                        cboDoanhThu.Text = dataThongTinKH.revenue.detail;
                        cboQuyMoNhanSu.Text = dataThongTinKH.size.detail;
                        cboXepHangKhachHang.Text = dataThongTinKH.rank.detail;
                        tb_Website.Text = dataThongTinKH.website.detail;
                        tb_HanMucNo.Text = dataThongTinKH.debt_limit.detail;
                        tb_SoNgayDuocNo.Text = dataThongTinKH.number_of_days_owed;
                        tb_MoTaKhachHang.Text = dataThongTinKH.description.detail;
                        if (dataThongTinKH.type == "1")
                        {
                            radioKHCaNhan.IsChecked = true;
                        }
                        else
                        {
                            radioKHDoanhNghiep.IsChecked = true;
                        }
                        if (dataThongTinKH.share_all == "0")
                        {
                            checkDungChung.IsChecked = true;
                        }
                        else
                        {
                            checkDungChung.IsChecked = false;
                        }
                        //DuongDanAnh = "https://crm.timviec365.vn/" + dataThongTinKH.logo;
                        DuongDanAnhDD = "https://crm.timviec365.vn/" + dataThongTinKH.logo;
                        string[] Ten1 = dataThongTinKH.logo.Split(Convert.ToChar("/"));
                        TenAnh = Ten1[Ten1.Length - 1];
                        var DuongDan = new Uri("https://crm.timviec365.vn/" + dataThongTinKH.logo);
                        var bitmap = new BitmapImage(DuongDan);
                        imgAnhKhachHang.ImageSource = bitmap;
                        string IdTinh = "";
                        string IdQuanHuyen = "";
                        string IdTinhGiaoHang = "";
                        string IdQuanHuyenGiaoHang = "";
                        foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                        {
                            if (cboTinhThanhPho.Text == tt.cit_name)
                            {
                                IdTinh = tt.cit_id;
                            }

                        }
                        LoadQuanHuyen(IdTinh);
                        foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                        {
                            if (cboQuanHuyen.Text == qh.cit_name)
                            {
                                IdQuanHuyen = qh.cit_id;
                            }

                        }
                        LoadDataPhuongXa(IdQuanHuyen);
                        foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                        {
                            if (cboTinhThanhPhoGiaoHang.Text == tt.cit_name)
                            {
                                IdTinhGiaoHang = tt.cit_id;
                            }

                        }
                        LoadQuanHuyenGiaoHang(IdTinhGiaoHang);
                        foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                        {
                            if (cboQuanHuyenGiaoHang.Text == qh.cit_name)
                            {
                                IdQuanHuyenGiaoHang = qh.cit_id;
                            }

                        }
                        LoadDataPhuongXaGiaoHang(IdQuanHuyenGiaoHang);
                    }
                }
                catch
                {
                }
            }
        }

        private void tblThemNhom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ViewsNhanVien.KhachHang.NhomKhachHang.frmNhomKhachHang frm = new NhomKhachHang.frmNhomKhachHang(dt, Main);
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            ////frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }

        private void tblThemTinhTrang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //TinhTrangKhachHang.frmTinhTrangKhachHang frm = new TinhTrangKhachHang.frmTinhTrangKhachHang(null);
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }
        private string DuongDanAnh = "";
        private void Border_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG|*.png|jpeg|*.jpg";
            DialogResult dr = open.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                DuongDanAnh = open.FileName;
                var DuongDan = new Uri(open.FileName);
                var bitmap = new BitmapImage(DuongDan);
                imgAnhKhachHang.ImageSource = bitmap;
            }
        }

        private void cboTinhThanhPho_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            if (cboTinhThanhPho.IsDropDownOpen == true)
            {
                string IdTinh = "";
                //MessageBox.Show(cboTinhThanhPho.Text);
                foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                {
                    if (name == tt.cit_name)
                    {
                        IdTinh = tt.cit_id;
                    }
                }

                LoadQuanHuyen(IdTinh);
            }

        }
        private void cboQuanHuyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            if (cboQuanHuyen.IsDropDownOpen == true)
            {
                string IdHuyen = "";
                //MessageBox.Show(cboTinhThanhPho.Text);
                foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                {
                    if (name == qh.cit_name)
                    {
                        IdHuyen = qh.cit_id;
                    }
                }

                LoadDataPhuongXa(IdHuyen);
            }

        }
        private void LoadDataPhuongXa(string Id)
        {
            if (Id != "")
            {
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"getWards?listDistrict={Id}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsPhuongXa.Root api = JsonConvert.DeserializeObject<clsPhuongXa.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            cboPhuongXa.Items.Clear();
                            foreach (var item in api.data)
                            {
                                cboPhuongXa.Items.Add(item.ward_name);
                                ListPhuongXa.Add(item);
                            }
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

            }
        }
        private void cboQuanHuyen_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {



        }
        private void LoadQuanHuyen(string Id)
        {
            if (Id != "")
            {
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"getDistrict?listCity={Id}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsQuanHuyen.Root api = JsonConvert.DeserializeObject<clsQuanHuyen.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            ListQuanHuyen.Clear();
                            cboQuanHuyen.Items.Clear();
                            foreach (var item in api.data)
                            {
                                ListQuanHuyen.Add(item);
                                cboQuanHuyen.Items.Add(item.cit_name);
                            }
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

            }
        }

        private void cboQuanHuyen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void cboTinhThanhPho_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void cboTinhThanhPhoGiaoHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            if (cboTinhThanhPhoGiaoHang.IsDropDownOpen == true)
            {
                string IdTinh = "";
                //MessageBox.Show(cboTinhThanhPho.Text);
                foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                {
                    if (name == tt.cit_name)
                    {
                        IdTinh = tt.cit_id;
                    }
                }

                LoadQuanHuyenGiaoHang(IdTinh);
            }
        }
        private void LoadQuanHuyenGiaoHang(string Id)
        {
            if (Id != "")
            {
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"getDistrict?listCity={Id}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsQuanHuyen.Root api = JsonConvert.DeserializeObject<clsQuanHuyen.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            cboQuanHuyenGiaoHang.Items.Clear();
                            foreach (var item in api.data)
                            {
                                ListQuanHuyen.Add(item);
                                cboQuanHuyenGiaoHang.Items.Add(item.cit_name);
                            }
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

            }
        }

        private void cboQuanHuyenGiaoHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            if (cboQuanHuyenGiaoHang.IsDropDownOpen == true)
            {
                string IdHuyen = "";
                //MessageBox.Show(cboTinhThanhPho.Text);
                foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                {
                    if (name == qh.cit_name)
                    {
                        IdHuyen = qh.cit_id;
                    }
                }

                LoadDataPhuongXaGiaoHang(IdHuyen);
            }
        }
        private void LoadDataPhuongXaGiaoHang(string Id)
        {
            if (Id != "")
            {
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = Properties.Resources.URL + $"getWards?listDistrict={Id}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsPhuongXa.Root api = JsonConvert.DeserializeObject<clsPhuongXa.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            cboPhuongXaGiaoHang.Items.Clear();
                            foreach (var item in api.data)
                            {
                                cboPhuongXaGiaoHang.Items.Add(item.ward_name);
                                ListPhuongXa.Add(item);
                            }
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

            }
        }
        private void bd_Luu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (textTieuDe.Text == "Chỉnh sửa khách hàng")
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/updateCustomer")))
                {
                    RestRequest request = new RestRequest();
                    request.Method = Method.Post;
                    request.AlwaysMultipartFormData = true;
                    request.AddHeader("Authorization", dt.token);
                    request.AddParameter("id", IdKH);
                    request.AddParameter("name", tb_TenKhachHang.Text);
                    if (tb_TenVietTat.Text == "")
                    {
                        request.AddParameter("stand_name", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("stand_name", tb_TenVietTat.Text);
                    }
                    if (tb_MaSoThue.Text == "")
                    {
                        request.AddParameter("tax_code", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("tax_code", tb_MaSoThue.Text);
                    }
                    if (tb_SoDienThoai.Text == "")
                    {
                        request.AddParameter("phone_number", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("phone_number", tb_SoDienThoai.Text);
                    }
                    if (tb_Email.Text == "")
                    {
                        request.AddParameter("email", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("email", tb_Email.Text);
                    }
                    if (tb_SoNhaDuongPho.Text == "")
                    {
                        request.AddParameter("bill_address", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("bill_address", tb_SoNhaDuongPho.Text);
                    }
                    if (tb_MaVung.Text == "")
                    {
                        request.AddParameter("bill_area_code", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("bill_area_code", tb_MaVung.Text);
                    }
                    if (tb_DiaChiHoaDon.Text == "")
                    {
                        request.AddParameter("bill_invoice_address", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("bill_invoice_address", tb_DiaChiHoaDon.Text);
                    }
                    if (tb_EmailNhanHD.Text == "")
                    {
                        request.AddParameter("email", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("email", tb_EmailNhanHD.Text);
                    }
                    if (tb_SoNhaDuongPhoGiaoHang.Text == "")
                    {
                        request.AddParameter("address", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("address", tb_SoNhaDuongPhoGiaoHang.Text);
                    }
                    if (tb_MaVungGiaoHang.Text == "")
                    {
                        request.AddParameter("ship_area", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("ship_area", tb_MaVungGiaoHang.Text);
                    }
                    if (tb_DiaChiGiaoHang.Text == "")
                    {
                        request.AddParameter("ship_invoice_address", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("ship_invoice_address", tb_DiaChiGiaoHang.Text);
                    }
                    if (tb_TaiKhoanNganHang.Text == "")
                    {
                        request.AddParameter("bank_account", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("bank_account", tb_TaiKhoanNganHang.Text);
                    }

                    request.AddParameter("birthday", dtpNgayThanhLap.Text);
                    request.AddParameter("customer_date_from", dtpLaKhachHangTuNgay.Text);
                    if (tb_Website.Text == "")
                    {
                        request.AddParameter("website", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("website", tb_Website.Text);
                    }
                    if (tb_HanMucNo.Text == "")
                    {
                        request.AddParameter("debt_limit", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("debt_limit", tb_HanMucNo.Text);
                    }
                    if (tb_SoNgayDuocNo.Text == "")
                    {
                        request.AddParameter("number_of_days_owed", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("number_of_days_owed", tb_SoNgayDuocNo.Text);
                    }
                    if (tb_MoTaKhachHang.Text == "")
                    {
                        request.AddParameter("description", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("description", tb_MoTaKhachHang.Text);
                    }
                    //WebClient client = new WebClient();
                    //client.DownloadFileAsync(new Uri(DuongDanAnhDD), Environment.CurrentDirectory + "\\" + TenFileHD);
                    //DuongDanAnh = Environment.CurrentDirectory + "\\" + TenFileHD;
                    //request.AddFile("logo", DuongDanAnh);
                    
                    if (checkDungChung.IsChecked == true)
                    {
                        request.AddParameter("share_all", "1");
                    }
                    else
                    {
                        request.AddParameter("share_all", "0");
                    }
                    if (radioKHCaNhan.IsChecked == true)
                    {
                        request.AddParameter("type", "1");
                    }
                    else
                    {
                        request.AddParameter("type", "2");
                    }
                    if (cboNguonKH.Text == "Chọn nguồn khách hàng")
                    {
                        request.AddParameter("resoure", "0");
                    }
                    else
                    {
                        foreach (clsNguonKhachHang.Datum nkh in LstNguonKH)
                        {
                            if (cboNguonKH.Text == nkh.value)
                            {
                                request.AddParameter("resoure", nkh.id.ToString());
                            }
                        }
                    }
                    if (cboLoaiHinh.Text == "Chọn")
                    {
                        request.AddParameter("business_type", "0");
                    }
                    else
                    {
                        foreach (clsLoaiHinhKhachHang.Datum lh in ListLoaiHinhKH)
                        {
                            if (cboLoaiHinh.Text == lh.value)
                            {
                                request.AddParameter("business_type", lh.id.ToString());
                            }
                        }
                    }
                    if (cboPhanLoaiKH.Text == "Chọn")
                    {
                        request.AddParameter("classify", "0");
                    }
                    else
                    {
                        foreach (clsPhanLoaiKhachHang.Datum pl in ListPhanLoaiKH)
                        {
                            if (cboPhanLoaiKH.Text == pl.value)
                            {
                                request.AddParameter("classify", pl.id.ToString());
                            }
                        }
                    }
                    if (cboLinhVuc.Text == "Chọn lĩnh vực")
                    {
                        request.AddParameter("business_areas", "0");
                    }
                    else
                    {
                        foreach (clsLinhVucKH.Datum lv in ListLinhVuc)
                        {
                            if (cboLinhVuc.Text == lv.value)
                            {
                                request.AddParameter("business_areas", lv.id);
                            }
                        }
                    }
                    if (cboNganhNghe.Text == "Chọn ngành nghề")
                    {
                        request.AddParameter("category", "0");
                    }
                    else
                    {
                        foreach (clsNganhNgheKH.Datum nn in ListNganhNghe)
                        {
                            if (cboNganhNghe.Text == nn.value)
                            {
                                request.AddParameter("category", nn.id.ToString());
                            }
                        }
                    }
                    if (cboNhanVienPhuTrach.Text == "Chọn nhân viên phụ trách")
                    {
                        request.AddParameter("emp_id", "0");
                    }
                    else
                    {
                        foreach (clsNhanVien.Item nv in ListNhanVien)
                        {
                            if (cboNhanVienPhuTrach.Text == nv.ep_name)
                            {
                                request.AddParameter("emp_id", nv.ep_id.ToString());
                            }
                        }
                    }
                    if (cboNhomKhachHang.Text == "Chọn nhóm khách hàng")
                    {
                        request.AddParameter("group_id", "0");
                    }
                    else
                    {
                        foreach (clsNhomKHConMacDinh.Datum con in LstNhomKhachHang)
                        {
                            if (cboNhomKhachHang.Text == con.gr_name)
                            {
                                request.AddParameter("group_id", con.gr_id.ToString());
                            }
                        }

                    }
                    if (cboTinhTrangKhachHang.Text == "Chọn tình trạng khách hàng")
                    {
                        request.AddParameter("status", "0");
                    }
                    else
                    {
                        foreach (clsTinhTrangKhachHang.Datum ttkh in LstTinhTrang)
                        {
                            if (cboTinhTrangKhachHang.Text == ttkh.stt_name)
                            {
                                request.AddParameter("status", ttkh.stt_id.ToString());
                            }
                        }
                    }
                    if (cboTinhThanhPho.Text == "Chọn tỉnh thành")
                    {
                        request.AddParameter("bill_city", "0");
                    }
                    else
                    {
                        foreach (clsTinhThanh.Datum th in ListTinhThanh)
                        {
                            if (cboTinhThanhPho.Text == th.cit_name)
                            {
                                request.AddParameter("bill_city", th.cit_id.ToString());
                            }
                        }
                    }
                    if (cboQuanHuyen.Text == "Chọn quận huyện")
                    {
                        request.AddParameter("bill_district", "0");
                    }
                    else
                    {
                        foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                        {
                            if (cboQuanHuyen.Text == qh.cit_name)
                            {
                                request.AddParameter("bill_district", qh.cit_id.ToString());
                            }
                        }
                    }
                    if (cboPhuongXa.Text == "Chọn Phường/Xã")
                    {
                        request.AddParameter("bill_ward", "0");
                    }
                    else
                    {
                        foreach (clsPhuongXa.Datum px in ListPhuongXa)
                        {
                            if (cboPhuongXa.Text == px.ward_name)
                            {
                                request.AddParameter("bill_ward", px.ward_id.ToString());
                            }
                        }
                    }
                    if (cboTinhThanhPhoGiaoHang.Text == "Chọn tỉnh thành")
                    {
                        request.AddParameter("bill_city", "0");
                    }
                    else
                    {
                        foreach (clsTinhThanh.Datum th in ListTinhThanh)
                        {
                            if (cboTinhThanhPhoGiaoHang.Text == th.cit_name)
                            {
                                request.AddParameter("cit_id", th.cit_id.ToString());
                            }
                        }
                    }
                    if (cboQuanHuyenGiaoHang.Text == "Chọn quận huyện")
                    {
                        request.AddParameter("district_id", "0");
                    }
                    else
                    {
                        foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                        {

                            if (cboQuanHuyenGiaoHang.Text == qh.cit_name)
                            {
                                request.AddParameter("district_id", qh.cit_id.ToString());
                            }
                        }
                    }
                    if (cboPhuongXaGiaoHang.Text == "Chọn Phường/Xã")
                    {
                        request.AddParameter("ward", "0");
                    }
                    else
                    {
                        foreach (clsPhuongXa.Datum px in ListPhuongXa)
                        {
                            if (cboPhuongXaGiaoHang.Text == px.ward_name)
                            {
                                request.AddParameter("ward", px.ward_id.ToString());
                            }
                        }
                    }
                    if (cboMoTaiNganHang.Text == "Chọn ngân hàng")
                    {
                        request.AddParameter("bank_id", "0");
                    }
                    else
                    {
                        foreach (clsNganHang.Datum nh in LstNganHang)
                        {
                            if (cboMoTaiNganHang.Text == nh.value)
                            {
                                request.AddParameter("bank_id", nh.id.ToString());
                            }
                        }
                    }
                    if (cboDoanhThu.Text == "Chọn doanh thu")
                    {
                        request.AddParameter("revenue", "0");
                    }
                    else
                    {
                        foreach (clsDoanhThu.Datum dt in LstDoanhThu)
                        {
                            if (cboDoanhThu.Text == dt.value)
                            {
                                request.AddParameter("revenue", dt.id.ToString());
                            }

                        }
                    }
                    if (cboQuyMoNhanSu.Text == "Chọn quy mô nhân sự")
                    {
                        request.AddParameter("size", "0");
                    }
                    else
                    {
                        foreach (clsQuyMoNhanSu.Datum qmns in LstQuyMoNhanSu)
                        {
                            if (cboQuyMoNhanSu.Text == qmns.value)
                            {
                                request.AddParameter("size", qmns.id.ToString());
                            }

                        }
                    }
                    if (cboXepHangKhachHang.Text == "Chọn xếp hạng khách hàng")
                    {
                        request.AddParameter("rank", "0");
                    }
                    else
                    {
                        foreach (clsXepHangKhachHang.Datum qmns in LstXepHangKhachHang)
                        {
                            if (cboXepHangKhachHang.Text == qmns.value)
                            {
                                request.AddParameter("rank", qmns.id.ToString());
                            }
                        }
                    }
                    if (DuongDanAnh != "")
                    {
                        request.AddFile("logo", DuongDanAnh);
                    }
                    else
                    {
                        WebClient client = new WebClient();
                        client.DownloadFileAsync(new Uri(DuongDanAnhDD), "F:\\" + TenAnh);
                        request.AddFile("logo", "F:\\" + TenAnh);
                    }
                    RestResponse resAlbum = restclient.Execute(request);
                    var b = resAlbum.Content;
                    LoadDataKhachHang(dt);
                    ConnectSocket Socket = new ConnectSocket();
                    Socket.UserDisconnect(dt.ep_id);
                    frmCustomerNhanVien frm = new frmCustomerNhanVien(Main, dt, LstKhachHang, TSD, LstNguonKH, LstNhomKhachHangCha, LstNhomKhachHang, LstTinhTrang, ListNhanVien, ListPhanLoaiKH, ListLinhVuc, ListLoaiHinhKH, ListNganhNghe, ListTinhThanh, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang, lstPhongBan);
                    pnlHienThi.Children.Clear();
                    object Content = frm.Content;
                    frm.Content = null;
                    //frm.Close();
                    pnlHienThi.Children.Add(Content as UIElement);
                    //try
                    //{
                        
                        
                    //}
                    //catch
                    //{
                    //}
                }
            }
            else
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addCustomer")))
                {
                    try
                    {
                        RestRequest request = new RestRequest();
                        request.Method = Method.Post;
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Authorization", dt.token);
                        //request.AddParameter("id", IdKH);
                        request.AddParameter("name", tb_TenKhachHang.Text);
                        if (tb_TenVietTat.Text == "")
                        {
                            request.AddParameter("stand_name", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("stand_name", tb_TenVietTat.Text);
                        }
                        if (tb_MaSoThue.Text == "")
                        {
                            request.AddParameter("tax_code", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("tax_code", tb_MaSoThue.Text);
                        }
                        if (tb_SoDienThoai.Text == "")
                        {
                            request.AddParameter("phone_number", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("phone_number", tb_SoDienThoai.Text);
                        }
                        if (tb_Email.Text == "")
                        {
                            request.AddParameter("email", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("email", tb_Email.Text);
                        }
                        if (tb_SoNhaDuongPho.Text == "")
                        {
                            request.AddParameter("bill_address", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("bill_address", tb_SoNhaDuongPho.Text);
                        }
                        if (tb_MaVung.Text == "")
                        {
                            request.AddParameter("bill_area_code", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("bill_area_code", tb_MaVung.Text);
                        }
                        if (tb_DiaChiHoaDon.Text == "")
                        {
                            request.AddParameter("bill_invoice_address", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("bill_invoice_address", tb_DiaChiHoaDon.Text);
                        }
                        //if (tb_EmailNhanHD.Text == "")
                        //{
                        //    request.AddParameter("email", "Chưa cập nhật");
                        //}
                        //else
                        //{
                        //    request.AddParameter("email", tb_EmailNhanHD.Text);
                        //}
                        if (tb_SoNhaDuongPhoGiaoHang.Text == "")
                        {
                            request.AddParameter("address", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("address", tb_SoNhaDuongPhoGiaoHang.Text);
                        }
                        if (tb_MaVungGiaoHang.Text == "")
                        {
                            request.AddParameter("ship_area", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("ship_area", tb_MaVungGiaoHang.Text);
                        }
                        if (tb_DiaChiGiaoHang.Text == "")
                        {
                            request.AddParameter("ship_invoice_address", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("ship_invoice_address", tb_DiaChiGiaoHang.Text);
                        }
                        if (tb_TaiKhoanNganHang.Text == "")
                        {
                            request.AddParameter("bank_account", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("bank_account", tb_TaiKhoanNganHang.Text);
                        }

                        request.AddParameter("birthday", dtpNgayThanhLap.Text);
                        request.AddParameter("customer_date_from", dtpLaKhachHangTuNgay.Text + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                        if (tb_Website.Text == "")
                        {
                            request.AddParameter("website", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("website", tb_Website.Text);
                        }
                        if (tb_HanMucNo.Text == "")
                        {
                            request.AddParameter("debt_limit", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("debt_limit", tb_HanMucNo.Text);
                        }
                        if (tb_SoNgayDuocNo.Text == "")
                        {
                            request.AddParameter("number_of_days_owed", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("number_of_days_owed", tb_SoNgayDuocNo.Text);
                        }
                        if (tb_MoTaKhachHang.Text == "")
                        {
                            request.AddParameter("description", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("description", tb_MoTaKhachHang.Text);
                        }

                        request.AddFile("logo", DuongDanAnh);

                        if (checkDungChung.IsChecked == true)
                        {
                            request.AddParameter("share_all", "1");
                        }
                        else
                        {
                            request.AddParameter("share_all", "0");
                        }
                        if (radioKHCaNhan.IsChecked == true)
                        {
                            request.AddParameter("type", "1");
                        }
                        else
                        {
                            request.AddParameter("type", "2");
                        }
                        if (cboNguonKH.Text == "Chọn nguồn khách hàng")
                        {
                            request.AddParameter("resoure", "0");
                        }
                        else
                        {
                            foreach (clsNguonKhachHang.Datum nkh in LstNguonKH)
                            {
                                if (cboNguonKH.Text == nkh.value)
                                {
                                    request.AddParameter("resoure", nkh.id.ToString());
                                }
                            }
                        }
                        if (cboLoaiHinh.Text == "Chọn")
                        {
                            request.AddParameter("business_type", "0");
                        }
                        else
                        {
                            foreach (clsLoaiHinhKhachHang.Datum lh in ListLoaiHinhKH)
                            {
                                if (cboLoaiHinh.Text == lh.value)
                                {
                                    request.AddParameter("business_type", lh.id.ToString());
                                }
                            }
                        }
                        if (cboPhanLoaiKH.Text == "Chọn")
                        {
                            request.AddParameter("classify", "0");
                        }
                        else
                        {
                            foreach (clsPhanLoaiKhachHang.Datum pl in ListPhanLoaiKH)
                            {
                                if (cboPhanLoaiKH.Text == pl.value)
                                {
                                    request.AddParameter("classify", pl.id.ToString());
                                }
                            }
                        }
                        if (cboLinhVuc.Text == "Chọn lĩnh vực")
                        {
                            request.AddParameter("business_areas", "0");
                        }
                        else
                        {
                            foreach (clsLinhVucKH.Datum lv in ListLinhVuc)
                            {
                                if (cboLinhVuc.Text == lv.value)
                                {
                                    request.AddParameter("business_areas", lv.id);
                                }
                            }
                        }
                        if (cboNganhNghe.Text == "Chọn ngành nghề")
                        {
                            request.AddParameter("category", "0");
                        }
                        else
                        {
                            foreach (clsNganhNgheKH.Datum nn in ListNganhNghe)
                            {
                                if (cboNganhNghe.Text == nn.value)
                                {
                                    request.AddParameter("category", nn.id.ToString());
                                }
                            }
                        }
                        if (cboNhanVienPhuTrach.Text == "Chọn nhân viên phụ trách")
                        {
                            request.AddParameter("emp_id", "0");
                        }
                        else
                        {
                            foreach (clsNhanVien.Item nv in ListNhanVien)
                            {
                                if (cboNhanVienPhuTrach.Text == nv.ep_name)
                                {
                                    request.AddParameter("emp_id", nv.ep_id.ToString());
                                }
                            }
                        }
                        if (cboNhomKhachHang.Text == "Chọn nhóm khách hàng")
                        {
                            request.AddParameter("group_id", "0");
                        }
                        else
                        {
                            foreach(clsNhomKHConMacDinh.Datum con in LstNhomKhachHang)
                            {
                                if (cboNhomKhachHang.Text == con.gr_name)
                                {
                                    request.AddParameter("group_id", con.gr_id.ToString());
                                }
                            }
                            //foreach (clsNhomKhachHang nhkh in LstNhomKhachHang)
                            //{
                            //    foreach (ListsChildCustomer nhkhc in nhkh.lists_child)
                            //    {
                                    
                            //    }
                            //}
                        }
                        if (cboTinhTrangKhachHang.Text == "Chọn tình trạng khách hàng")
                        {
                            request.AddParameter("status", "0");
                        }
                        else
                        {
                            foreach (clsTinhTrangKhachHang.Datum ttkh in LstTinhTrang)
                            {
                                if (cboTinhTrangKhachHang.Text == ttkh.stt_name)
                                {
                                    request.AddParameter("status", ttkh.stt_id.ToString());
                                }
                            }
                        }
                        if (cboTinhThanhPho.Text == "Chọn tỉnh thành")
                        {
                            request.AddParameter("bill_city", "0");
                        }
                        else
                        {
                            foreach (clsTinhThanh.Datum th in ListTinhThanh)
                            {
                                if (cboTinhThanhPho.Text == th.cit_name)
                                {
                                    request.AddParameter("bill_city", th.cit_id.ToString());
                                }
                            }
                        }
                        if (cboQuanHuyen.Text == "Chọn quận huyện")
                        {
                            request.AddParameter("bill_district", "0");
                        }
                        else
                        {
                            foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                            {
                                if (cboQuanHuyen.Text == qh.cit_name)
                                {
                                    request.AddParameter("bill_district", qh.cit_id.ToString());
                                }
                            }
                        }
                        if (cboPhuongXa.Text == "Chọn Phường/Xã")
                        {
                            request.AddParameter("bill_ward", "0");
                        }
                        else
                        {
                            foreach (clsPhuongXa.Datum px in ListPhuongXa)
                            {
                                if (cboPhuongXa.Text == px.ward_name)
                                {
                                    request.AddParameter("bill_ward", px.ward_id.ToString());
                                }
                            }
                        }
                        if (cboTinhThanhPhoGiaoHang.Text == "Chọn tỉnh thành")
                        {
                            request.AddParameter("bill_city", "0");
                        }
                        else
                        {
                            foreach (clsTinhThanh.Datum th in ListTinhThanh)
                            {
                                if (cboTinhThanhPhoGiaoHang.Text == th.cit_name)
                                {
                                    request.AddParameter("cit_id", th.cit_id.ToString());
                                }
                            }
                        }
                        if (cboQuanHuyenGiaoHang.Text == "Chọn quận huyện")
                        {
                            request.AddParameter("district_id", "0");
                        }
                        else
                        {
                            foreach (clsQuanHuyen.Datum qh in ListQuanHuyen)
                            {

                                if (cboQuanHuyenGiaoHang.Text == qh.cit_name)
                                {
                                    request.AddParameter("district_id", qh.cit_id.ToString());
                                }
                            }
                        }
                        if (cboPhuongXaGiaoHang.Text == "Chọn Phường/Xã")
                        {
                            request.AddParameter("ward", "0");
                        }
                        else
                        {
                            foreach (clsPhuongXa.Datum px in ListPhuongXa)
                            {
                                if (cboPhuongXaGiaoHang.Text == px.ward_name)
                                {
                                    request.AddParameter("ward", px.ward_id.ToString());
                                }
                            }
                        }
                        if (cboMoTaiNganHang.Text == "Chọn ngân hàng")
                        {
                            request.AddParameter("bank_id", "0");
                        }
                        else
                        {
                            foreach (clsNganHang.Datum nh in LstNganHang)
                            {
                                if (cboMoTaiNganHang.Text == nh.value)
                                {
                                    request.AddParameter("bank_id", nh.id.ToString());
                                }
                            }
                        }
                        if (cboDoanhThu.Text == "Chọn doanh thu")
                        {
                            request.AddParameter("revenue", "0");
                        }
                        else
                        {
                            foreach (clsDoanhThu.Datum dt in LstDoanhThu)
                            {
                                if (cboDoanhThu.Text == dt.value)
                                {
                                    request.AddParameter("revenue", dt.id.ToString());
                                }

                            }
                        }
                        if (cboQuyMoNhanSu.Text == "Chọn quy mô nhân sự")
                        {
                            request.AddParameter("size", "0");
                        }
                        else
                        {
                            foreach (clsQuyMoNhanSu.Datum qmns in LstQuyMoNhanSu)
                            {
                                if (cboQuyMoNhanSu.Text == qmns.value)
                                {
                                    request.AddParameter("size", qmns.id.ToString());
                                }

                            }
                        }
                        if (cboXepHangKhachHang.Text == "Chọn xếp hạng khách hàng")
                        {
                            request.AddParameter("rank", "0");
                        }
                        else
                        {
                            foreach (clsXepHangKhachHang.Datum qmns in LstXepHangKhachHang)
                            {
                                if (cboXepHangKhachHang.Text == qmns.value)
                                {
                                    request.AddParameter("rank", qmns.id.ToString());
                                }
                            }
                        }
                        request.AddParameter("NgayCapNhat", DateTime.Now.ToString());
                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        LoadDataKhachHang(dt);
                        frmCustomerNhanVien frm = new frmCustomerNhanVien(Main, dt, LstKhachHang, TSD, LstNguonKH,LstNhomKhachHangCha, LstNhomKhachHang, LstTinhTrang, ListNhanVien, ListPhanLoaiKH, ListLinhVuc, ListLoaiHinhKH, ListNganhNghe, ListTinhThanh, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang, lstPhongBan);
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
        }
        private void LoadDataKhachHang(Model.APIEntity.DataLogin_Employee data)
        {
            LstKhachHang = new List<clsKhachHang.KhachHang>();
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
                            foreach(clsNhomKHConMacDinh.Datum con in LstNhomKhachHang)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }

                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in LstTinhTrang)
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
                            foreach (clsNguonKhachHang.Datum lst in lstNguonKH)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in LstTinhTrang)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum nkh in LstNhomKhachHang)
                            {
                                item.DanhSachNhomKH.Add(nkh.gr_name);
                                
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
                            {
                                item.DanhSachNguonKH.Add(nguonKH.value);
                            }
                            foreach (clsNhanVien.Item lstnv in ListNhanVien)
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
                            if (item.user_create_id == "0" || item.user_create_id == null)
                            {
                                item.user_create_id = "Chưa cập nhật";
                            }
                            if (item.user_handing_over_work == "0" || item.user_handing_over_work == null)
                            {
                                item.user_handing_over_work = "Chưa cập nhật";
                            }
                            if (item.emp_id == "0" || item.emp_id == null)
                            {
                                item.emp_id = "Chưa cập nhật";
                            }
                            LstKhachHang.Add(item);
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
        private void bd_Huy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmCustomerNhanVien frm = new frmCustomerNhanVien(dt, LstKhachHang, TSD, LstNguonKH, LstNhomKhachHangCha, LstNhomKhachHang,  LstTinhTrang, ListNhanVien, ListPhanLoaiKH, ListLinhVuc, ListLoaiHinhKH, ListNganhNghe, ListTinhThanh, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang);
            pnlHienThi.Children.Clear();
            object Content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(Content as UIElement);
        }

        private void tblThemNhom_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            NhomKhachHangNhanVien.frmNhomKhachHangNhanVien frm = new NhomKhachHangNhanVien.frmNhomKhachHangNhanVien(dt, Main);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void tblThemTinhTrang_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //TinhTrangKhachHangNhanVien.frmTinhTrangKhachHangNhanVien frm = new TinhTrangKhachHangNhanVien.frmTinhTrangKhachHangNhanVien(TenCTy, dt);
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
