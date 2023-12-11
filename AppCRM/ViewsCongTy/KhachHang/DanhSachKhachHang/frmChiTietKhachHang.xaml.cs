using AppCRM.Model.APIEntity;
using AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang;
using AppCRM.Views.KhachHang.NhomKhachHang;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHang
{
    /// <summary>
    /// Interaction logic for frmChiTietKhachHang.xaml
    /// </summary>
    public partial class frmChiTietKhachHang : Window
    {
        public string IdMaKH = "";
        
        private clsKhachHang.KhachHang _khachhang = new clsKhachHang.KhachHang();

        public clsKhachHang.KhachHang Khachhang { get => _khachhang; set => _khachhang = value; }
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        private List<Class.clsPhongBanThuocCongTy.Item> lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        frmTrangChuSauDangNhapCongTy frmMain;
        private DataLogin_Company data;
        private string TenKH = "";
        private string EmailKH = "";
        private string SdtKH = "";
        public frmChiTietKhachHang(frmTrangChuSauDangNhapCongTy Main, clsKhachHang.KhachHang kh, DataLogin_Company dt, List<clsNhanVien.Item> lstNv, List<Class.clsPhongBanThuocCongTy.Item> lstPb)
        {
            InitializeComponent();
            data = dt;
            Khachhang = kh;
            frmMain = Main;
            lstNhanVien = lstNv;
            lstPhongBan = lstPb;
            IdMaKH = kh.cus_id;
            TenKH = kh.name;
            EmailKH = kh.email;
            SdtKH = kh.phone_number;
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textThongTinChiTiet.FontWeight = FontWeights.DemiBold;
            ChiTietKhachHang.frmChiTietKH frm = new ChiTietKhachHang.frmChiTietKH(kh);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            LoadDLGhiChu();
            LoadDLTaiLieuDinhKem();
            LoadDLDanhSachTinDang();
            //MaKH = MaKhachHang;
            //TenKH = TenKhachHang;
            //SoDienThoai = SDT;
            //EmailKH = Email;
            //TinhTrangKH = TinhTrang;
            //MoTaKH = Mota;
            //NguonKhachHang = NguonKH;
            //NhomKhachHangHCha = NhomKHCha;
            //NhanVienPhuTrach = NVPhuTrach;
            //NT = NgayTao;
            //textMaKhachHang.Text = MaKhachHang;
            //textMaKhachHang.Foreground = Brushes.DarkSlateGray;
            //textTenKhachHang.Text = TenKhachHang;
            //textTenKhachHang.Foreground = Brushes.DarkSlateGray;
            //textDienThoai.Text = SDT;
            //textDienThoai.Foreground = Brushes.DarkSlateGray;
            //textEmail.Text = Email;
            //textEmail.Foreground = Brushes.DarkSlateGray;
            //textTinhTrangKhachHang.Text = TinhTrang;
            //textTinhTrangKhachHang.Foreground = Brushes.DarkSlateGray;
            //textMoTa.Text = Mota;
            //textMoTa.Foreground = Brushes.DarkSlateGray;
            //textNguonKhachHang.Text = NguonKH;
            //textNguonKhachHang.Foreground = Brushes.DarkSlateGray;
            //textNhomKhachHangCha.Text = NhomKHCha;
            //textNhomKhachHangCha.Foreground = Brushes.DarkSlateGray;
            //textNhanVienPhuTrach.Text = NVPhuTrach;
            //textNhanVienPhuTrach.Foreground = Brushes.DarkSlateGray;
            //textNgayThanhLap.Text = NgayTao;
            //textNgayThanhLap.Foreground = Brushes.DarkSlateGray;
        }

        private void btnLienHe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textLienHe.FontWeight = FontWeights.DemiBold;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmLienHe frm = new ChiTietKhachHang.frmLienHe(IdMaKH);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnThongTinChiTiet_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textThongTinChiTiet.FontWeight = FontWeights.DemiBold;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmChiTietKH frm = new ChiTietKhachHang.frmChiTietKH(Khachhang);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnCoHoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textCoHoi.FontWeight = FontWeights.DemiBold;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmCoHoi frm = new ChiTietKhachHang.frmCoHoi();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnHopDongBan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textHopDongBan.FontWeight = FontWeights.DemiBold;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmHopDongBan frm = new ChiTietKhachHang.frmHopDongBan(frmMain, IdMaKH, data, lstNhanVien, lstPhongBan, TenKH, EmailKH, SdtKH);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnDanhSachTinDang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textDanhSachTinDang.FontWeight = FontWeights.DemiBold;
            ChiTietKhachHang.frmDanhSachTinDang frm = new ChiTietKhachHang.frmDanhSachTinDang(IdMaKH, TongSoDongDSTinDang, LstDanhSachTinDang, frmMain);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnLichSuDonHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textLichSuDonHang.FontWeight = FontWeights.DemiBold;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmLichSuDonHang frm = new ChiTietKhachHang.frmLichSuDonHang();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnChienDich_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textChienDich.FontWeight = FontWeights.DemiBold;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmChienDich frm = new ChiTietKhachHang.frmChienDich(frmMain);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnBaoGia_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textBaoGia.FontWeight = FontWeights.DemiBold;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnHangHoaDaMua_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textHangHoaDaMua.FontWeight = FontWeights.DemiBold;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnHoaDon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textHoaDon.FontWeight = FontWeights.DemiBold;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnLichHen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textLichHen.FontWeight = FontWeights.DemiBold;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnCuocGoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textCuocGoi.FontWeight = FontWeights.DemiBold;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnLichSuChamSoc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textLichSuChamSoc.FontWeight = FontWeights.DemiBold;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnEmail_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textEmail.FontWeight = FontWeights.DemiBold;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnSMS_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textSMS.FontWeight = FontWeights.DemiBold;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnTaiLieuDinhKem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textTaiLieuDinhKem.FontWeight = FontWeights.DemiBold;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmTaiLieuDinhKem frm = new ChiTietKhachHang.frmTaiLieuDinhKem(IdMaKH, LstTaiLieuDinhKem, TongSoDongTaiLieuDinhKem, frmMain);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnGhiChu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textGhiChu.FontWeight = FontWeights.DemiBold;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachChiaSe.FontWeight = FontWeights.Normal;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
            ChiTietKhachHang.frmGhiChu frm = new ChiTietKhachHang.frmGhiChu(clsBien.lstGhiChu, IdMaKH, TongSoDongGhiChu, frmMain);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnDanhSachChiaSe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#474747");
            textThongTinChiTiet.FontWeight = FontWeights.Normal;
            textLienHe.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLienHe.FontWeight = FontWeights.Normal;
            textCoHoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCoHoi.FontWeight = FontWeights.Normal;
            textChienDich.Foreground = (Brush)bc.ConvertFrom("#474747");
            textChienDich.FontWeight = FontWeights.Normal;
            textBaoGia.Foreground = (Brush)bc.ConvertFrom("#474747");
            textBaoGia.FontWeight = FontWeights.Normal;
            textLichSuDonHang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuDonHang.FontWeight = FontWeights.Normal;
            textHopDongBan.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHopDongBan.FontWeight = FontWeights.Normal;
            textHangHoaDaMua.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHangHoaDaMua.FontWeight = FontWeights.Normal;
            textHoaDon.Foreground = (Brush)bc.ConvertFrom("#474747");
            textHoaDon.FontWeight = FontWeights.Normal;
            textLichHen.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichHen.FontWeight = FontWeights.Normal;
            textCuocGoi.Foreground = (Brush)bc.ConvertFrom("#474747");
            textCuocGoi.FontWeight = FontWeights.Normal;
            textLichSuChamSoc.Foreground = (Brush)bc.ConvertFrom("#474747");
            textLichSuChamSoc.FontWeight = FontWeights.Normal;
            textEmail.Foreground = (Brush)bc.ConvertFrom("#474747");
            textEmail.FontWeight = FontWeights.Normal;
            textSMS.Foreground = (Brush)bc.ConvertFrom("#474747");
            textSMS.FontWeight = FontWeights.Normal;
            textTaiLieuDinhKem.Foreground = (Brush)bc.ConvertFrom("#474747");
            textTaiLieuDinhKem.FontWeight = FontWeights.Normal;
            textGhiChu.Foreground = (Brush)bc.ConvertFrom("#474747");
            textGhiChu.FontWeight = FontWeights.Normal;
            textDanhSachChiaSe.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textDanhSachChiaSe.FontWeight = FontWeights.DemiBold;
            textDanhSachTinDang.Foreground = (Brush)bc.ConvertFrom("#474747");
            textDanhSachTinDang.FontWeight = FontWeights.Normal;
        }

        private void btnGhiChu_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

        }
        private string TongSoDongGhiChu = "";
        private string TongSoDongTaiLieuDinhKem = "";
        private string TongSoDongDSTinDang = "";
        
        private List<clsTaiLieuDinhKem.Datum> _lstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
        public List<clsTaiLieuDinhKem.Datum> LstTaiLieuDinhKem { get => _lstTaiLieuDinhKem; set => _lstTaiLieuDinhKem = value; }
        private List<clsDanhSachTinDang.Datum> _lstDanhSachTinDang = new List<clsDanhSachTinDang.Datum>();
        public List<clsDanhSachTinDang.Datum> LstDanhSachTinDang { get => _lstDanhSachTinDang; set => _lstDanhSachTinDang = value; }
        private async void LoadDLGhiChu()
        {
            clsBien.lstGhiChu = new List<clsGhiChu.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listNoteCus?customerId={IdMaKH}";

                    var kq = await httpClient.GetAsync(url);
                    clsGhiChu.Root receiveInfo = JsonConvert.DeserializeObject<clsGhiChu.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        TongSoDongGhiChu = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            if (item.user_created_id == "0")
                            {
                                item.user_created_id = "Công ty";
                            }
                            clsBien.lstGhiChu.Add(item);
                            for (int i = 1; i <= clsBien.lstGhiChu.Count; i++)
                            {
                                item.stt = i.ToString();
                            }

                        }
                        //dgv.ItemsSource = lstGhiChu.ToList();
                    }
                }
                catch
                {
                }
            }
        }
        private async void LoadDLTaiLieuDinhKem()
        {
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listFileCus?customerId={IdMaKH}";

                    var kq = await httpClient.GetAsync(url);
                    clsTaiLieuDinhKem.Root receiveInfo = JsonConvert.DeserializeObject<clsTaiLieuDinhKem.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        TongSoDongTaiLieuDinhKem = receiveInfo.total.ToString();
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
                        //dgv.ItemsSource = LstTaiLieuDinhKem.ToList();
                    }
                }
                catch
                {
                }
            }
        }
        private async void LoadDLDanhSachTinDang()
        {
            //clsBien.lstGhiChu = new List<clsGhiChu.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    string url = Properties.Resources.URL + $"listNew3312?customerId={IdMaKH}";

                    var kq = await httpClient.GetAsync(url);
                    clsDanhSachTinDang.Root receiveInfo = JsonConvert.DeserializeObject<clsDanhSachTinDang.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (receiveInfo.data != null)
                    {
                        TongSoDongDSTinDang = receiveInfo.total.ToString();
                        foreach (var item in receiveInfo.data)
                        {
                            LstDanhSachTinDang.Add(item);
                            for (int i = 1; i <= LstDanhSachTinDang.Count; i++)
                            {
                                item.stt = i.ToString();
                            }

                        }
                        //dgv.ItemsSource = lstGhiChu.ToList();
                    }
                }
                catch
                {
                }
            }
        }
    }
}
