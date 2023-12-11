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
    /// Interaction logic for frmChiTietLienHe.xaml
    /// </summary>
    public partial class frmChiTietLienHe : Page
    {
        private clsLienHe.Datum _lstLienHe = new clsLienHe.Datum();
        public clsLienHe.Datum LstLienHe { get => _lstLienHe; set => _lstLienHe = value; }
        public clsThongTinLienHe.Data LienHe { get => _LienHe; set => _LienHe = value; }

        private clsThongTinLienHe.Data _LienHe = new clsThongTinLienHe.Data();
        public frmChiTietLienHe(clsLienHe.Datum clsLienHe)
        {
            InitializeComponent();
            LstLienHe = clsLienHe;
            LoadDLKhachHang();
        }
        private async void LoadDLKhachHang()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"infoContactCustomer?id_contact={LstLienHe.contact_id}&id_customer={LstLienHe.id_customer}";
                    var kq = await httpClient.GetAsync(url);
                    clsThongTinLienHe.Root receiveInfo = JsonConvert.DeserializeObject<clsThongTinLienHe.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        LienHe = receiveInfo.data;
                        var DuongDan = new Uri("https://crm.timviec365.vn/" + LienHe.logo);
                        var bitmap = new BitmapImage(DuongDan);
                        imgAnhKhachHang.ImageSource = bitmap;
                        textMaLienHe.Text = LienHe.contact_id;
                        textMaLienHe.Foreground = Brushes.DarkSlateGray;
                        textXungHo.Text = LienHe.vocative.detail;
                        textXungHo.Foreground = Brushes.DarkSlateGray;
                        textHoVaDem.Text = LienHe.middle_name.detail;
                        textHoVaDem.Foreground = Brushes.DarkSlateGray;
                        textTen.Text = LienHe.name;
                        textTen.Foreground = Brushes.DarkSlateGray;
                        textHoVaTen.Text = LienHe.fullname;
                        textHoVaTen.Foreground = Brushes.DarkSlateGray;
                        textChucDanh.Text = LienHe.titles.detail;
                        textChucDanh.Foreground = Brushes.DarkSlateGray;
                        textPhongBan.Text = LienHe.department.detail;
                        textPhongBan.Foreground = Brushes.DarkSlateGray;
                        textDTCoQuan.Text = LienHe.office_phone.detail;
                        textDTCoQuan.Foreground = Brushes.DarkSlateGray;
                        textDTCaNhan.Text = LienHe.personal_phone.detail;
                        textDTCaNhan.Foreground = Brushes.DarkSlateGray;
                        textEmailCoQuan.Text = LienHe.office_email.detail;
                        textEmailCoQuan.Foreground = Brushes.DarkSlateGray;
                        textEmailCaNha.Text = LienHe.personal_email.detail;
                        textEmailCaNha.Foreground = Brushes.DarkSlateGray;
                        textMangXaHoi.Text = LienHe.social.detail;
                        textMangXaHoi.Foreground = Brushes.DarkSlateGray;
                        textNguonGoc.Text = LienHe.source.detail;
                        textNguonGoc.Foreground = Brushes.DarkSlateGray;
                        textZalo.Text = LienHe.Zalo;
                        textZalo.Foreground = Brushes.DarkSlateGray;
                        textFacebook.Text = LienHe.Facebook;
                        textFacebook.Foreground = Brushes.DarkSlateGray;
                        textQuocGia.Text = LienHe.country_contact;
                        textQuocGia.Foreground = Brushes.DarkSlateGray;
                        textTinhThanhPho.Text = LienHe.city_contact.detail;
                        textTinhThanhPho.Foreground = Brushes.DarkSlateGray;
                        textQuanHuyen.Text = LienHe.district_contact.detail;
                        textQuanHuyen.Foreground = Brushes.DarkSlateGray;
                        textPhuongXa.Text = LienHe.ward_contact.detail;
                        textPhuongXa.Foreground = Brushes.DarkSlateGray;
                        textSoNhaDuongPho.Text = LienHe.street_contact.detail;
                        textSoNhaDuongPho.Foreground = Brushes.DarkSlateGray;
                        textDiaChiHoaDon.Text = LienHe.address_contact.detail;
                        textDiaChiHoaDon.Foreground = Brushes.DarkSlateGray;
                        textMaVung.Text = LienHe.area_code_contact.detail;
                        textMaVung.Foreground = Brushes.DarkSlateGray;
                        textQuocGiaGiaoHang.Text = LienHe.country_ship;
                        textQuocGiaGiaoHang.Foreground = Brushes.DarkSlateGray;
                        textTinhThanhPhoGiaoHang.Text = LienHe.city_ship.detail;
                        textTinhThanhPhoGiaoHang.Foreground = Brushes.DarkSlateGray;
                        textQuanHuyenGiaoHang.Text = LienHe.district_ship.detail;
                        textQuanHuyenGiaoHang.Foreground = Brushes.DarkSlateGray;
                        textPhuongXaGiaoHang.Text = LienHe.ward_ship.detail;
                        textPhuongXaGiaoHang.Foreground = Brushes.DarkSlateGray;
                        textSoNhaDuongPhoGiaoHang.Text = LienHe.street_ship.detail;
                        textSoNhaDuongPhoGiaoHang.Foreground = Brushes.DarkSlateGray;
                        textDiaChiDonHang.Text = LienHe.address_ship.detail;
                        textDiaChiDonHang.Foreground = Brushes.DarkSlateGray;
                        textMaVungGiaoHang.Text = LienHe.area_code_ship.detail;
                        textMaVungGiaoHang.Foreground = Brushes.DarkSlateGray;
                        textMoTa.Text = LienHe.description.detail;
                        textMoTa.Foreground = Brushes.DarkSlateGray;
                        if (LienHe.contact_type.info == "1,2,4")
                        {
                            pathDaiDien.Visibility = Visibility.Visible;
                            pathNhanHoaDon.Visibility = Visibility.Visible;
                            pathThuTruongDonVi.Visibility = Visibility.Visible;
                        }
                        else if(LienHe.contact_type.info == "1,3,4")
                        {
                            pathDaiDien.Visibility = Visibility.Visible;
                            pathGiaoHang.Visibility = Visibility.Visible;
                            pathThuTruongDonVi.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "1,2,3")
                        {
                            pathDaiDien.Visibility = Visibility.Visible;
                            pathNhanHoaDon.Visibility = Visibility.Visible;
                            pathGiaoHang.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "2,3,4")
                        {
                            pathNhanHoaDon.Visibility = Visibility.Visible;
                            pathGiaoHang.Visibility = Visibility.Visible;
                            pathThuTruongDonVi.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "1,2")
                        {
                            pathDaiDien.Visibility = Visibility.Visible;
                            pathNhanHoaDon.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "1,3")
                        {
                            pathDaiDien.Visibility = Visibility.Visible;
                            pathGiaoHang.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "1,4")
                        {
                            pathDaiDien.Visibility = Visibility.Visible;
                            pathThuTruongDonVi.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "2,3")
                        {
                            pathNhanHoaDon.Visibility = Visibility.Visible;
                            pathGiaoHang.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "2,4")
                        {
                            pathNhanHoaDon.Visibility = Visibility.Visible;
                            pathThuTruongDonVi.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "3,4")
                        {
                            pathGiaoHang.Visibility = Visibility.Visible;
                            pathThuTruongDonVi.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "1")
                        {
                            pathDaiDien.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "2")
                        {
                            pathNhanHoaDon.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "3")
                        {
                            pathGiaoHang.Visibility = Visibility.Visible;
                        }
                        else if (LienHe.contact_type.info == "4")
                        {
                            pathThuTruongDonVi.Visibility = Visibility.Visible;
                        }
                    }
                }
                catch
                {
                }
            }
        }

    }
}
