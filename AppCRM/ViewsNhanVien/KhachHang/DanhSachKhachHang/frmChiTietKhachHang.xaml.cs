using AppCRM.Views.KhachHang.DanhSachKhachHang;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmChiTietKhachHangNhanVien.xaml
    /// </summary>
    public partial class frmChiTietKhachHangNhanVien : Page
    {
        public string IdMaKH = "";

        private clsKhachHang.KhachHang _khachhang = new clsKhachHang.KhachHang();

        public clsKhachHang.KhachHang Khachhang { get => _khachhang; set => _khachhang = value; }
        private Model.APIEntity.DataLogin_Employee data;
        private frmThanhMenuDoc frmMain;
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        private string TenKH = "";
        private string EmailKH = "";
        private string SDTKh = "";
        private List<Class.clsPhongBanThuocCongTy.Item> lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        public frmChiTietKhachHangNhanVien(frmThanhMenuDoc main, clsKhachHang.KhachHang kh, Model.APIEntity.DataLogin_Employee dt,List<clsNhanVien.Item> lstNV, List<Class.clsPhongBanThuocCongTy.Item> lstPB)
        {
            InitializeComponent();
            frmMain = main;
            Khachhang = kh;
            data = dt;
            IdMaKH = kh.cus_id;
            TenKH = kh.name;
            EmailKH = kh.email;
            SDTKh = kh.phone_number;
            lstNhanVien = lstNV;
            lstPhongBan = lstPB;
            BrushConverter bc = new BrushConverter();
            textThongTinChiTiet.Foreground = (Brush)bc.ConvertFrom("#4C5BD4");
            textThongTinChiTiet.FontWeight = FontWeights.DemiBold;
            ChiTietKhachHangNhanVien.frmChiTietKHNhanVien frm = new ChiTietKhachHangNhanVien.frmChiTietKHNhanVien(kh,data);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            LoadDLGhiChu();
            LoadDLTaiLieuDinhKem();
            LoadDLDanhSachTinDang();
        }
        private string TongSoDongGhiChu = "";
        private string TongSoDongTaiLieuDinhKem = "";
        private string TongSoDongDSTinDang = "";
        public List<clsGhiChu.Datum> lstGhiChu = new List<clsGhiChu.Datum>();
        private List<clsTaiLieuDinhKem.Datum> _lstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
        public List<clsTaiLieuDinhKem.Datum> LstTaiLieuDinhKem { get => _lstTaiLieuDinhKem; set => _lstTaiLieuDinhKem = value; }
        private List<clsDanhSachTinDang.Datum> _lstDanhSachTinDang = new List<clsDanhSachTinDang.Datum>();
        public List<clsDanhSachTinDang.Datum> LstDanhSachTinDang { get => _lstDanhSachTinDang; set => _lstDanhSachTinDang = value; }
        public async void LoadDLGhiChu()
        {
            lstGhiChu = new List<clsGhiChu.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
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
                            lstGhiChu.Add(item);
                            for (int i = 1; i <= lstGhiChu.Count; i++)
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
        public async void LoadDLTaiLieuDinhKem()
        {
            LstTaiLieuDinhKem = new List<clsTaiLieuDinhKem.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
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
            lstGhiChu = new List<clsGhiChu.Datum>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    //dgv.Items.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
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
            ChiTietKhachHangNhanVien.frmLienHeNhanVien frm = new ChiTietKhachHangNhanVien.frmLienHeNhanVien(IdMaKH, data, frmMain);
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
            ChiTietKhachHangNhanVien.frmGhiChuNhanVien frm = new ChiTietKhachHangNhanVien.frmGhiChuNhanVien(frmMain, lstGhiChu, IdMaKH, TongSoDongGhiChu,data);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
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
            ChiTietKhachHangNhanVien.frmChiTietKHNhanVien frm = new ChiTietKhachHangNhanVien.frmChiTietKHNhanVien(Khachhang, data);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
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
            ChiTietKhachHangNhanVien.frmTaiLieuDinhKemNhanVien frm = new ChiTietKhachHangNhanVien.frmTaiLieuDinhKemNhanVien(frmMain, IdMaKH, LstTaiLieuDinhKem, TongSoDongTaiLieuDinhKem,data);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnDanhSachTinDang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
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
            ViewsNhanVien.KhachHang.DanhSachKhachHang.ChiTietKhachHang.frmHopDongBan frm = new ViewsNhanVien.KhachHang.DanhSachKhachHang.ChiTietKhachHang.frmHopDongBan(frmMain, IdMaKH, data, lstNhanVien, lstPhongBan, TenKH, SDTKh, EmailKH);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
