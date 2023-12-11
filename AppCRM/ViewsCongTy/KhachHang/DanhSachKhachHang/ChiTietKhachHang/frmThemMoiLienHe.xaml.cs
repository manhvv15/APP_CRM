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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmThemMoiLienHe.xaml
    /// </summary>
    public partial class frmThemMoiLienHe : Window
    {
        private clsLienHe.Datum _LienHe = new clsLienHe.Datum();
        public clsLienHe.Datum LienHe { get => _LienHe; set => _LienHe = value; }
        private clsThongTinLienHe.Data _ThongTinLH = new clsThongTinLienHe.Data();
        public clsThongTinLienHe.Data ThongTinLH { get => _ThongTinLH; set => _ThongTinLH = value; }
        private List<NhomKhachHang.Item> _listPhongBan = new List<NhomKhachHang.Item> ();
        public List<NhomKhachHang.Item> ListPhongBan { get => _listPhongBan; set => _listPhongBan = value; }
        private List<clsNguonKhachHang.Datum> _listNguonKH = new List<clsNguonKhachHang.Datum>();
        public List<clsNguonKhachHang.Datum> ListNguonKH { get => _listNguonKH; set => _listNguonKH = value; }
        private List<clsTinhThanh.Datum> _listTinhThanh = new List<clsTinhThanh.Datum>();
        public List<clsTinhThanh.Datum> ListTinhThanh { get => _listTinhThanh; set => _listTinhThanh = value; }
        private List<clsQuanHuyen.Datum> _listQuanHuyen = new List<clsQuanHuyen.Datum>();
        public List<clsQuanHuyen.Datum> ListQuanHuyen { get => _listQuanHuyen; set => _listQuanHuyen = value; }
        private List<clsPhuongXa.Datum> _listPhuongXa = new List<clsPhuongXa.Datum>();
        public List<clsPhuongXa.Datum> ListPhuongXa { get => _listPhuongXa; set => _listPhuongXa = value; }
        private string IDKhachHang = "";
        private string IdLienHe = "";
        public frmThemMoiLienHe(string TieuDe, clsLienHe.Datum LH, string idMKH)
        {
            InitializeComponent();
            this.DataContext = this;
            IDKhachHang = idMKH;
            IdLienHe = LH.contact_id;
            LienHe = LH;
            radioKHDoanhNghiep.IsChecked = true;
            
            //LoadDataPhongBan();
            LoadDataNguonKH();
            LoadDLTinhThanh();
            tb_TieuDe.Text = TieuDe;
            if (tb_TieuDe.Text == "Thêm mới liên hệ")
            {

            }
            else
            {
                LoadDLLienHe();
            }

        }
        private async void LoadDLLienHe()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"infoContactCustomer?id_contact={IdLienHe}&id_customer={IDKhachHang}";
                    var kq = await httpClient.GetAsync(url);
                    clsThongTinLienHe.Root receiveInfo = JsonConvert.DeserializeObject<clsThongTinLienHe.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        ThongTinLH = receiveInfo.data;
                        var DuongDan = new Uri("https://crm.timviec365.vn/" + ThongTinLH.logo);
                        var bitmap = new BitmapImage(DuongDan);
                        ImgKH.ImageSource = bitmap;
                        if (ThongTinLH.vocative.detail == "Chưa cập nhật.")
                        {
                            cboXungHo.Text = "Chọn";
                        }
                        else
                        {
                            cboXungHo.Text = ThongTinLH.vocative.detail;
                        }
                        //cboXungHo.Text = ThongTinLH.vocative.detail;
                        if(ThongTinLH.middle_name.detail=="Chưa cập nhật.")
                        {
                            tb_HoVaDem.Text = "";
                        }
                        else
                        {
                            tb_HoVaDem.Text = ThongTinLH.middle_name.detail;
                        }
                        if (ThongTinLH.name == "Chưa cập nhật.")
                        {
                            tb_Ten.Text = "";
                        }
                        else
                        {
                            tb_Ten.Text = ThongTinLH.name;
                        }
                        if (ThongTinLH.fullname == "Chưa cập nhật.")
                        {
                            tb_HoVaTen.Text = "";
                        }
                        else
                        {
                            tb_HoVaTen.Text = ThongTinLH.fullname;
                        }
                        if (ThongTinLH.titles.detail == "Chưa cập nhật.")
                        {
                            cboChucDanh.Text = "Chọn";
                        }
                        else
                        {
                            cboChucDanh.Text = ThongTinLH.titles.detail;
                        }
                        if (ThongTinLH.department.detail == "Chưa cập nhật.")
                        {
                            cboPhongBan.Text = "Chọn";
                        }
                        else
                        {
                            cboPhongBan.Text = ThongTinLH.department.detail;
                        }
                        if (ThongTinLH.office_phone.detail == "Chưa cập nhật.")
                        {
                            tb_DienThoaiCoQuan.Text = "";
                        }
                        else
                        {
                            tb_DienThoaiCoQuan.Text = ThongTinLH.office_phone.detail;
                        }
                        if (ThongTinLH.office_email.detail == "Chưa cập nhật.")
                        {
                            tb_EmailCoQuan.Text = "";
                        }
                        else
                        {
                            tb_EmailCoQuan.Text = ThongTinLH.office_email.detail;
                        }
                        if (ThongTinLH.contact_type.info == "1,2,4")
                        {
                            chkLienHeDaiDien.IsChecked = true;
                            chkLienHeNhanHoaDon.IsChecked = true;
                            chkLienHeThuTruongDonVi.IsChecked = true;
                        }
                        else if(ThongTinLH.contact_type.info == "1,3,4")
                        {
                            chkLienHeDaiDien.IsChecked = true;
                            chkLienHeGiaoHang.IsChecked = true;
                            chkLienHeThuTruongDonVi.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "1,2,3")
                        {
                            chkLienHeDaiDien.IsChecked = true;
                            chkLienHeNhanHoaDon.IsChecked = true;
                            chkLienHeGiaoHang.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "2,3,4")
                        {
                            chkLienHeNhanHoaDon.IsChecked = true;
                            chkLienHeGiaoHang.IsChecked = true;
                            chkLienHeThuTruongDonVi.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "1,2")
                        {
                            chkLienHeDaiDien.IsChecked = true;
                            chkLienHeNhanHoaDon.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "1,3")
                        {
                            chkLienHeDaiDien.IsChecked = true;
                            chkLienHeGiaoHang.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "1,4")
                        {
                            chkLienHeDaiDien.IsChecked = true;
                            chkLienHeThuTruongDonVi.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "2,3")
                        {
                            chkLienHeNhanHoaDon.IsChecked = true;
                            chkLienHeGiaoHang.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "2,4")
                        {
                            chkLienHeNhanHoaDon.IsChecked = true;
                            chkLienHeThuTruongDonVi.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "3,4")
                        {
                            chkLienHeGiaoHang.IsChecked = true;
                            chkLienHeThuTruongDonVi.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "1")
                        {
                            chkLienHeDaiDien.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "2")
                        {
                            chkLienHeNhanHoaDon.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "3")
                        {
                            chkLienHeGiaoHang.IsChecked = true;
                        }
                        else if (ThongTinLH.contact_type.info == "4")
                        {
                            chkLienHeThuTruongDonVi.IsChecked = true;
                        }
                        if (ThongTinLH.accept_phone == "1")
                        {
                            chkKhongGoiDien.IsChecked = true;
                        }
                        else
                        {
                            chkKhongGoiDien.IsChecked = false;
                        }
                        if (ThongTinLH.accept_email == "1")
                        {
                            chkKhongGuiMail.IsChecked = true;
                        }
                        else
                        {
                            chkKhongGuiMail.IsChecked = false;
                        }
                        if(ThongTinLH.personal_email.detail=="Chưa cập nhật.")
                        {
                            tb_EmailCaNhan.Text = "";
                        }
                        else
                        {
                            tb_EmailCaNhan.Text = ThongTinLH.personal_email.detail;
                        }
                        if (ThongTinLH.source.detail == "Chưa cập nhật.")
                        {
                            cboNguonKH.Text = "Chọn";
                        }
                        else
                        {
                            cboNguonKH.Text = ThongTinLH.source.detail;
                        }
                        if (ThongTinLH.country_contact == "1")
                        {
                            cboQuocGiaDC.Text = "Việt Nam";
                        }
                        else
                        {
                            cboQuocGiaDC.Text = "Chọn quốc gia";
                        }
                        if(ThongTinLH.city_contact.detail=="Chưa cập nhật.")
                        {
                            cboTinhThanhPhoDC.Text = "Chọn tỉnh thành";
                        }
                        else
                        {
                            cboTinhThanhPhoDC.Text = ThongTinLH.city_contact.detail;
                        }
                        if (ThongTinLH.district_contact.detail == "Chưa cập nhật.")
                        {
                            cboQuanHuyenDC.Text = "Chọn quận huyện";
                        }
                        else
                        {
                            cboQuanHuyenDC.Text = ThongTinLH.district_contact.detail;
                        }
                        if (ThongTinLH.ward_contact.detail == "Chưa cập nhật.")
                        {
                            cboPhuongXaDC.Text = "Chọn phường xã";
                        }
                        else
                        {
                            cboPhuongXaDC.Text = ThongTinLH.ward_contact.detail;
                        }
                        if (ThongTinLH.street_contact.detail == "Chưa cập nhật.")
                        {
                            tb_SoNhaDuongPhoDC.Text = "";
                        }
                        else
                        {
                            tb_SoNhaDuongPhoDC.Text = ThongTinLH.street_contact.detail;
                        }
                        if (ThongTinLH.area_code_contact.detail == "Chưa cập nhật.")
                        {
                            tb_MaVungDC.Text = "";
                        }
                        else
                        {
                            tb_MaVungDC.Text = ThongTinLH.area_code_contact.detail;
                        }
                        if (ThongTinLH.address_contact.detail == "Chưa cập nhật.")
                        {
                            tb_DiaChiDC.Text = "";
                        }
                        else
                        {
                            tb_DiaChiDC.Text = ThongTinLH.address_contact.detail;
                        }
                        if (ThongTinLH.country_ship == "1")
                        {
                            cboQuocGiaGH.Text = "Việt Nam";
                        }
                        else
                        {
                            cboQuocGiaGH.Text = "Chọn quốc gia";
                        }
                        if (ThongTinLH.city_ship.detail == "Chưa cập nhật.")
                        {
                            cboTinhThanhPhoGiaoHang.Text = "Chọn tỉnh thành";
                        }
                        else
                        {
                            cboTinhThanhPhoGiaoHang.Text = ThongTinLH.city_ship.detail;
                        }
                        if (ThongTinLH.district_ship.detail == "Chưa cập nhật.")
                        {
                            cboQuanHuyenGH.Text = "Chọn quận huyện";
                        }
                        else
                        {
                            cboQuanHuyenGH.Text = ThongTinLH.district_ship.detail;
                        }
                        if (ThongTinLH.ward_ship.detail == "Chưa cập nhật.")
                        {
                            cboPhuongXaGH.Text = "Chọn phường xã";
                        }
                        else
                        {
                            cboPhuongXaGH.Text = ThongTinLH.ward_ship.detail;
                        }
                        if (ThongTinLH.street_ship.detail == "Chưa cập nhật.")
                        {
                            tb_SoNhaDuongPhoGiaoHang.Text = "";
                        }
                        else
                        {
                            tb_SoNhaDuongPhoGiaoHang.Text = ThongTinLH.street_ship.detail;
                        }
                        if (ThongTinLH.area_code_ship.detail == "Chưa cập nhật.")
                        {
                            tb_MaVungGiaoHang.Text = "";
                        }
                        else
                        {
                            tb_MaVungGiaoHang.Text = ThongTinLH.area_code_ship.detail;
                        }
                        if (ThongTinLH.address_ship.detail == "Chưa cập nhật.")
                        {
                            tb_DiaChiGiaoHang.Text = "";
                        }
                        else
                        {
                            tb_DiaChiGiaoHang.Text = ThongTinLH.address_ship.detail;
                        }
                        if (ThongTinLH.description.detail == "Chưa cập nhật.")
                        {
                            tb_MoTa.Text = "";
                        }
                        else
                        {
                            tb_MoTa.Text = ThongTinLH.description.detail;
                        }
                        
                    }
                }
                catch
                {
                }
            }
        }
        private void textThemSDT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //lsv.Visibility = Visibility.Visible;
            //lsv.Items.Add(tb_DienThoaiCaNhan.Text);
        }
        private List<string> _lstSDT = new List<string>();

        public List<string> LstSDT { get => _lstSDT; set => _lstSDT = value; }


        private void bd_Luu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (tb_TieuDe.Text == "Thêm mới liên hệ")
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addContactCustomer")))
                {
                    try
                    {
                        RestRequest request = new RestRequest();
                        request.Method = Method.Post;
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.Token);
                        request.AddParameter("id_customer", IDKhachHang);
                        if (tb_HoVaDem.Text == "")
                        {
                            request.AddParameter("middle_name", "");
                        }
                        else
                        {
                            request.AddParameter("middle_name", tb_HoVaDem.Text);
                        }
                        if (tb_Ten.Text == "")
                        {
                            request.AddParameter("name", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("name", tb_Ten.Text);
                        }
                        if (tb_HoVaTen.Text == "")
                        {
                            request.AddParameter("fullname", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("fullname", tb_HoVaTen.Text);
                        }
                        
                        request.AddFile("logo", DuongDanAnh);
                        if (cboXungHo.Text == "Chọn")
                        {
                            request.AddParameter("vocative", "Chưa cập nhật.");
                        }
                        else
                        {
                            if (cboXungHo.Text == "Anh")
                            {
                                request.AddParameter("vocative", "1");
                            }
                            else if(cboXungHo.Text == "Chị")
                            {
                                request.AddParameter("vocative", "2");
                            }
                            else if (cboXungHo.Text == "Ông")
                            {
                                request.AddParameter("vocative", "3");
                            }
                            else if (cboXungHo.Text == "Bà")
                            {
                                request.AddParameter("vocative", "4");
                            }
                        }
                        
                        if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,3,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2,3");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2,3,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,3");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,4");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2,3");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2,4");
                        }
                        else if (chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "3,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2");
                        }
                        else if (chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "3");
                        }
                        else if (chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "4");
                        }
                        else
                        {
                            request.AddParameter("contact_type", "Chưa cập nhật.");
                        }
                        if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2,3,4");
                        }
                        if (cboChucDanh.Text == "Chọn")
                        {
                            request.AddParameter("titles", "Chưa cập nhật.");
                        }
                        else
                        {
                            if(cboChucDanh.Text=="Chủ tịch")
                            {
                                request.AddParameter("titles", "1");
                            }
                            else if(cboChucDanh.Text == "Phó chủ tịch")
                            {
                                request.AddParameter("titles", "2");
                            }
                            else if (cboChucDanh.Text == "Tổng giám đốc")
                            {
                                request.AddParameter("titles", "3");
                            }
                            else if (cboChucDanh.Text == "Phó tổng giám đốc")
                            {
                                request.AddParameter("titles", "4");
                            }
                            else if (cboChucDanh.Text == "Giám đốc")
                            {
                                request.AddParameter("titles", "5");
                            }
                            else if (cboChucDanh.Text == "Kế toán trưởng")
                            {
                                request.AddParameter("titles", "6");
                            }
                            else if (cboChucDanh.Text == "Trưởng phòng")
                            {
                                request.AddParameter("titles", "7");
                            }
                            else if (cboChucDanh.Text == "Trợ lý")
                            {
                                request.AddParameter("titles", "8");
                            }
                            else if (cboChucDanh.Text == "Nhân viên")
                            {
                                request.AddParameter("titles", "9");
                            }
                        }

                        if (cboPhongBan.Text == "Chọn")
                        {
                            request.AddParameter("department", "0");
                        }
                        else
                        {
                            if(cboPhongBan.Text=="Ban giám đốc")
                            {
                                request.AddParameter("department", "1");
                            }
                            else if(cboPhongBan.Text == "Phòng tài chính")
                            {
                                request.AddParameter("department", "2");
                            }
                            else if (cboPhongBan.Text == "Phòng nhân sự")
                            {
                                request.AddParameter("department", "3");
                            }
                            else if (cboPhongBan.Text == "Phòng marketing")
                            {
                                request.AddParameter("department", "4");
                            }
                            else if (cboPhongBan.Text == "Phòng CSKH")
                            {
                                request.AddParameter("department", "5");
                            }
                            else if (cboPhongBan.Text == "Phòng hành chính tổng hợp")
                            {
                                request.AddParameter("department", "6");
                            }
                            else if (cboPhongBan.Text == "Phòng kỹ thuật")
                            {
                                request.AddParameter("department", "7");
                            }
                            else if (cboPhongBan.Text == "Phòng kinh doanh")
                            {
                                request.AddParameter("department", "8");
                            }
                        }
                        if (tb_DienThoaiCoQuan.Text == "")
                        {
                            request.AddParameter("office_phone", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("office_phone", tb_DienThoaiCoQuan.Text);
                        }
                        if (tb_EmailCoQuan.Text == "")
                        {
                            request.AddParameter("office_email", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("office_email", tb_EmailCoQuan.Text);
                        }

                        string SDTCaNhan = "";
                        if (clsBien.listSDT.Count > 0)
                        {
                            foreach (string sdt in clsBien.listSDT)
                            {
                                SDTCaNhan = SDTCaNhan + sdt + ",";
                            }
                            SDTCaNhan = SDTCaNhan.Remove(SDTCaNhan.Length - 1);
                            request.AddParameter("personal_phone", SDTCaNhan);
                        }
                        else
                        {
                            request.AddParameter("personal_phone", "Chưa cập nhật.");
                        }
                        if (tb_EmailCaNhan.Text == "")
                        {
                            request.AddParameter("personal_email", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("personal_email", tb_EmailCaNhan.Text);
                        }

                        string IdMXH = "";
                        if (clsBien.listIDMangXaHoi.Count > 0)
                        {
                            foreach (string mxh in clsBien.listIDMangXaHoi)
                            {
                                IdMXH = IdMXH + mxh + ",";
                            }
                            IdMXH = IdMXH.Remove(IdMXH.Length - 1);
                            request.AddParameter("social", IdMXH);
                        }
                        else
                        {
                            request.AddParameter("social", "");
                        }
                        if (IdMXH != "")
                        {
                            request.AddParameter("social_detail", "Face");
                        }
                        if (cboNguonKH.Text != "Chọn")
                        {
                            foreach (clsNguonKhachHang.Datum nkh in ListNguonKH)
                            {
                                if (cboNguonKH.Text == nkh.value)
                                {
                                    request.AddParameter("source", nkh.id);
                                }
                            }
                        }
                        else
                        {
                            request.AddParameter("source", "0");
                        }
                        if (cboQuocGiaDC.Text == "Việt Nam")
                        {
                            request.AddParameter("country_contact", "1");
                        }
                        else
                        {
                            request.AddParameter("country_contact", "0");
                        }
                        if(cboTinhThanhPhoDC.Text!="Chọn tỉnh thành")
                        {
                            foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                            {
                                if (cboTinhThanhPhoDC.Text == tt.cit_name)
                                {
                                    request.AddParameter("city_contact", tt.cit_id);
                                }

                            }
                        }
                        else
                        {
                            request.AddParameter("city_contact", "0");
                        }
                        if (cboQuanHuyenDC.Text != "Chọn quận huyện")
                        {
                            foreach (clsQuanHuyen.Datum tt in ListQuanHuyen)
                            {
                                if (cboQuanHuyenDC.Text == tt.cit_name)
                                {
                                    request.AddParameter("district_contact", tt.cit_id);
                                }
                            }
                        }
                        else
                        {
                            request.AddParameter("district_contact", "0");
                        }
                        if (cboPhuongXaDC.Text != "Chọn phường xã")
                        {
                            foreach (clsPhuongXa.Datum tt in ListPhuongXa)
                            {
                                if (cboPhuongXaDC.Text == tt.ward_name)
                                {
                                    request.AddParameter("ward_contact", tt.ward_id);
                                }
                                
                            }
                        }
                        else
                        {
                            request.AddParameter("ward_contact", "0");
                        }

                        if (tb_SoNhaDuongPhoDC.Text == "")
                        {
                            request.AddParameter("street_contact", "");
                        }
                        else
                        {
                            request.AddParameter("street_contact", tb_SoNhaDuongPhoDC.Text);
                        }
                        if (tb_DiaChiDC.Text == "")
                        {
                            request.AddParameter("address_contact", "");
                        }
                        else
                        {
                            request.AddParameter("address_contact", tb_DiaChiDC.Text);
                        }
                        if (tb_MaVungDC.Text == "")
                        {
                            request.AddParameter("area_code_contact", "");
                        }
                        else
                        {
                            request.AddParameter("area_code_contact", tb_MaVungDC.Text);
                        }

                        if (cboQuanHuyenGH.Text == "Việt Nam")
                        {
                            request.AddParameter("country_ship", "1");
                        }
                        else
                        {
                            request.AddParameter("country_ship", "0");
                        }
                        if(cboTinhThanhPhoGiaoHang.Text!="Chọn tỉnh thành")
                        {
                            foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                            {
                                if (cboTinhThanhPhoGiaoHang.Text == tt.cit_name)
                                {
                                    request.AddParameter("city_ship", tt.cit_id);
                                }
                                
                            }
                        }
                        else
                        {
                            request.AddParameter("city_ship", "0");
                        }
                        if (cboQuanHuyenGH.Text != "Chọn quận huyện")
                        {
                            foreach (clsQuanHuyen.Datum tt in ListQuanHuyen)
                            {
                                if (cboQuanHuyenGH.Text == tt.cit_name)
                                {
                                    request.AddParameter("district_ship", tt.cit_id);
                                }
                                
                            }
                        }
                        else
                        {
                            request.AddParameter("district_ship", "0");
                        }
                        if(cboPhuongXaGH.Text!="Chọn phường xã")
                        {
                            foreach (clsPhuongXa.Datum tt in ListPhuongXa)
                            {
                                if (cboPhuongXaGH.Text == tt.ward_name)
                                {
                                    request.AddParameter("ward_ship", tt.ward_id);
                                }
                                
                            }
                        }
                        else
                        {
                            request.AddParameter("ward_ship", "0");
                        }
                        if (tb_SoNhaDuongPhoGiaoHang.Text == "")
                        {
                            request.AddParameter("street_ship", "");
                        }
                        else
                        {
                            request.AddParameter("street_ship", tb_SoNhaDuongPhoGiaoHang.Text);
                        }
                        if (tb_DiaChiGiaoHang.Text == "")
                        {
                            request.AddParameter("address_ship", "");
                        }
                        else
                        {
                            request.AddParameter("address_ship", tb_DiaChiGiaoHang.Text);
                        }
                        if (tb_MaVungGiaoHang.Text == "")
                        {
                            request.AddParameter("area_code_ship", "");
                        }
                        else
                        {
                            request.AddParameter("area_code_ship", tb_MaVungGiaoHang.Text);
                        }
                        if (tb_MoTa.Text == "")
                        {
                            request.AddParameter("description", "");
                        }
                        else
                        {
                            request.AddParameter("description", tb_MoTa.Text);
                        }

                        if (chkDungChung.IsChecked == true)
                        {
                            request.AddParameter("share_all", "1");
                        }
                        else
                        {
                            request.AddParameter("share_all", "0");
                        }
                        if (chkKhongGoiDien.IsChecked == true)
                        {
                            request.AddParameter("accept_phone", "1");
                        }
                        else
                        {
                            request.AddParameter("accept_phone", "0");
                        }
                        if (chkKhongGuiMail.IsChecked == true)
                        {
                            request.AddParameter("accept_email", "1");
                        }
                        else
                        {
                            request.AddParameter("accept_email", "0");
                        }
                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        frmLienHe frm = new frmLienHe(IDKhachHang);
                        pnlHienThi.Children.Clear();
                        object Content = frm.Content;
                        frm.Content = null;
                        frm.Close();
                        pnlHienThi.Children.Add(Content as UIElement);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/updateContactCustomer")))
                {
                    try
                    {
                        RestRequest request = new RestRequest();
                        request.Method = Method.Post;
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.Token);
                        request.AddParameter("contact_id", IdLienHe);
                        request.AddParameter("id_customer", IDKhachHang);
                        if (tb_HoVaDem.Text == "")
                        {
                            request.AddParameter("middle_name", "");
                        }
                        else
                        {
                            request.AddParameter("middle_name", tb_HoVaDem.Text);
                        }
                        if (tb_Ten.Text == "")
                        {
                            request.AddParameter("name", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("name", tb_Ten.Text);
                        }
                        if (tb_HoVaTen.Text == "")
                        {
                            request.AddParameter("fullname", "Chưa cập nhật");
                        }
                        else
                        {
                            request.AddParameter("fullname", tb_HoVaTen.Text);
                        }

                        request.AddFile("logo", DuongDanAnh);
                        if (cboXungHo.Text == "Chọn")
                        {
                            request.AddParameter("vocative", "Chưa cập nhật.");
                        }
                        else
                        {
                            if (cboXungHo.Text == "Anh")
                            {
                                request.AddParameter("vocative", "1");
                            }
                            else if (cboXungHo.Text == "Chị")
                            {
                                request.AddParameter("vocative", "2");
                            }
                            else if (cboXungHo.Text == "Ông")
                            {
                                request.AddParameter("vocative", "3");
                            }
                            else if (cboXungHo.Text == "Bà")
                            {
                                request.AddParameter("vocative", "4");
                            }
                        }

                        if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,3,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2,3");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2,3,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,3");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,4");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2,3");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2,4");
                        }
                        else if (chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "3,4");
                        }
                        else if (chkLienHeDaiDien.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1");
                        }
                        else if (chkLienHeNhanHoaDon.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "2");
                        }
                        else if (chkLienHeGiaoHang.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "3");
                        }
                        else if (chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "4");
                        }
                        else
                        {
                            request.AddParameter("contact_type", "Chưa cập nhật.");
                        }
                        if (chkLienHeDaiDien.IsChecked == true && chkLienHeNhanHoaDon.IsChecked == true && chkLienHeGiaoHang.IsChecked == true && chkLienHeThuTruongDonVi.IsChecked == true)
                        {
                            request.AddParameter("contact_type", "1,2,3,4");
                        }
                        if (cboChucDanh.Text == "Chọn")
                        {
                            request.AddParameter("titles", "Chưa cập nhật.");
                        }
                        else
                        {
                            if (cboChucDanh.Text == "Chủ tịch")
                            {
                                request.AddParameter("titles", "1");
                            }
                            else if (cboChucDanh.Text == "Phó chủ tịch")
                            {
                                request.AddParameter("titles", "2");
                            }
                            else if (cboChucDanh.Text == "Tổng giám đốc")
                            {
                                request.AddParameter("titles", "3");
                            }
                            else if (cboChucDanh.Text == "Phó tổng giám đốc")
                            {
                                request.AddParameter("titles", "4");
                            }
                            else if (cboChucDanh.Text == "Giám đốc")
                            {
                                request.AddParameter("titles", "5");
                            }
                            else if (cboChucDanh.Text == "Kế toán trưởng")
                            {
                                request.AddParameter("titles", "6");
                            }
                            else if (cboChucDanh.Text == "Trưởng phòng")
                            {
                                request.AddParameter("titles", "7");
                            }
                            else if (cboChucDanh.Text == "Trợ lý")
                            {
                                request.AddParameter("titles", "8");
                            }
                            else if (cboChucDanh.Text == "Nhân viên")
                            {
                                request.AddParameter("titles", "9");
                            }
                        }

                        if (cboPhongBan.Text == "Chọn")
                        {
                            request.AddParameter("department", "0");
                        }
                        else
                        {
                            if (cboPhongBan.Text == "Ban giám đốc")
                            {
                                request.AddParameter("department", "1");
                            }
                            else if (cboPhongBan.Text == "Phòng tài chính")
                            {
                                request.AddParameter("department", "2");
                            }
                            else if (cboPhongBan.Text == "Phòng nhân sự")
                            {
                                request.AddParameter("department", "3");
                            }
                            else if (cboPhongBan.Text == "Phòng marketing")
                            {
                                request.AddParameter("department", "4");
                            }
                            else if (cboPhongBan.Text == "Phòng CSKH")
                            {
                                request.AddParameter("department", "5");
                            }
                            else if (cboPhongBan.Text == "Phòng hành chính tổng hợp")
                            {
                                request.AddParameter("department", "6");
                            }
                            else if (cboPhongBan.Text == "Phòng kỹ thuật")
                            {
                                request.AddParameter("department", "7");
                            }
                            else if (cboPhongBan.Text == "Phòng kinh doanh")
                            {
                                request.AddParameter("department", "8");
                            }
                        }
                        if (tb_DienThoaiCoQuan.Text == "")
                        {
                            request.AddParameter("office_phone", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("office_phone", tb_DienThoaiCoQuan.Text);
                        }
                        if (tb_EmailCoQuan.Text == "")
                        {
                            request.AddParameter("office_email", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("office_email", tb_EmailCoQuan.Text);
                        }

                        string SDTCaNhan = "";
                        if (clsBien.listSDT.Count > 0)
                        {
                            foreach (string sdt in clsBien.listSDT)
                            {
                                SDTCaNhan = SDTCaNhan + sdt + ",";
                            }
                            SDTCaNhan = SDTCaNhan.Remove(SDTCaNhan.Length - 1);
                            request.AddParameter("personal_phone", SDTCaNhan);
                        }
                        else
                        {
                            request.AddParameter("personal_phone", "Chưa cập nhật.");
                        }
                        if (tb_EmailCaNhan.Text == "")
                        {
                            request.AddParameter("personal_email", "Chưa cập nhật.");
                        }
                        else
                        {
                            request.AddParameter("personal_email", tb_EmailCaNhan.Text);
                        }

                        string IdMXH = "";
                        if (clsBien.listIDMangXaHoi.Count > 0)
                        {
                            foreach (string mxh in clsBien.listIDMangXaHoi)
                            {
                                IdMXH = IdMXH + mxh + ",";
                            }
                            IdMXH = IdMXH.Remove(IdMXH.Length - 1);
                            request.AddParameter("social", IdMXH);
                        }
                        else
                        {
                            request.AddParameter("social", "");
                        }
                        if (IdMXH != "")
                        {
                            request.AddParameter("social_detail", "Face");
                        }
                        if (cboNguonKH.Text != "Chọn")
                        {
                            foreach (clsNguonKhachHang.Datum nkh in ListNguonKH)
                            {
                                if (cboNguonKH.Text == nkh.value)
                                {
                                    request.AddParameter("source", nkh.id);
                                }
                            }
                        }
                        else
                        {
                            request.AddParameter("source", "0");
                        }
                        if (cboQuocGiaDC.Text == "Việt Nam")
                        {
                            request.AddParameter("country_contact", "1");
                        }
                        else
                        {
                            request.AddParameter("country_contact", "0");
                        }
                        if (cboTinhThanhPhoDC.Text != "Chọn tỉnh thành")
                        {
                            foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                            {
                                if (cboTinhThanhPhoDC.Text == tt.cit_name)
                                {
                                    request.AddParameter("city_contact", tt.cit_id);
                                }

                            }
                        }
                        else
                        {
                            request.AddParameter("city_contact", "0");
                        }
                        if (cboQuanHuyenDC.Text != "Chọn quận huyện")
                        {
                            foreach (clsQuanHuyen.Datum tt in ListQuanHuyen)
                            {
                                if (cboQuanHuyenDC.Text == tt.cit_name)
                                {
                                    request.AddParameter("district_contact", tt.cit_id);
                                }
                            }
                        }
                        else
                        {
                            request.AddParameter("district_contact", "0");
                        }
                        if (cboPhuongXaDC.Text != "Chọn phường xã")
                        {
                            foreach (clsPhuongXa.Datum tt in ListPhuongXa)
                            {
                                if (cboPhuongXaDC.Text == tt.ward_name)
                                {
                                    request.AddParameter("ward_contact", tt.ward_id);
                                }

                            }
                        }
                        else
                        {
                            request.AddParameter("ward_contact", "0");
                        }

                        if (tb_SoNhaDuongPhoDC.Text == "")
                        {
                            request.AddParameter("street_contact", "");
                        }
                        else
                        {
                            request.AddParameter("street_contact", tb_SoNhaDuongPhoDC.Text);
                        }
                        if (tb_DiaChiDC.Text == "")
                        {
                            request.AddParameter("address_contact", "");
                        }
                        else
                        {
                            request.AddParameter("address_contact", tb_DiaChiDC.Text);
                        }
                        if (tb_MaVungDC.Text == "")
                        {
                            request.AddParameter("area_code_contact", "");
                        }
                        else
                        {
                            request.AddParameter("area_code_contact", tb_MaVungDC.Text);
                        }

                        if (cboQuanHuyenGH.Text == "Việt Nam")
                        {
                            request.AddParameter("country_ship", "1");
                        }
                        else
                        {
                            request.AddParameter("country_ship", "0");
                        }
                        if (cboTinhThanhPhoGiaoHang.Text != "Chọn tỉnh thành")
                        {
                            foreach (clsTinhThanh.Datum tt in ListTinhThanh)
                            {
                                if (cboTinhThanhPhoGiaoHang.Text == tt.cit_name)
                                {
                                    request.AddParameter("city_ship", tt.cit_id);
                                }

                            }
                        }
                        else
                        {
                            request.AddParameter("city_ship", "0");
                        }
                        if (cboQuanHuyenGH.Text != "Chọn quận huyện")
                        {
                            foreach (clsQuanHuyen.Datum tt in ListQuanHuyen)
                            {
                                if (cboQuanHuyenGH.Text == tt.cit_name)
                                {
                                    request.AddParameter("district_ship", tt.cit_id);
                                }

                            }
                        }
                        else
                        {
                            request.AddParameter("district_ship", "0");
                        }
                        if (cboPhuongXaGH.Text != "Chọn phường xã")
                        {
                            foreach (clsPhuongXa.Datum tt in ListPhuongXa)
                            {
                                if (cboPhuongXaGH.Text == tt.ward_name)
                                {
                                    request.AddParameter("ward_ship", tt.ward_id);
                                }

                            }
                        }
                        else
                        {
                            request.AddParameter("ward_ship", "0");
                        }
                        if (tb_SoNhaDuongPhoGiaoHang.Text == "")
                        {
                            request.AddParameter("street_ship", "");
                        }
                        else
                        {
                            request.AddParameter("street_ship", tb_SoNhaDuongPhoGiaoHang.Text);
                        }
                        if (tb_DiaChiGiaoHang.Text == "")
                        {
                            request.AddParameter("address_ship", "");
                        }
                        else
                        {
                            request.AddParameter("address_ship", tb_DiaChiGiaoHang.Text);
                        }
                        if (tb_MaVungGiaoHang.Text == "")
                        {
                            request.AddParameter("area_code_ship", "");
                        }
                        else
                        {
                            request.AddParameter("area_code_ship", tb_MaVungGiaoHang.Text);
                        }
                        if (tb_MoTa.Text == "")
                        {
                            request.AddParameter("description", "");
                        }
                        else
                        {
                            request.AddParameter("description", tb_MoTa.Text);
                        }

                        if (chkDungChung.IsChecked == true)
                        {
                            request.AddParameter("share_all", "1");
                        }
                        else
                        {
                            request.AddParameter("share_all", "0");
                        }
                        if (chkKhongGoiDien.IsChecked == true)
                        {
                            request.AddParameter("accept_phone", "1");
                        }
                        else
                        {
                            request.AddParameter("accept_phone", "0");
                        }
                        if (chkKhongGuiMail.IsChecked == true)
                        {
                            request.AddParameter("accept_email", "1");
                        }
                        else
                        {
                            request.AddParameter("accept_email", "0");
                        }
                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        frmLienHe frm = new frmLienHe(IDKhachHang);
                        pnlHienThi.Children.Clear();
                        object Content = frm.Content;
                        frm.Content = null;
                        frm.Close();
                        pnlHienThi.Children.Add(Content as UIElement);
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void LoadDataPhongBan()
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
                    NhomKhachHang.Root api = JsonConvert.DeserializeObject<NhomKhachHang.Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            ListPhongBan.Add(item);
                            cboPhongBan.Items.Add(item.dep_name);
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
        private void LoadDataNguonKH()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getResouce";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsNguonKhachHang.Root api = JsonConvert.DeserializeObject<clsNguonKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            ListNguonKH.Add(item);
                            cboNguonKH.Items.Add(item.value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void LoadDLTinhThanh()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getCity";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsTinhThanh.Root api = JsonConvert.DeserializeObject<clsTinhThanh.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            cboTinhThanhPhoDC.Items.Add(item.cit_name);
                            cboTinhThanhPhoGiaoHang.Items.Add(item.cit_name);
                            ListTinhThanh.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void tb_DienThoaiKhac_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var select = sender as TextBox;
            //string name = select.Text;
            ////LstSDT.Clear();
            //LstSDT.Add(name);
        }


        private void lsv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void selectBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (clsBien.listMangXaHoi.Contains(" Zalo"))
            {
                pnlNhapZalo.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapZalo.Visibility = Visibility.Collapsed;
            }
            if(clsBien.listMangXaHoi.Contains(" Facebook"))
            {
                pnlNhapFacebook.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapFacebook.Visibility = Visibility.Collapsed;
            }
            if (clsBien.listMangXaHoi.Contains(" Telegram"))
            {
                pnlNhapTelegram.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapTelegram.Visibility = Visibility.Collapsed;
            }
            if (clsBien.listMangXaHoi.Contains(" Twitter"))
            {
                pnlNhapTwitter.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapTwitter.Visibility = Visibility.Collapsed;
            }
            if (clsBien.listMangXaHoi.Contains(" Skype"))
            {
                pnlNhapSkype.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapSkype.Visibility = Visibility.Collapsed;
            }
            if (clsBien.listMangXaHoi.Contains(" Instagram"))
            {
                pnlNhapInstagram.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapInstagram.Visibility = Visibility.Collapsed;
            }
            if (clsBien.listMangXaHoi.Contains(" Linkedin"))
            {
                pnlNhapLinkedin.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapLinkedin.Visibility = Visibility.Collapsed;
            }
            if (clsBien.listMangXaHoi.Contains(" Tiktok"))
            {
                pnlNhapTikTok.Visibility = Visibility.Visible;
            }
            else
            {
                pnlNhapTikTok.Visibility = Visibility.Collapsed;
            }
        }
        private string hvd = "";
        private string ten = "";
        private void tb_HoVaDem_TextChanged(object sender, TextChangedEventArgs e)
        {
            var name = sender as System.Windows.Controls.TextBox;
            hvd = name.Text;
            tb_HoVaTen.Text = hvd + " " + ten;
        }

        private void tb_Ten_TextChanged(object sender, TextChangedEventArgs e)
        {
            var name = sender as System.Windows.Controls.TextBox;
            ten = name.Text;
            tb_HoVaTen.Text = hvd +" "+ ten;
        }

        private void LoadQuanHuyen(string Id)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"getDistrict?listCity={Id}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsQuanHuyen.Root api = JsonConvert.DeserializeObject<clsQuanHuyen.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        ListQuanHuyen.Clear();
                        cboQuanHuyenDC.Items.Clear();
                        foreach (var item in api.data)
                        {
                            ListQuanHuyen.Add(item);
                            cboQuanHuyenDC.Items.Add("Chọn quận huyện");
                            cboQuanHuyenDC.Text = "Chọn quận huyện";
                            cboQuanHuyenDC.Items.Add(item.cit_name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void LoadDataPhuongXa(string Id)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"getWards?listDistrict={Id}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsPhuongXa.Root api = JsonConvert.DeserializeObject<clsPhuongXa.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        cboPhuongXaDC.Items.Clear();
                        foreach (var item in api.data)
                        {
                            cboPhuongXaDC.Items.Add("Chọn phường xã");
                            cboPhuongXaDC.Text = "Chọn phường xã";
                            cboPhuongXaDC.Items.Add(item.ward_name);
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
        private void LoadQuanHuyenGiaoHang(string Id)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"getDistrict?listCity={Id}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsQuanHuyen.Root api = JsonConvert.DeserializeObject<clsQuanHuyen.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        cboQuanHuyenGH.Items.Clear();
                        foreach (var item in api.data)
                        {
                            ListQuanHuyen.Add(item);
                            cboQuanHuyenGH.Items.Add("Chọn quận huyện");
                            cboQuanHuyenGH.Text = "Chọn quận huyện";
                            cboQuanHuyenGH.Items.Add(item.cit_name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void LoadDataPhuongXaGiaoHang(string Id)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"getWards?listDistrict={Id}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsPhuongXa.Root api = JsonConvert.DeserializeObject<clsPhuongXa.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        cboPhuongXaGH.Items.Clear();
                        foreach (var item in api.data)
                        {
                            cboPhuongXaGH.Items.Add("Chọn phường xã");
                            cboPhuongXaGH.Text = "Chọn phường xã";
                            cboPhuongXaGH.Items.Add(item.ward_name);
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

        private void cboQuanHuyenDC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            if (cboQuanHuyenDC.IsDropDownOpen == true)
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

        private void cboQuanHuyenGH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            if (cboQuanHuyenGH.IsDropDownOpen == true)
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

        private void cboTinhThanhPhoDC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            if (cboTinhThanhPhoDC.IsDropDownOpen == true)
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
        private string DuongDanAnh = "";
        private void imgAnhKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG|*.png|jpeg|*.jpg";
            DialogResult dr = open.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                DuongDanAnh = open.FileName;
                var DuongDan = new Uri(open.FileName);
                var bitmap = new BitmapImage(DuongDan);
                ImgKH.ImageSource = bitmap;
            }
        }
    }
}
