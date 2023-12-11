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
    /// Interaction logic for frmChiTietKH.xaml
    /// </summary>
    public partial class frmChiTietKH : Page
    {
        private DataThongTinKH _KhachHang = new DataThongTinKH();
        public DataThongTinKH KhachHang { get => _KhachHang; set => _KhachHang = value; }
        private string IdMaKH = "";
        public frmChiTietKH(clsKhachHang.KhachHang kh)
        {
            InitializeComponent();

            IdMaKH = kh.cus_id;
            LoadDLKhachHang();
            
            //textDienThoai.Text = kh.phone_number.detail;
            //textDienThoai.Foreground = Brushes.DarkSlateGray;
            //textEmail.Text = kh.email.detail;
            //textEmail.Foreground = Brushes.DarkSlateGray;
            //textTinhTrangKhachHang.Text = kh.status.detail;
            //textTinhTrangKhachHang.Foreground = Brushes.DarkSlateGray;
            //textMoTa.Text = kh.description.detail;
            //textMoTa.Foreground = Brushes.DarkSlateGray;
            //textNguonKhachHang.Text = kh.resoure.detail;
            //textNguonKhachHang.Foreground = Brushes.DarkSlateGray;
            //textNhomKhachHangCha.Text = kh.group_id.detail;
            //textNhomKhachHangCha.Foreground = Brushes.DarkSlateGray;
            //textNhanVienPhuTrach.Text = kh.emp_id.detail;
            //textNhanVienPhuTrach.Foreground = Brushes.DarkSlateGray;
            //textNgayThanhLap.Text = kh.birthday;
            //textNgayThanhLap.Foreground = Brushes.DarkSlateGray;
            //lineMaKH.X2 = colMaKH.Width.Value;
        }
        private async void LoadDLKhachHang()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"infoCustomer?id={IdMaKH}";
                    var kq = await httpClient.GetAsync(url);
                    clsThongTinKH receiveInfo = JsonConvert.DeserializeObject<clsThongTinKH>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        KhachHang = receiveInfo.data;
                        textMaKhachHang.Text = IdMaKH;
                        textMaKhachHang.Foreground = Brushes.DarkSlateGray;
                        textTenKhachHang.Text = KhachHang.name;
                        textTenKhachHang.Foreground = Brushes.DarkSlateGray;
                        textTenVietTat.Text = KhachHang.stand_name.detail;
                        if(textTenVietTat.Text!="Chưa cập nhật")
                        {
                            textTenVietTat.Foreground = Brushes.DarkSlateGray;
                        }
                        textMaSoThue.Text = KhachHang.tax_code;
                        if (textMaSoThue.Text != "Chưa cập nhật.")
                        {
                            textMaSoThue.Foreground = Brushes.DarkSlateGray;
                        }
                        textDienThoai.Text = KhachHang.phone_number.detail;
                        if (textDienThoai.Text != "Chưa cập nhật.")
                        {
                            textDienThoai.Foreground = Brushes.DarkSlateGray;
                        }
                        textEmail.Text = KhachHang.email.detail;
                        if (textEmail.Text != "Chưa cập nhật.")
                        {
                            textEmail.Foreground = Brushes.DarkSlateGray;
                        }
                        textNguonKhachHang.Text = KhachHang.resoure.detail;
                        if (textNguonKhachHang.Text != "Chưa cập nhật.")
                        {
                            textNguonKhachHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textPhanLoaiKhachHang.Text = KhachHang.classify.detail;
                        if (textPhanLoaiKhachHang.Text != "Chưa cập nhật.")
                        {
                            textPhanLoaiKhachHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textLinhVuc.Text = KhachHang.business_areas.detail;
                        if (textLinhVuc.Text != "Chưa cập nhật.")
                        {
                            textLinhVuc.Foreground = Brushes.DarkSlateGray;
                        }
                        textLoaiHinh.Text = KhachHang.business_type.detail;
                        if (textLoaiHinh.Text != "Chưa cập nhật.")
                        {
                            textLoaiHinh.Foreground = Brushes.DarkSlateGray;
                        }
                        textNganhNghe.Text = KhachHang.category.detail;
                        if (textNganhNghe.Text != "Chưa cập nhật.")
                        {
                            textNganhNghe.Foreground = Brushes.DarkSlateGray;
                        }
                        textNhomKhachHangCha.Text = KhachHang.gr_name;
                        if (textNhomKhachHangCha.Text != "Chưa cập nhật.")
                        {
                            textNhomKhachHangCha.Foreground = Brushes.DarkSlateGray;
                        }
                        textTinhTrangKhachHang.Text = KhachHang.status.detail;
                        if (textTinhTrangKhachHang.Text != "Chưa cập nhật.")
                        {
                            textTinhTrangKhachHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textNhanVienPhuTrach.Text = KhachHang.emp_id.detail;
                        if (textNhanVienPhuTrach.Text != "Chưa cập nhật.")
                        {
                            textNhanVienPhuTrach.Foreground = Brushes.DarkSlateGray;
                        }
                        textQuocGia.Text = "Việt Nam";
                        if (textQuocGia.Text != "Chưa cập nhật.")
                        {
                            textQuocGia.Foreground = Brushes.DarkSlateGray;
                        }
                        textTinhThanhPho.Text = KhachHang.bill_city.detail;
                        if (textTinhThanhPho.Text != "Chưa cập nhật.")
                        {
                            textTinhThanhPho.Foreground = Brushes.DarkSlateGray;
                        }
                        textQuanHuyen.Text = KhachHang.bill_district.detail;
                        if (textQuanHuyen.Text != "Chưa cập nhật.")
                        {
                            textQuanHuyen.Foreground = Brushes.DarkSlateGray;
                        }
                        textPhuongXa.Text = KhachHang.bill_ward.detail;
                        if (textPhuongXa.Text != "Chưa cập nhật.")
                        {
                            textPhuongXa.Foreground = Brushes.DarkSlateGray;
                        }
                        textSoNhaDuongPho.Text = KhachHang.bill_address.detail;
                        if (textSoNhaDuongPho.Text != "Chưa cập nhật.")
                        {
                            textSoNhaDuongPho.Foreground = Brushes.DarkSlateGray;
                        }
                        textMaVung.Text = KhachHang.bill_area_code.detail;
                        if (textMaVung.Text != "Chưa cập nhật.")
                        {
                            textMaVung.Foreground = Brushes.DarkSlateGray;
                        }
                        textDiaChiHoaDon.Text = KhachHang.bill_invoice_address.detail;
                        if (textDiaChiHoaDon.Text != "Chưa cập nhật.")
                        {
                            textDiaChiHoaDon.Foreground = Brushes.DarkSlateGray;
                        }
                        //tb_EmailNhanHD.Text = dataThongTinKH.bill_invoice_address_email.ToString();
                        textQuocGiaGiaoHang.Text = "Việt Nam";
                        if(textQuocGiaGiaoHang.Text!="Chưa cập nhật.")
                        {
                            textQuocGiaGiaoHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textTinhThanhPhoGiaoHang.Text = KhachHang.cit_id.detail;
                        if (textTinhThanhPhoGiaoHang.Text != "Chưa cập nhật.")
                        {
                            textTinhThanhPhoGiaoHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textQuanHuyenGiaoHang.Text = KhachHang.district_id.detail;
                        if (textQuanHuyenGiaoHang.Text != "Chưa cập nhật.")
                        {
                            textQuanHuyenGiaoHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textPhuongXaGiaoHang.Text = KhachHang.ward.detail;
                        if (textPhuongXaGiaoHang.Text != "Chưa cập nhật.")
                        {
                            textPhuongXaGiaoHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textSoNhaDuongPhoGiaoHang.Text = KhachHang.address.detail;
                        if (textSoNhaDuongPhoGiaoHang.Text != "Chưa cập nhật.")
                        {
                            textSoNhaDuongPhoGiaoHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textMaVungGiaoHang.Text = KhachHang.ship_area.detail;
                        if (textMaVungGiaoHang.Text != "Chưa cập nhật.")
                        {
                            textMaVungGiaoHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textDiaChiDonHang.Text = KhachHang.ship_invoice_address.detail;
                        if (textDiaChiDonHang.Text != "Chưa cập nhật.")
                        {
                            textDiaChiDonHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textTaiKhoanNganHang.Text = KhachHang.bank_account.detail;
                        if (textTaiKhoanNganHang.Text != "Chưa cập nhật.")
                        {
                            textTaiKhoanNganHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textMoTaiNganHang.Text = KhachHang.bank_id.detail;
                        if (textMoTaiNganHang.Text != "Chưa cập nhật.")
                        {
                            textMoTaiNganHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textNgayThanhLap.Text = KhachHang.birthday;
                        if (textNgayThanhLap.Text != "Chưa cập nhật.")
                        {
                            textNgayThanhLap.Foreground = Brushes.DarkSlateGray;
                        }
                        textLaKhachHangTu.Text = KhachHang.created_at;
                        if (textLaKhachHangTu.Text != "Chưa cập nhật.")
                        {
                            textLaKhachHangTu.Foreground = Brushes.DarkSlateGray;
                        }
                        textDoanhThu.Text = KhachHang.revenue.detail;
                        if (textDoanhThu.Text != "Chưa cập nhật.")
                        {
                            textDoanhThu.Foreground = Brushes.DarkSlateGray;
                        }
                        textQuyMoNhanSu.Text = KhachHang.size.detail;
                        if (textQuyMoNhanSu.Text != "Chưa cập nhật.")
                        {
                            textQuyMoNhanSu.Foreground = Brushes.DarkSlateGray;
                        }
                        textXepHangKhachHang.Text = KhachHang.rank.detail;
                        if (textXepHangKhachHang.Text != "Chưa cập nhật.")
                        {
                            textXepHangKhachHang.Foreground = Brushes.DarkSlateGray;
                        }
                        textWebsite.Text = KhachHang.website.detail;
                        if (textWebsite.Text != "Chưa cập nhật.")
                        {
                            textWebsite.Foreground = Brushes.DarkSlateGray;
                        }
                        textHanMucNo.Text = KhachHang.debt_limit.detail;
                        if (textHanMucNo.Text != "Chưa cập nhật.")
                        {
                            textHanMucNo.Foreground = Brushes.DarkSlateGray;
                        }
                        textSoNgayDuocNo.Text = KhachHang.number_of_days_owed;
                        if (textSoNgayDuocNo.Text != "Chưa cập nhật.")
                        {
                            textSoNgayDuocNo.Foreground = Brushes.DarkSlateGray;
                        }
                        textMoTa.Text = KhachHang.description.detail;
                        if (textMoTa.Text != "Chưa cập nhật.")
                        {
                            textMoTa.Foreground = Brushes.DarkSlateGray;
                        }
                        textNgayTao.Text = KhachHang.created_at;
                        if (textMoTa.Text != "Chưa cập nhật.")
                        {
                            textMoTa.Foreground = Brushes.DarkSlateGray;
                        }
                        if (KhachHang.type == "1")
                        {
                            textLoaiHinh2.Text = "Khách hàng cá nhân";
                            textLoaiHinh2.Foreground = Brushes.DarkSlateGray;
                        }
                        else
                        {
                            textLoaiHinh2.Text = "Khách hàng doanh nghiệp";
                            textLoaiHinh2.Foreground = Brushes.DarkSlateGray;
                        }
                        textNgaySua.Text = KhachHang.updated_at;
                        textNgaySua.Foreground = Brushes.DarkSlateGray;
                        if (KhachHang.share_all == "0")
                        {
                            icondungChung.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            icondungChung.Visibility = Visibility.Visible;
                        }
                        var DuongDan = new Uri("https://crm.timviec365.vn/" + KhachHang.logo);
                        var bitmap = new BitmapImage(DuongDan);
                        ImageAnhKH.ImageSource = bitmap;
                        lsvNhatKy.ItemsSource = KhachHang.history_edit_customer;
                    }
                }
                catch
                {
                }
            }
        }

    }
}
