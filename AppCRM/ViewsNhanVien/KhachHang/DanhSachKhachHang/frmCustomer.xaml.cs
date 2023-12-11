using AppCRM.Login.Entities;
using AppCRM.Views.KhachHang.DanhSachKhachHang;
using AppCRM.Views.KhachHang.NhomKhachHang;
using AppCRM.Views.KhachHang.TinhTrangKhachHang;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmCustomerNhanVien.xaml
    /// </summary>
    public partial class frmCustomerNhanVien : Page
    {
        public Model.APIEntity.DataLogin_Employee dt;
        private List<clsKhachHang.KhachHang> _lst = new List<clsKhachHang.KhachHang>();
        public List<clsKhachHang.KhachHang> lst { get => _lst; set => _lst = value; }
        private List<clsKhachHang.KhachHang> _lstSearchKH = new List<clsKhachHang.KhachHang>();
        public List<clsKhachHang.KhachHang> lstSearchKH { get => _lst; set => _lst = value; }
        private List<clsNhomKhachHangMacDinh.Datum> lstNhomKH = new List<clsNhomKhachHangMacDinh.Datum>();
        private List<TinhTrangKhachHang.clsTinhTrangKhachHang.Datum> _lstTT = new List<TinhTrangKhachHang.clsTinhTrangKhachHang.Datum>();

        public List<TinhTrangKhachHang.clsTinhTrangKhachHang.Datum> lstTT { get => _lstTT; set => _lstTT = value; }
        private List<clsNguonKhachHang.Datum> _lstNguonKH = new List<clsNguonKhachHang.Datum>();
        public List<clsNguonKhachHang.Datum> lstNguonKH { get => _lstNguonKH; set => _lstNguonKH = value; }
        
        public List<clsNhanVien.Item> LstNV { get => _lstNV; set => _lstNV = value; }


        private List<clsNganHang.Datum> _lstNganHang = new List<clsNganHang.Datum>();
        public List<clsNganHang.Datum> LstNganHang { get => _lstNganHang; set => _lstNganHang = value; }
        private List<clsDoanhThu.Datum> _lstDoanhThu = new List<clsDoanhThu.Datum>();
        public List<clsDoanhThu.Datum> LstDoanhThu { get => _lstDoanhThu; set => _lstDoanhThu = value; }
        private List<clsQuyMoNhanSu.Datum> _lstQuyMoNhanSu = new List<clsQuyMoNhanSu.Datum>();
        public List<clsQuyMoNhanSu.Datum> LstQuyMoNhanSu { get => _lstQuyMoNhanSu; set => _lstQuyMoNhanSu = value; }
        private List<clsXepHangKhachHang.Datum> _lstXepHangKhachHang = new List<clsXepHangKhachHang.Datum>();
        public List<clsXepHangKhachHang.Datum> LstXepHangKhachHang { get => _lstXepHangKhachHang; set => _lstXepHangKhachHang = value; }
        private List<clsLoaiHinhKhachHang.Datum> _listLoaiHinhKH = new List<clsLoaiHinhKhachHang.Datum>();
        public List<clsLoaiHinhKhachHang.Datum> ListLoaiHinhKH { get => _listLoaiHinhKH; set => _listLoaiHinhKH = value; }
        private List<clsPhanLoaiKhachHang.Datum> _listPhanLoaiKH = new List<clsPhanLoaiKhachHang.Datum>();
        public List<clsPhanLoaiKhachHang.Datum> ListPhanLoaiKH { get => _listPhanLoaiKH; set => _listPhanLoaiKH = value; }
        private List<clsLinhVucKH.Datum> _listLinhVuc = new List<clsLinhVucKH.Datum>();
        public List<clsLinhVucKH.Datum> ListLinhVuc { get => _listLinhVuc; set => _listLinhVuc = value; }
        private List<clsNganhNgheKH.Datum> _listNganhNghe = new List<clsNganhNgheKH.Datum>();
        public List<clsNganhNgheKH.Datum> ListNganhNghe { get => _listNganhNghe; set => _listNganhNghe = value; }
        private List<clsTinhThanh.Datum> _listTinhThanh = new List<clsTinhThanh.Datum>();
        public List<clsTinhThanh.Datum> ListTinhThanh { get => _listTinhThanh; set => _listTinhThanh = value; }
        private List<clsNhomKHConMacDinh.Datum> lstNhomKHConMacDinh = new List<clsNhomKHConMacDinh.Datum>();
        private int TongSoTrang = 0;
        private List<clsNhanVien.Item> _lstNV = new List<clsNhanVien.Item>();
        private List<clsNhanVien.Item> _lstNVThuocChucVu = new List<clsNhanVien.Item>();
        public List<clsNhanVien.Item> LstNVThuocChucVu { get => _lstNVThuocChucVu; set => _lstNVThuocChucVu = value; }
        public List<clsKhachHang.KhachHang> lstKH2 = new List<clsKhachHang.KhachHang>();
        private List<Class.clsPhongBanThuocCongTy.Item> lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        private string TSDong = "";
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        frmThanhMenuDoc Main;
        public frmCustomerNhanVien(frmThanhMenuDoc main, Model.APIEntity.DataLogin_Employee data, List<clsKhachHang.KhachHang> lstKhachHang, string TongSoDong, List<clsNguonKhachHang.Datum> lstNguonKhachHang, List<clsNhomKhachHangMacDinh.Datum> lstNhomKhachHang, List<clsNhomKHConMacDinh.Datum> lstNhomKHCon, List<clsTinhTrangKhachHang.Datum> lstTinhTrang, List<clsNhanVien.Item> lstNhanVien, List<clsPhanLoaiKhachHang.Datum> listPLKH, List<clsLinhVucKH.Datum> listLVKH, List<clsLoaiHinhKhachHang.Datum> listLHKH, List<clsNganhNgheKH.Datum> listNNKH, List<clsTinhThanh.Datum> listTTH, List<clsNganHang.Datum> listNH, List<clsDoanhThu.Datum> listDT, List<clsQuyMoNhanSu.Datum> listQMNS, List<clsXepHangKhachHang.Datum> listXHKH, List<Class.clsPhongBanThuocCongTy.Item> lstPB)
        {
            InitializeComponent();
            lsvNguonKH.Items.Clear();
            Main = main;
            Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            LoadKH.Visibility = Visibility.Visible;
            this.DataContext = this;
            dt = data;
            TSDong = TongSoDong;
            lst = lstKhachHang;
            lstKH2 = lstKhachHang;
            lstPhongBan = lstPB;
            lstNguonKH = lstNguonKhachHang;
            lsvNguonKH.Items.Add("Tất cả");
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKhachHang)
            {
                //cboNguonKhachHang.Items.Add(nguon.value);
                lsvNguonKH.Items.Add(nguon.value);
            }
            if (data.position_id == "2")
            {
                foreach(var item in lstNhomKHCon)
                {
                    cboNhomKhachHangCon.Items.Add(item.gr_name);
                }
            }
            lstNhomKH = lstNhomKhachHang;
            lstNhomKHConMacDinh = lstNhomKHCon;
            foreach (clsNhomKhachHangMacDinh.Datum nhom in lstNhomKhachHang)
            {
                cboNhomKhachHangCha.Items.Add(nhom.gr_name);
            }
            lstTT = lstTinhTrang;
            LstNV = lstNhanVien;
            if (data.position_id == "4")
            {
                foreach (clsNhanVien.Item nv in lstNhanVien)
                {
                    if (nv.dep_id == data.dep_id)
                    {
                        cboNhanVienPhuTrach.Items.Add("(" + nv.ep_id + ") " + nv.ep_name + " - " + nv.dep_name);
                        cboNhanVienTaoKhachHang.Items.Add("(" + nv.ep_id + ") " + nv.ep_name + " - " + nv.dep_name);
                    }
                }

            }
            else if (data.position_id == "3")
            {
                cboNhanVienPhuTrach.Items.Add("(" + data.ep_id + ")" + " - " + data.ep_name);
                cboNhanVienTaoKhachHang.Items.Add("(" + data.ep_id + ")" + " - " + data.ep_name);
            }
            LstNganHang = listNH;
            LstDoanhThu = listDT;
            LstQuyMoNhanSu = listQMNS;
            LstXepHangKhachHang = listXHKH;
            ListLoaiHinhKH = listLHKH;
            ListPhanLoaiKH = listPLKH;
            ListLinhVuc = listLVKH;
            ListNganhNghe = listNNKH;
            ListTinhThanh = listTTH;
            cboNhomKhachHangCha.Text = "Tất cả";
            cboNhomKhachHangCon.Text = "Tất cả";
            cboNhomKhachHangCha.Items.Add("Tất cả");
            cboNhomKhachHangCon.Items.Add("Tất cả");
            cboNhanVienPhuTrach.Text = "Tất cả";
            cboNhanVienPhuTrach.Items.Add("Tất cả");
            cboNhanVienTaoKhachHang.Text = "Tất cả";
            cboNhanVienTaoKhachHang.Items.Add("Tất cả");
            cboNguonKhachHang.Text = "Tất cả";
            //cboNguonKhachHang.Items.Add("Tất cả");
            clsBien.listTinhTrang.Clear();
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            btnLui1.Visibility = Visibility.Collapsed;
            btnDau.Visibility = Visibility.Collapsed;
            btnLen1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Visible;
            cboPhanTrang.Text = "10 bản ghi trên trang";
            name = "10 bản ghi trên trang";
            cboPhanTrang.Items.Add("10 bản ghi trên trang");
            cboPhanTrang.Items.Add("20 bản ghi trên trang");
            cboPhanTrang.Items.Add("30 bản ghi trên trang");
            cboPhanTrang.Items.Add("40 bản ghi trên trang");
            cboPhanTrang.Items.Add("50 bản ghi trên trang");
            txtTongSoDong.Text = TSDong;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            dispatcherTimer.Start();
        }
        private List<string> lstNguonKHBoLoc = new List<string>();
        public frmCustomerNhanVien(Model.APIEntity.DataLogin_Employee data, List<clsKhachHang.KhachHang> lstKhachHang, string TongSoDong, List<clsNguonKhachHang.Datum> lstNguonKhachHang, List<clsNhomKhachHangMacDinh.Datum> lstNhomKhachHang,List<clsNhomKHConMacDinh.Datum> lstNhomKHCon, List<clsTinhTrangKhachHang.Datum> lstTinhTrang, List<clsNhanVien.Item> lstNhanVien, List<clsPhanLoaiKhachHang.Datum> listPLKH, List<clsLinhVucKH.Datum> listLVKH, List<clsLoaiHinhKhachHang.Datum> listLHKH, List<clsNganhNgheKH.Datum> listNNKH, List<clsTinhThanh.Datum> listTTH, List<clsNganHang.Datum> listNH, List<clsDoanhThu.Datum> listDT, List<clsQuyMoNhanSu.Datum> listQMNS, List<clsXepHangKhachHang.Datum> listXHKH)
        {
            InitializeComponent();
            //Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            LoadKH.Visibility = Visibility.Visible;
            this.DataContext = this;
            dt = data;
            TSDong = TongSoDong;
            lst = lstKhachHang;
            lstKH2 = lstKhachHang;
            lstNguonKH = lstNguonKhachHang;
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKhachHang)
            {
                //cboNguonKhachHang.Items.Add(nguon.value);
                lstNguonKHBoLoc.Add(nguon.value);
                
            }
            lsvNguonKH.Items.Add("Tất cả");
            lsvNguonKH.ItemsSource = lstNguonKHBoLoc;
            lstNhomKH = lstNhomKhachHang;
            lstNhomKHConMacDinh = lstNhomKHCon;
            foreach (clsNhomKhachHangMacDinh.Datum nhom in lstNhomKhachHang)
            {
                cboNhomKhachHangCha.Items.Add(nhom.gr_name);
            }
            lstTT = lstTinhTrang;
            LstNV = lstNhanVien;
            if (data.position_id == "2")
            {
                foreach (var item in lstNhomKHCon)
                {
                    cboNhomKhachHangCon.Items.Add(item.gr_name);
                }
            }
            if (data.position_id == "4")
            {
                foreach (clsNhanVien.Item nv in lstNhanVien)
                {
                    if (nv.dep_id == data.dep_id)
                    {
                        cboNhanVienPhuTrach.Items.Add("(" + nv.ep_id + ") " + nv.ep_name + " - " + nv.dep_name);
                        cboNhanVienTaoKhachHang.Items.Add("(" + nv.ep_id + ") " + nv.ep_name + " - " + nv.dep_name);
                    }
                }

            }
            else if (data.position_id == "3")
            {
                cboNhanVienPhuTrach.Items.Add(data.ep_name);
                cboNhanVienTaoKhachHang.Items.Add(data.ep_name);
            }
            LstNganHang = listNH;
            LstDoanhThu = listDT;
            LstQuyMoNhanSu = listQMNS;
            LstXepHangKhachHang = listXHKH;
            ListLoaiHinhKH = listLHKH;
            ListPhanLoaiKH = listPLKH;
            ListLinhVuc = listLVKH;
            ListNganhNghe = listNNKH;
            ListTinhThanh = listTTH;
            cboNhomKhachHangCha.Text = "Tất cả";
            cboNhomKhachHangCon.Text = "Tất cả";
            cboNhomKhachHangCha.Items.Add("Tất cả");
            cboNhomKhachHangCon.Items.Add("Tất cả");
            cboNhanVienPhuTrach.Text = "Tất cả";
            cboNhanVienPhuTrach.Items.Add("Tất cả");
            cboNhanVienTaoKhachHang.Text = "Tất cả";
            cboNhanVienTaoKhachHang.Items.Add("Tất cả");
            cboNguonKhachHang.Text = "Tất cả";
            //cboNguonKhachHang.Items.Add("Tất cả");
            clsBien.listTinhTrang.Clear();
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            
            btnLui1.Visibility = Visibility.Collapsed;
            btnDau.Visibility = Visibility.Collapsed;
            btnLen1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Visible;
            cboPhanTrang.Items.Add("10 bản ghi trên trang");
            cboPhanTrang.Items.Add("20 bản ghi trên trang");
            cboPhanTrang.Items.Add("30 bản ghi trên trang");
            cboPhanTrang.Items.Add("40 bản ghi trên trang");
            cboPhanTrang.Items.Add("50 bản ghi trên trang");
            txtTongSoDong.Text = TSDong;
            
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            if (clsBien.GhimNhomKHCha == "")
            {
                cboNhomKhachHangCha.Text = "Tất cả";
            }
            else
            {
                cboNhomKhachHangCha.Text = clsBien.GhimNhomKHCha;
                chkGhimNhom.IsChecked = true;
            }
            if (clsBien.DanhSachKH == true)
            {
                LocKhachHang();
            }
            else
            {
                LoadDataKhachHang(dt);
            }
            Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
        private void btnTimKiem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstSearchKH = new List<clsKhachHang.KhachHang>();
            try
            {
                //dgv.Items.Clear();
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();
                        foreach (var item in api.data)
                        {
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }

                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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
                            lstSearchKH.Add(item);
                            //cboNhomKhachHangCha.Items.Add(item.gr_name);
                        }
                        
                        dgv.ItemsSource = lstSearchKH;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void btnBanGiaoCongViec_Click(object sender, RoutedEventArgs e)
        {
            if (dgv.SelectedItems.Count > 0)
            {
                Main.pnlShowPopup.Children.Add(new Popup.dialogBanGiaoCongViec(this, dt, LstNV, NhanVienPhuTrach, MaKH));
                //Popup.dialogBanGiaoCongViec dialog = new Popup.dialogBanGiaoCongViec(LstNV, NhanVienPhuTrach, MaKH);
                //dialog.ShowDialog();
                //LoadLaiDuLieuKhachHang(dt);
            }
        }

        private void MenuKiemTraTrung_Click(object sender, RoutedEventArgs e)
        {
            frmKiemTraTrungNhanVien frm = new frmKiemTraTrungNhanVien("Tên khách hàng");
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnBoLoc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            pnlBoLoc.Visibility = Visibility.Visible;
            
        }
        private clsKhachHang.KhachHang _Kh = new clsKhachHang.KhachHang();
        public clsKhachHang.KhachHang Kh { get => _Kh; set => _Kh = value; }
        private void btnThemMoiKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemMoiKhachHangNhanVien frm = new frmThemMoiKhachHangNhanVien(Main, "Thêm mới khách hàng", Kh, LstNV, lstTT, lstNhomKHConMacDinh,lstNhomKH, dt, lstNguonKH, lst, txtTongSoDong.Text, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang, ListLoaiHinhKH, ListPhanLoaiKH, ListLinhVuc, ListNganhNghe, ListTinhThanh, lstPhongBan);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnNhapTuFile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
        }
        public string MaKH = "";
        public string MoTa = "";
        public string NhanVienPhuTrach = "";
        public object Link = "";
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsKhachHang.KhachHang kh = (clsKhachHang.KhachHang)dgv.SelectedItem;
            if (kh != null)
            {
                MaKH = kh.cus_id;
                Link = kh.link;
                NhanVienPhuTrach = kh.emp_id;
                MoTa = kh.description;
            }
        }

        private void textTenKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            clsKhachHang.KhachHang kh = (clsKhachHang.KhachHang)dgv.SelectedItem;
            DanhSachKhachHangNhanVien.frmChiTietKhachHangNhanVien frm = new DanhSachKhachHangNhanVien.frmChiTietKhachHangNhanVien(Main, kh, dt, LstNV, lstPhongBan);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void cboNhomKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", dt.token);
                    httpClient.QueryString.Add("id", MaKH);
                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                    {
                        if (name == con.gr_name)
                        {
                            httpClient.QueryString.Add("group_id", con.gr_id);
                        }
                    }
                    
                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateGroupCustomerList"), "POST", httpClient.QueryString);

                }
                catch
                {
                }
            }
        }

        private void cboTinhTrangKH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", dt.token);
                    httpClient.QueryString.Add("id", MaKH);
                    foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                    {
                        if (name == tt.stt_name)
                        {
                            httpClient.QueryString.Add("status", tt.stt_id);
                        }
                    }
                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateStatusCustomerList"), "POST", httpClient.QueryString);
                }
                catch
                {
                }
            }
        }

        private void cboNguonKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", dt.token);
                    httpClient.QueryString.Add("id", MaKH);
                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
                    {
                        if (name == nguonKH.value)
                        {
                            httpClient.QueryString.Add("resoure", nguonKH.id.ToString());
                        }
                    }
                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateResouceCustomerList"), "POST", httpClient.QueryString);

                }
                catch
                {
                }
            }
        }

        private void btnChinhSua_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsKhachHang.KhachHang kh = (clsKhachHang.KhachHang)dgv.SelectedItem;
            frmThemMoiKhachHangNhanVien frm = new frmThemMoiKhachHangNhanVien(Main, "Chỉnh sửa khách hàng", kh, LstNV, lstTT, lstNhomKHConMacDinh, lstNhomKH, dt, lstNguonKH, lst, txtTongSoDong.Text, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang, ListLoaiHinhKH, ListPhanLoaiKH, ListLinhVuc, ListNganhNghe, ListTinhThanh, lstPhongBan);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
        private void btnDau_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string[] PageA = name.Split(Convert.ToChar("b"));
            string SoDLTrenTrang = PageA[0];
            kh.Clear();
            clsBien.Trang = "1";
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
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
            lstKH2 = new List<clsKhachHang.KhachHang>();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                var kq = httpClient.GetAsync(url);
                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                if (api != null)
                {
                    txtTongSoDong.Text = api.total.ToString();

                    foreach (var item in api.data)
                    {

                        //dgv.ItemsSource = ListCustomer;
                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                        {
                            if (item.group_id == con.gr_id)
                            {
                                item.group_id = con.gr_name;
                            }
                        }
                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                        {
                            if (tt.status == 1)
                            {
                                item.DanhSachTinhTrang.Add(tt.stt_name);
                            }

                        }
                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                        {
                            item.DanhSachNhomKH.Add(con.gr_name);
                        }
                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                        //lstId.Add(item.cus_id);

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
                        kh.Add(item);

                    }
                    dgv.ItemsSource = kh;

                }
                
            }
        }
        private void btnPage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstKH2 = new List<clsKhachHang.KhachHang>();
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            LoadDLTrang1();
        }
        private List<clsKhachHang.KhachHang> lstKHTrang1 = new List<clsKhachHang.KhachHang>();
        private void LoadDLTrang1()
        {
            string[] PageA = name.Split(Convert.ToChar("b"));
            string SoDLTrenTrang = PageA[0];
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            lstKHTrang1 = new List<clsKhachHang.KhachHang>();
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
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
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                lstKHTrang1.Add(item);

                            }
                            dgv.ItemsSource = lstKHTrang1;
                            clsBien.Trang = textPage2.Text;

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
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                lstKHTrang1.Add(item);

                            }
                            dgv.ItemsSource = lstKHTrang1;
                            clsBien.Trang = "1";
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }
        private void btnPage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string[] PageA = name.Split(Convert.ToChar("b"));
            string SoDLTrenTrang = PageA[0];
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            lstKH2 = new List<clsKhachHang.KhachHang>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            if (textPage2.Text != "2")
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.BlueViolet;
                btnPage3.Background = Brushes.White;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                lstKH2.Add(item);

                            }
                            dgv.ItemsSource = lstKH2;

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
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=2&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                lstKH2.Add(item);

                            }
                            dgv.ItemsSource = lstKH2;

                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
            clsBien.Trang = textPage2.Text;
        }
        private void btnPage3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string[] PageA = name.Split(Convert.ToChar("b"));
            string SoDLTrenTrang = PageA[0];
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            lstKH2 = new List<clsKhachHang.KhachHang>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            TongSoTrang = int.Parse(txtTongSoDong.Text) / 10;
            if (int.Parse(txtTongSoDong.Text) % 10 > 0)
            {
                TongSoTrang++;
            }
            clsBien.TongSoTrang = TongSoTrang.ToString();
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={TongSoTrang}&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;
                                clsBien.Trang = TongSoTrang.ToString();
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;
                                clsBien.Trang = textPage2.Text;
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
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=3&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                lstKH2.Add(item);

                            }
                            dgv.ItemsSource = lstKH2;
                            clsBien.Trang = "3";
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }

        }

        private void dispatcherTimerLoadTrang3_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void btnCuoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string[] PageA = name.Split(Convert.ToChar("b"));
            string SoDLTrenTrang = PageA[0];
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            //textPage1.Text = (TongSoTrang - 2).ToString();
            //textPage2.Text = (TongSoTrang - 1).ToString();
            //textPage3.Text = TongSoTrang.ToString();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Collapsed;
            btnLen1.Visibility = Visibility.Collapsed;
            btnPage1.Background = Brushes.White;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.BlueViolet;
            lstKH2 = new List<clsKhachHang.KhachHang>();
            TongSoTrang = int.Parse(txtTongSoDong.Text) / 10;
            if (TongSoTrang % 10 != 0)
            {
                TongSoTrang++;
            }
            clsBien.TongSoTrang = TongSoTrang.ToString();
            clsBien.Trang = TongSoTrang.ToString();
            textPage3.Text = TongSoTrang.ToString();
            textPage2.Text = (TongSoTrang - 1).ToString();
            textPage1.Text = (TongSoTrang - 2).ToString();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={TongSoTrang}&limit={SoDLTrenTrang}&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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
                            lstKH2.Add(item);

                        }
                        dgv.ItemsSource = lstKH2;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            pnlBoLoc.Visibility = Visibility.Collapsed;
        }

        private void textGio1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textGio1.Text != "")
            {

                if (!char.IsNumber(textGio1.Text, 0))
                {
                    textGio1.Text = "";
                }
                else
                {
                    if (Convert.ToInt32(textGio1.Text) > 23)
                    {
                        textGio1.Text = "23";
                    }
                }
            }
            
        }

        private void textPhut1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textPhut1.Text != "")
            {

                if (!char.IsNumber(textPhut1.Text, 0))
                {
                    textPhut1.Text = "";
                }
                else
                {
                    if (Convert.ToInt32(textPhut1.Text) > 59)
                    {
                        textPhut1.Text = "59";
                    }
                }
            }
            
        }

        private void textGio2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textGio2.Text != "")
            {

                if (!char.IsNumber(textGio2.Text, 0))
                {
                    textGio2.Text = "";
                }
                else
                {
                    if (Convert.ToInt32(textGio2.Text) > 23)
                    {
                        textGio2.Text = "23";
                    }
                }
            }
            
        }

        private void textPhut2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textPhut2.Text != "")
            {
                
                if (!char.IsNumber(textPhut2.Text, 0))
                {
                    textPhut2.Text = "";
                }
                else
                {
                    if (Convert.ToInt32(textPhut2.Text) > 59)
                    {
                        textPhut2.Text = "59";
                    }
                }
            }
            
        }
        List<string> test = new List<string>();
        private void cboNhomKhachHangCha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string IdCha = "";
            if (cboNhomKhachHangCha.SelectedValue != null)
            {
                if (cboNhomKhachHangCha.SelectedValue.ToString() == "Tất cả")
                {
                    cboNhomKhachHangCon.Items.Clear();
                    cboNhomKhachHangCon.Items.Add("Tất cả");
                    cboNhomKhachHangCon.Text = "Tất cả";
                }
                else
                {
                    cboNhomKhachHangCon.Items.Clear();
                    cboNhomKhachHangCon.Items.Add("Tất cả");
                    foreach (clsNhomKhachHangMacDinh.Datum nhomcha in lstNhomKH)
                    {
                        try
                        {
                            //cboNhomKhachHangCon.Items.Clear();
                            if (cboNhomKhachHangCha.SelectedValue.ToString() == nhomcha.gr_name)
                            {
                                IdCha = nhomcha.gr_id;
                                using (HttpClient httpClient = new HttpClient())
                                {
                                    //string url = Properties.Resources.URL + "listGroupCustomer";
                                    string url = $"https://crm.timviec365.vn/ApiWinform/listGroup?groupId={IdCha}";
                                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                    var kq = httpClient.GetAsync(url);
                                    clsNhomKHConMacDinh.Root api = JsonConvert.DeserializeObject<clsNhomKHConMacDinh.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                    if (api != null)
                                    {
                                        foreach (var item in api.data)
                                        {
                                            //lstNhomkHConMacDinh.Add(item);
                                            cboNhomKhachHangCon.Items.Add(item.gr_name);

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
            
        }
        private List<clsKhachHang.KhachHang> kh = new List<clsKhachHang.KhachHang>();
        private void btnApDung_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            kh = new List<clsKhachHang.KhachHang>();
            kh.Clear();
            textPage1.Text = "1";
            textPage2.Text = "2";
            textPage3.Text = "3";
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            
            btnDau.Visibility = Visibility.Collapsed;
            btnLui1.Visibility = Visibility.Collapsed;
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                    clsBien.NguonKH = nguon.value;
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                    clsBien.NhomKhCha = cha.gr_name;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                    clsBien.NhomKHCon = con.gr_name;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            //clsBien.NhanVienPT = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
                clsBien.NhanVienPT = "Tất cả";
               
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            //clsBien.NhanVienTao = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
                clsBien.NhanVienTao = "Tất cả";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            clsBien.Gio1 = textGio1.Text;
            clsBien.Gio2 = textGio2.Text;
            clsBien.Phut1 = textPhut1.Text;
            clsBien.Phut2 = textPhut2.Text;
            clsBien.DateTuNgay = dtpTuNgay.Text;
            clsBien.DateDenNgay = dtpDenNgay.Text;
            clsBien.NhanVienPT = cboNhanVienPhuTrach.Text;
            clsBien.NhanVienTao = cboNhanVienTaoKhachHang.Text;
            clsBien.Trang = "1";
            if (chkGhimNhom.IsChecked == true)
            {
                clsBien.GhimNhomKHCha = cboNhomKhachHangCha.Text;
            }
            else
            {
                clsBien.GhimNhomKHCha = "";
            }
            if (btnPage1.Background == Brushes.BlueViolet)
            {
                clsBien.Trang = textPage1.Text;
            }
            else if (btnPage2.Background == Brushes.BlueViolet)
            {
                clsBien.Trang = textPage2.Text;
            }
            else if (btnPage3.Background == Brushes.BlueViolet)
            {
                clsBien.Trang = textPage3.Text;
            }
            if (cboPhanTrang.Text == "10 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            kh.Add(item);

                        }
                        //if (kh.Count <= 10)
                        //{
                        //    btnPage1.Background = Brushes.BlueViolet;
                        //    textPage1.Text = "1";
                        //    btnPage2.Visibility = Visibility.Collapsed;
                        //    btnPage3.Visibility = Visibility.Collapsed;
                        //    btnCuoi.Visibility = Visibility.Collapsed;
                        //}
                    }
                }
                clsBien.DuLieuToiDa = "10 bản ghi trên trang";
            }
            else if (cboPhanTrang.Text == "20 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            kh.Add(item);

                        }


                    }
                }
                clsBien.DuLieuToiDa = "20 bản ghi trên trang";
            }
            else if (cboPhanTrang.Text == "30 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            kh.Add(item);

                        }
                    }
                }
                clsBien.DuLieuToiDa = "30 bản ghi trên trang";
            }
            else if (cboPhanTrang.Text == "40 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            kh.Add(item);

                        }
                    }
                }
                clsBien.DuLieuToiDa = "40 bản ghi trên trang";
            }
            else if (cboPhanTrang.Text == "50 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            kh.Add(item);

                        }
                    }
                }
                clsBien.DuLieuToiDa = "50 bản ghi trên trang";
            }
            dgv.ItemsSource = kh.ToList();
            pnlBoLoc.Visibility = Visibility.Collapsed;
            Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            
        }
        private void LocKhachHang()
        {
            lst = new List<clsKhachHang.KhachHang>();
            textGio1.Text = clsBien.Gio1;
            textPhut1.Text = clsBien.Phut1;
            textGio2.Text = clsBien.Gio2;
            textPhut2.Text = clsBien.Phut2;
            dtpTuNgay.Text = clsBien.DateTuNgay;
            dtpDenNgay.Text = clsBien.DateDenNgay;
            if (clsBien.DuLieuToiDa == "")
            {
                cboPhanTrang.Text = "10 bản ghi trên trang";
            }
            else
            {
                cboPhanTrang.Text = clsBien.DuLieuToiDa;
            }
            cboNguonKhachHang.Text = clsBien.NguonKH;
            //cboPhanTrang.Text = clsBien.DuLieuToiDa;
            cboNhanVienPhuTrach.Text = clsBien.NhanVienPT;
            cboNhomKhachHangCha.Text = clsBien.NhomKhCha;
            cboNhomKhachHangCon.Text = clsBien.NhomKHCon;
            cboNhanVienTaoKhachHang.Text = clsBien.NhanVienTao;
            tbSearch.Text = clsBien.TimKiem;
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            if (cboPhanTrang.Text == "10 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={clsBien.Trang}&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            lst.Add(item);

                        }
                    }
                }
                
                
            }
            else if (cboPhanTrang.Text == "20 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={clsBien.Trang}&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            lst.Add(item);

                        }


                    }
                }
            }
            else if (cboPhanTrang.Text == "30 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={clsBien.Trang}&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            lst.Add(item);

                        }
                    }
                }
            }
            else if (cboPhanTrang.Text == "40 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={clsBien.Trang}&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            lst.Add(item);

                        }
                    }
                }
            }
            else if (cboPhanTrang.Text == "50 bản ghi trên trang")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={clsBien.Trang}&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {

                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                            }
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                            //lstId.Add(item.cus_id);

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
                            lst.Add(item);

                        }
                    }
                }
            }
            dgv.ItemsSource = lst.ToList();
            if (clsBien.GhimNhomKHCha == "")
            {
                cboNhomKhachHangCha.Text = "Tất cả";
            }
            else
            {
                cboNhomKhachHangCha.Text = clsBien.GhimNhomKHCha;
            }
            if (clsBien.TongSoTrang != "")
            {
                if (clsBien.Trang == clsBien.TongSoTrang)
                {
                    textPage3.Text = clsBien.TongSoTrang;
                    textPage2.Text = (int.Parse(clsBien.TongSoTrang) - 1).ToString();
                    textPage1.Text = (int.Parse(clsBien.TongSoTrang) - 2).ToString();
                    btnPage3.Background = Brushes.BlueViolet;
                    btnPage2.Background = Brushes.White;
                    btnPage1.Background = Brushes.White;
                    btnLen1.Visibility = Visibility.Collapsed;
                    btnCuoi.Visibility = Visibility.Collapsed;
                    btnDau.Visibility = Visibility.Visible;
                    btnLui1.Visibility = Visibility.Visible;
                }
                else
                {
                    textPage3.Text = (int.Parse(clsBien.Trang) + 1).ToString();
                    textPage2.Text = clsBien.Trang;
                    textPage1.Text = (int.Parse(clsBien.Trang) - 1).ToString();
                    btnPage3.Background = Brushes.White;
                    btnPage2.Background = Brushes.BlueViolet;
                    btnPage1.Background = Brushes.White;
                    if (textPage1.Text != "1")
                    {
                        btnDau.Visibility = Visibility.Visible;
                        btnLui1.Visibility = Visibility.Visible;
                    }
                    
                }
            }
            pnlBoLoc.Visibility = Visibility.Collapsed;
            dispatcherTimer.Stop();
            LoadKH.Visibility = Visibility.Collapsed;
        }
        public void LoadDataKhachHang(Model.APIEntity.DataLogin_Employee data)
        {
            clsBien.Gio1 = "";
            clsBien.Phut1 = "";
            clsBien.Gio2 = "";
            clsBien.Phut2 = "";
            clsBien.DateTuNgay = "";
            clsBien.DateDenNgay = "";
            clsBien.NguonKH = "Tất cả";
            clsBien.NhomKhCha = "Tất cả";
            clsBien.NhomKHCon = "Tất cả";
            clsBien.NhanVienPT = "Tất cả";
            clsBien.NhanVienTao = "Tất cả";
            clsBien.TimKiem = "";
            clsBien.Trang = "";
            clsBien.DuLieuToiDa = "";
            clsBien.TongSoTrang = "";
            clsBien.DanhSachKH = false;
            
            lst = new List<clsKhachHang.KhachHang>();
            List<string> lstIdCha = new List<string>();
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
                    txtTongSoDong.Text = api.total.ToString();

                    foreach (var item in api.data)
                    {
                        if (item.cus_from == null)
                        {
                            item.cus_from = "";
                        }
                        //dgv.ItemsSource = ListCustomer;
                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                        {
                            if (item.group_id == con.gr_id)
                            {
                                item.group_id = con.gr_name;
                            }
                        }
                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
                        {
                            if (item.status == lst.stt_id)
                            {
                                item.status = lst.stt_name;
                            }
                            if (item.status == "0")
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
                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                        {
                            if (tt.status == 1)
                            {
                                item.DanhSachTinhTrang.Add(tt.stt_name);
                            }
                        }
                        foreach (clsNhomKHConMacDinh.Datum nkh in lstNhomKHConMacDinh)
                        {
                            item.DanhSachNhomKH.Add(nkh.gr_name);
                            
                        }
                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                        //lstId.Add(item.cus_id);

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
                        lst.Add(item);

                    }
                    dgv.ItemsSource = lst;
                    dispatcherTimer.Stop();
                    LoadKH.Visibility = Visibility.Collapsed;
                }
            }
        }
        public void LoadLaiDuLieuKhachHang(Model.APIEntity.DataLogin_Employee data)
        {
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            if (btnPage1.Background == Brushes.BlueViolet)
            {
                if (cboPhanTrang.Text == "10 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage1.Text}&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "20 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage1.Text}&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "30 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage1.Text}&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "40 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage1.Text}&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "50 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage1.Text}&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                dgv.ItemsSource = kh.ToList();
                pnlBoLoc.Visibility = Visibility.Collapsed;
            }
            else if (btnPage2.Background == Brushes.BlueViolet)
            {
                if (cboPhanTrang.Text == "10 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "20 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "30 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "40 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "50 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                dgv.ItemsSource = kh.ToList();
                pnlBoLoc.Visibility = Visibility.Collapsed;
            }
            else if (btnPage3.Background == Brushes.BlueViolet)
            {
                if (cboPhanTrang.Text == "10 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage3.Text}&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "20 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage3.Text}&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "30 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage3.Text}&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "40 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage3.Text}&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                else if (cboPhanTrang.Text == "50 bản ghi trên trang")
                {
                    kh.Clear();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage3.Text}&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                        //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();

                            foreach (var item in api.data)
                            {

                                //dgv.ItemsSource = ListCustomer;
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                //lstId.Add(item.cus_id);

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
                                kh.Add(item);

                            }
                            dgv.ItemsSource = kh;

                        }
                    }
                }
                dgv.ItemsSource = kh.ToList();
                pnlBoLoc.Visibility = Visibility.Collapsed;
            }
        }
            
        private void LoadDataKhachHangFromDateToDate(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                kh = new List<clsKhachHang.KhachHang>();
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = Properties.Resources.URL + $"listCustomer?startDate={dtpTuNgay.Text}&endDate={dtpDenNgay.Text}";
                    //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        txtTongSoDong.Text = api.total.ToString();

                        foreach (var item in api.data)
                        {
                            //dgv.ItemsSource = ListCustomer;
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                if (item.group_id == con.gr_id)
                                {
                                    item.group_id = con.gr_name;
                                }
                            }
                            foreach (clsTinhTrangKhachHang.Datum lst in lstTT)
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
                            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                            {
                                if (tt.status == 1)
                                {
                                    item.DanhSachTinhTrang.Add(tt.stt_name);
                                }

                            }
                            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                            {
                                item.DanhSachNhomKH.Add(con.gr_name);
                                
                            }
                            //foreach (clsNhomKhachHangMacDinh.Datum nkh in lstNhomKH)
                            //{
                            //    foreach (ListsChildCustomer khcon in nkh.lists_child)
                            //    {
                            //        item.DanhSachNhomKH.Add(khcon.gr_name);
                            //    }
                            //}
                            foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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
                            kh.Add(item);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        

        private void bd_Huy_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            pnlBoLoc.Visibility = Visibility.Collapsed;
        }

        private void tb_SoDienThoai_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.pnlShowPopup.Children.Add(new Popup.dialogCapNhatKhachHangTuKDNhanVien(this, MaKH, lstTT, lstNguonKH, lstNhomKH, lstNhomKHConMacDinh, dt));
            
            
        }

        private void mnuChinhSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgv.SelectedItems.Count == 1)
            {
                clsKhachHang.KhachHang kh = (clsKhachHang.KhachHang)dgv.SelectedItem;
                frmThemMoiKhachHangNhanVien frm = new frmThemMoiKhachHangNhanVien(Main, "Chỉnh sửa khách hàng", kh, LstNV, lstTT,lstNhomKHConMacDinh, lstNhomKH, dt, lstNguonKH, lst, txtTongSoDong.Text, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang, ListLoaiHinhKH, ListPhanLoaiKH, ListLinhVuc, ListNganhNghe, ListTinhThanh, lstPhongBan);
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                //frm.Close();
                pnlHienThi.Children.Add(content as UIElement);
                
            }
        }

        private string name = "";
        private void cboPhanTrang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = sender as System.Windows.Controls.ComboBox;
            name = select.SelectedItem as string;
            string[] NgayThangFrom1 = dtpTuNgay.Text.Split(Convert.ToChar("/"));
            string[] NgayThangNamTo1 = dtpDenNgay.Text.Split(Convert.ToChar("/"));
            string idNguonKH = "";
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (cboNguonKhachHang.Text == nguon.value)
                {
                    idNguonKH = nguon.id.ToString();
                }
            }
            string IdNhomCha1 = "";
            string IdNhomCon1 = "";
            foreach (clsNhomKhachHangMacDinh.Datum cha in lstNhomKH)
            {
                if (cboNhomKhachHangCha.Text == cha.gr_name)
                {
                    IdNhomCha1 = cha.gr_id;
                }
            }
            foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
            {
                if (cboNhomKhachHangCon.Text == con.gr_name)
                {
                    IdNhomCon1 = con.gr_id;
                }
            }
            string[] MaNVPT = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
            string MaNVPT1 = MaNVPT[0];
            string[] MaNVPT2 = MaNVPT1.Split(Convert.ToChar("("));
            string MaNhanvienPhuTrach = MaNVPT2[MaNVPT2.Length - 1];
            if (MaNhanvienPhuTrach == "Tất cả")
            {
                MaNhanvienPhuTrach = "";
            }
            string[] MaNVTaoKH = cboNhanVienTaoKhachHang.Text.Split(Convert.ToChar(")"));
            string MaNVTaoKH1 = MaNVTaoKH[0];
            string[] MaNVTaoKH2 = MaNVTaoKH1.Split(Convert.ToChar("("));
            string MaNhanvienTaoKH = MaNVTaoKH2[MaNVTaoKH2.Length - 1];
            if (MaNhanvienTaoKH == "Tất cả")
            {
                MaNhanvienTaoKH = "";
            }
            List<string> lstStatus = new List<string>();
            foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
            {
                foreach (string str in clsBien.listTinhTrang)
                {
                    if (str == tt.stt_name)
                    {
                        lstStatus.Add(tt.stt_id);
                    }
                }
            }
            string TinhTrangKH = "";
            if (lstStatus.Count > 0)
            {
                foreach (var item in lstStatus)
                {
                    TinhTrangKH = TinhTrangKH + item + ",";
                }
                TinhTrangKH = TinhTrangKH.Remove(TinhTrangKH.Length - 1);
            }
            if (name == "10 bản ghi trên trang")
            {
                lstKH2 = new List<clsKhachHang.KhachHang>();

                if (btnPage1.Background == Brushes.BlueViolet)
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                else if (btnPage2.Background == Brushes.BlueViolet)
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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=2&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var check = ex.Message;
                        }
                    }
                }
                else if (btnPage3.Background == Brushes.BlueViolet)
                {
                    TongSoTrang = int.Parse(txtTongSoDong.Text) / 10;
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={TongSoTrang}&limit=10&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                clsBien.DuLieuToiDa = "10 bản ghi trên trang";

            }
            else if (name == "20 bản ghi trên trang")
            {
                lstKH2 = new List<clsKhachHang.KhachHang>();
                if (btnPage1.Background == Brushes.BlueViolet)
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }


                }
                else if (btnPage2.Background == Brushes.BlueViolet)
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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=2&limit=20&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var check = ex.Message;
                        }
                    }
                }
                else if (btnPage3.Background == Brushes.BlueViolet)
                {
                    TongSoTrang = int.Parse(txtTongSoDong.Text) / 20;
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
                            string url = Properties.Resources.URL + $"listCustomer?page={TongSoTrang}&limit=20";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {

                                foreach (var item in api.data)
                                {
                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }

                }
                clsBien.DuLieuToiDa = "20 bản ghi trên trang";
            }
            else if (name == "30 bản ghi trên trang")
            {
                lstKH2 = new List<clsKhachHang.KhachHang>();
                if (btnPage1.Background == Brushes.BlueViolet)
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                else if (btnPage2.Background == Brushes.BlueViolet)
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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=2&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var check = ex.Message;
                        }
                    }
                }
                else if (btnPage3.Background == Brushes.BlueViolet)
                {
                    TongSoTrang = int.Parse(txtTongSoDong.Text) / 30;
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={TongSoTrang}&limit=30&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                clsBien.DuLieuToiDa = "30 bản ghi trên trang";
            }
            else if (name == "40 bản ghi trên trang")
            {
                lstKH2 = new List<clsKhachHang.KhachHang>();
                if (btnPage1.Background == Brushes.BlueViolet)
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                else if (btnPage2.Background == Brushes.BlueViolet)
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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=2&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var check = ex.Message;
                        }
                    }
                }
                else if (btnPage3.Background == Brushes.BlueViolet)
                {
                    TongSoTrang = int.Parse(txtTongSoDong.Text) / 40;
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={TongSoTrang}&limit=40&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                clsBien.DuLieuToiDa = "40 bản ghi trên trang";
            }
            else if (name == "50 bản ghi trên trang")
            {
                lstKH2 = new List<clsKhachHang.KhachHang>();
                if (btnPage1.Background == Brushes.BlueViolet)
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=1&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                    //lstId.Add(item.cus_id);

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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                else if (btnPage2.Background == Brushes.BlueViolet)
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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={textPage2.Text}&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

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
                                string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page=2&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                                //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                                httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                                var kq = httpClient.GetAsync(url);
                                clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    txtTongSoDong.Text = api.total.ToString();

                                    foreach (var item in api.data)
                                    {

                                        //dgv.ItemsSource = ListCustomer;
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            if (item.group_id == con.gr_id)
                                            {
                                                item.group_id = con.gr_name;
                                            }
                                        }
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                        foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                        {
                                            if (tt.status == 1)
                                            {
                                                item.DanhSachTinhTrang.Add(tt.stt_name);
                                            }

                                        }
                                        foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                        {
                                            item.DanhSachNhomKH.Add(con.gr_name);
                                        }
                                        foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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

                                        //lstId.Add(item.cus_id);

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
                                        lstKH2.Add(item);

                                    }
                                    dgv.ItemsSource = lstKH2;

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var check = ex.Message;
                        }
                    }
                }
                else if (btnPage3.Background == Brushes.BlueViolet)
                {
                    TongSoTrang = int.Parse(txtTongSoDong.Text) / 50;
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
                            string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}&page={TongSoTrang}&limit=50&startHour={textGio1.Text}:{textPhut1.Text}&startDate={dtpTuNgay.Text}&endHour={textGio2.Text}:{textPhut2.Text}&endDate={dtpDenNgay.Text}&status={TinhTrangKH}&source={idNguonKH}&groupParent={IdNhomCha1}&groupChild={IdNhomCon1}&empCharge={MaNhanvienPhuTrach}&creater={MaNhanvienTaoKH}";
                            //string url = Properties.Resources.URL + $"listCustomer?page=1&limit=10";
                            httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                            var kq = httpClient.GetAsync(url);
                            clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                            if (api != null)
                            {
                                txtTongSoDong.Text = api.total.ToString();

                                foreach (var item in api.data)
                                {

                                    //dgv.ItemsSource = ListCustomer;
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        if (item.group_id == con.gr_id)
                                        {
                                            item.group_id = con.gr_name;
                                        }
                                    }
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                    foreach (Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum tt in lstTT)
                                    {
                                        if (tt.status == 1)
                                        {
                                            item.DanhSachTinhTrang.Add(tt.stt_name);
                                        }

                                    }
                                    foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                    {
                                        item.DanhSachNhomKH.Add(con.gr_name);
                                    }
                                    foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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
                                    lstKH2.Add(item);

                                }
                                dgv.ItemsSource = lstKH2;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var check = ex.Message;
                    }
                }
                clsBien.DuLieuToiDa = "50 bản ghi trên trang";
            }
        }

        private void mnuGoiDien_Click(object sender, RoutedEventArgs e)
        {
            if (dgv.SelectedItems.Count == 1)
            {
                Main.pnlShowPopup.Children.Add(new Popup.dialogCapNhatKhachHangTuKDNhanVien(this, MaKH, lstTT, lstNguonKH, lstNhomKH, lstNhomKHConMacDinh, dt));
                
            }
        }
        
        private void textCusfr_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Link != null)
            {
                System.Diagnostics.Process.Start(Link.ToString());
            }
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Main.scrollMain.ScrollToVerticalOffset(Main.scrollMain.VerticalOffset - e.Delta);
        }

        private void tbSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                lstSearchKH = new List<clsKhachHang.KhachHang>();
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        string url = Properties.Resources.URL + $"listCustomer?search={tbSearch.Text}";
                        httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                        var kq = httpClient.GetAsync(url);
                        clsKhachHang.Root api = JsonConvert.DeserializeObject<clsKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            txtTongSoDong.Text = api.total.ToString();
                            foreach (var item in api.data)
                            {
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    if (item.group_id == con.gr_id)
                                    {
                                        item.group_id = con.gr_name;
                                    }
                                }
                                foreach (clsTinhTrangKhachHang.Datum lst in lstTT)
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
                                foreach (clsTinhTrangKhachHang.Datum tt in lstTT)
                                {
                                    if (tt.status == 1)
                                    {
                                        item.DanhSachTinhTrang.Add(tt.stt_name);
                                    }

                                }
                                foreach (clsNhomKHConMacDinh.Datum con in lstNhomKHConMacDinh)
                                {
                                    item.DanhSachNhomKH.Add(con.gr_name);
                                }
                                foreach (clsNguonKhachHang.Datum nguonKH in lstNguonKH)
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
                                lstSearchKH.Add(item);
                                //cboNhomKhachHangCha.Items.Add(item.gr_name);
                            }
                            dgv.ItemsSource = lstSearchKH;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var check = ex.Message;
                }
            }
        }

        private void btnSuaMoTa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.pnlShowPopup.Children.Add(new Popup.PopUpSuaMoTaKhachHang(this, MaKH, MoTa, dt));
            

        }
        private void BorNguonKH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (borDSNguonKH.Visibility == Visibility.Collapsed)
            {
                borDSNguonKH.Visibility = Visibility.Visible;
            }
            else
            {
                borDSNguonKH.Visibility = Visibility.Collapsed;
            }
        }

        private void lsvNguonKH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboNguonKhachHang.Text = lsvNguonKH.SelectedItem.ToString();
            borDSNguonKH.Visibility = Visibility.Collapsed;
        }
        private void textSearchNguon_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvNguonKH.Items.Clear();
            foreach (clsNguonKhachHang.Datum nguon in lstNguonKH)
            {
                if (nguon.value.Contains(textSearchNguon.Text))
                {
                    lsvNguonKH.Items.Add(nguon.value);
                }
            }
            
        }
    }
}