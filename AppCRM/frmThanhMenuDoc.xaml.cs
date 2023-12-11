using AppCRM.Login;
using AppCRM.Login.Entities;
using AppCRM.Model.APIEntity;
using AppCRM.Views.ChamSocKhachHang.TongDai;
using AppCRM.Views.HopDong;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace AppCRM
{
    /// <summary>
    /// Interaction logic for frmThanhMenuDoc.xaml
    /// </summary>
    public partial class frmThanhMenuDoc : Window, INotifyPropertyChanged
    {
        //public User userCurrent;
        private List<clsKhachHang.KhachHang> _lst = new List<clsKhachHang.KhachHang>();
        private List<clsNhomKhachHang> lstNhomKH = new List<clsNhomKhachHang>();
        private List<clsNhomKhachHangMacDinh.Datum> lstNhomKHMacDinh = new List<clsNhomKhachHangMacDinh.Datum>();
        private List<clsNhomKHConMacDinh.Datum> lstNhomkHConMacDinh = new List<clsNhomKHConMacDinh.Datum>();
        private List<Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum> _lstTT = new List<Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum>();

        public List<Views.KhachHang.TinhTrangKhachHang.clsTinhTrangKhachHang.Datum> lstTT { get => _lstTT; set => _lstTT = value; }
        private List<clsNguonKhachHang.Datum> _lstNguonKH = new List<clsNguonKhachHang.Datum>();
        public List<clsNguonKhachHang.Datum> lstNguonKH { get => _lstNguonKH; set => _lstNguonKH = value; }
        public List<clsKhachHang.KhachHang> lst { get => _lst; set => _lst = value; }
        public List<clsNhanVien.Item> LstNV { get => _lstNV; set => _lstNV = value; }

        private string TongSoDong = "";
        private string TongSoDongHopDong = "";
        private int TongSoTrang = 0;
        private List<int> LietKeTrang = new List<int>();
        private List<clsNhanVien.Item> _lstNV = new List<clsNhanVien.Item>();

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
        private List<clsSoLine.Datum> _lstSoLine = new List<clsSoLine.Datum>();
        public List<clsSoLine.Datum> LstSoLine { get => _lstSoLine; set => _lstSoLine = value; }
        private List<clsThongBao.ListNotification> _lstThongBao = new List<clsThongBao.ListNotification>();
        public List<clsThongBao.ListNotification> LstThongBao { get => _lstThongBao; set => _lstThongBao = value; }
        private List<Class.clsPhongBanThuocCongTy.Item> _lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        public List<Class.clsPhongBanThuocCongTy.Item> LstPhongBan { get => _lstPhongBan; set => _lstPhongBan = value; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private DataLogin_Employee _DataEmployee;
        public DataLogin_Employee DataEmployee { get => _DataEmployee; set { _DataEmployee = value; } }
        private string _PathImage;
        public string PathImage { get => _PathImage; set { _PathImage = value; OnPropertyChanged(); } }
        //Load
        private void showImage()
        {
            PathImage = "https://chamcong.24hpay.vn/upload/employee/" + DataEmployee.ep_image;
        }
        private List<clsHopDong.Datum> lstHopDong = new List<clsHopDong.Datum>();
        public List<clsHopDong.Datum> LstHopDong { get => lstHopDong; set => lstHopDong = value; }
        private List<clsNhomKHConMacDinh.Datum> lstNhomKHConMD = new List<clsNhomKHConMacDinh.Datum>();
        private string tkE = "";

        public frmThanhMenuDoc(DataLogin_Employee data, string accessTK, LoginWindow lg)
        {
            InitializeComponent();
            //frmLgE = lg;
            this.DataContext = this;
            WinLogin = lg;
            tkE = accessTK;
            this.DataEmployee = data;
            showImage();
            pnlIconMenuDoc.Visibility = Visibility.Collapsed;
            pnlTieuDeThuNho.Visibility = Visibility.Collapsed;
            clsBien.IdCongTy = data.com_id;
            if (data.position_id == "1")
            {
                textChucVuNV.Text = "Sinh viên thực tập";
            }
            else if (data.position_id == "2")
            {
                textChucVuNV.Text = "Nhân viên thử việc";
            }
            else if(data.position_id == "4")
            {
                textChucVuNV.Text = "Trưởng nhóm";
            }
            else if (data.position_id == "3")
            {
                textChucVuNV.Text = "Nhân viên chính thức";
            }
            else if (data.position_id == "5")
            {
                textChucVuNV.Text = "Phó trưởng phòng";
            }
            else if (data.position_id == "6")
            {
                textChucVuNV.Text = "Trưởng phòng";
            }
            else if (data.position_id == "7")
            {
                textChucVuNV.Text = "Phó giám đốc";
            }
            else if (data.position_id == "8")
            {
                textChucVuNV.Text = "Giám đốc";
            }
            else if (data.position_id == "9")
            {
                textChucVuNV.Text = "Nhân viên parttime";
            }
            else if (data.position_id == "10")
            {
                textChucVuNV.Text = "Phó ban dự án";
            }
            else if (data.position_id == "11")
            {
                textChucVuNV.Text = "Trưởng ban dự án";
            }
            else if (data.position_id == "12")
            {
                textChucVuNV.Text = "Phó tổ trưởng";
            }
            else if (data.position_id == "13")
            {
                textChucVuNV.Text = "Tổ trưởng";
            }
            else if (data.position_id == "14")
            {
                textChucVuNV.Text = "Phó tổng giám đốc";
            }
            else if (data.position_id == "16")
            {
                textChucVuNV.Text = "Tổng giám đốc";
            }
            else if (data.position_id == "17")
            {
                textChucVuNV.Text = "Thành viên hội đồng quản trị";
            }
            else if (data.position_id == "18")
            {
                textChucVuNV.Text = "Phó chủ tịch hội đồng quản trị";
            }
            else if (data.position_id == "19")
            {
                textChucVuNV.Text = "Chủ tịch hội đồng quản trị";
            }
            else if (data.position_id == "20")
            {
                textChucVuNV.Text = "Phó nhóm";
            }
            else if (data.position_id == "21")
            {
                textChucVuNV.Text = "Tổng giám đốc tập đoàn";
            }
            else if (data.position_id == "22")
            {
                textChucVuNV.Text = "Phó tổng giám đốc tập đoàn";
            }
            LoadDLHopDong();
            //LoadDataNhomKH(data);
            LoadDataNhomKHMacDinh(data);
            //LoadDataTinhTrangKhachHang(data);
            LoadDataTinhTrangKhachHangMacDinh(data);
            LoadDataNguonKhachHang(data);
            LoadDataNhanVien(data);
            LoadDataKhachHang(data);
            //gg
            loadDLPhanLoaiKH(data);
            loadDLLinhVuc(data);
            loadDLLoaiHinhKH(data);
            loadDLNganhNgheKH(data);
            LoadDLTinhThanh(data);
            LoadDLNganHang(data);
            LoadDLDoanhThu(data);
            LoadDLQuyMoNhanSu(data);
            LoadDLXepHangKH(data);
            LoadDLSoLineNguoiPhuTrach(data);
            LoadDLLichSuCuocGoi();
            LoadDuLieuThongBao();
            LoadDataPhongBan(data);
            Views.Home frm = new Views.Home(TongSoDong);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            ConnectionSocket();
        }
        private void LoadDataNhomKHMacDinh(DataLogin_Employee data)
        {
            if (data.position_id == "2")
            {
                using (HttpClient httpClientCon = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string urlCon = $"https://crm.timviec365.vn/ApiWinform/listGroupOnListCus";
                    httpClientCon.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kqCon = httpClientCon.GetAsync(urlCon);
                    clsNhomKHConMacDinh.Root apiCon = JsonConvert.DeserializeObject<clsNhomKHConMacDinh.Root>(kqCon.Result.Content.ReadAsStringAsync().Result);
                    if (apiCon != null)
                    {
                        foreach (var item in apiCon.data)
                        {
                            lstNhomKHConMD.Add(item);
                            cboNhomKHCon.Items.Add(item.gr_name);
                        }

                    }
                }
            }
            else
            {
                List<string> lstIdCha = new List<string>();
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        //string url = Properties.Resources.URL + "listGroupCustomer";
                        string url = "https://crm.timviec365.vn/ApiWinform/listGroup";
                        httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                        var kq = httpClient.GetAsync(url);
                        clsNhomKhachHangMacDinh.Root api = JsonConvert.DeserializeObject<clsNhomKhachHangMacDinh.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                        if (api != null)
                        {
                            foreach (var item in api.data)
                            {
                                lstIdCha.Add(item.gr_id);
                                lstNhomKHMacDinh.Add(item);
                                cboNhomKHCha.Items.Add(item.gr_name);

                            }
                            foreach (string str in lstIdCha)
                            {
                                using (HttpClient httpClientCon = new HttpClient())
                                {
                                    //string url = Properties.Resources.URL + "listGroupCustomer";
                                    string urlCon = $"https://crm.timviec365.vn/ApiWinform/listGroup?groupId={str}";
                                    httpClientCon.DefaultRequestHeaders.Add("Authorization", data.token);
                                    var kqCon = httpClientCon.GetAsync(urlCon);
                                    clsNhomKHConMacDinh.Root apiCon = JsonConvert.DeserializeObject<clsNhomKHConMacDinh.Root>(kqCon.Result.Content.ReadAsStringAsync().Result);
                                    if (apiCon != null)
                                    {
                                        foreach (var item in apiCon.data)
                                        {
                                            lstNhomKHConMD.Add(item);

                                        }

                                    }
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
        private void LoadDataTinhTrangKhachHangMacDinh(DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listAllStatusCusCom";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsTinhTrangKhachHang.Root api = JsonConvert.DeserializeObject<clsTinhTrangKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {

                            lstTT.Add(item);
                            cboTinhTrangKH.Items.Add(item.stt_name);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        public ConnectSocket Socket { get; set; }
        public void ConnectionSocket()
        {
            try
            {
                Socket = new ConnectSocket();
                Socket.WIO.OnConnected += WIO_OnConnected;
                Socket.WIO.OnDisconnected += WIO_OnDisconnected;
                Socket.WIO.OnReconnected += WIO_OnReconnected;
                //Socket.LoginSuccess(Convert.ToInt32(Properties.Settings.Default.IDChatNV), Convert.ToInt32(dt.com_id), "chat365");
                Socket.UserDisconnect(DataEmployee.ep_id);
                Socket.WIO.On("CRMNotification", response =>
                {
                    try
                    {
                        APINotification nof = new APINotification();
                        nof.content = response.GetValue<string>(0);
                        nof.customerName = response.GetValue<string>(1);
                        nof.customerId = response.GetValue<int>(2);
                        nof.groupName = response.GetValue<string>(3);
                        nof.link = response.GetValue<string>(4);
                        nof.type = response.GetValue<int>(5);
                        nof.phone = response.GetValue<string>(6);

                        Dispatcher.Invoke(() => {
                            lsvThongBao.Visibility = Visibility.Visible;
                            test.Insert(0, nof);
                            test = test.ToList();

                        });
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
        private void WIO_OnReconnected(object sender, int e)
        {
            Socket.LoginSuccess(Convert.ToInt32(DataEmployee.ep_id), Convert.ToInt32(DataEmployee.com_id), "CRM");
            Socket.UserDisconnect(DataEmployee.ep_id);
        }

        private void WIO_OnDisconnected(object sender, string e)
        {
            Socket.LoginSuccess(Convert.ToInt32(DataEmployee.ep_id), Convert.ToInt32(DataEmployee.com_id), "CRM");
            Socket.UserDisconnect(DataEmployee.ep_id);
        }

        private void WIO_OnConnected(object sender, EventArgs e)
        {
            Socket.LoginSuccess(Convert.ToInt32(DataEmployee.ep_id), Convert.ToInt32(DataEmployee.com_id), "CRM");
            Socket.UserDisconnect(DataEmployee.ep_id);
        }
        private List<object> _test = new List<object>();

        public List<object> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged(); }
        }
        private string Id;
        APINotification notifile;
        private string SoDienThoaiKH = "";
        private void lsvThongBao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            notifile = (APINotification)lsvThongBao.SelectedItem;
            if (notifile != null)
            {
                SoDienThoaiKH = notifile.phone;
            }
        }
        private void btnThoatThongBao_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //string item = (sender as TextBlock).DataContext as string;
            test.Remove(notifile);
            test = test.ToList();
            if (test.Count == 0)
            {
                lsvThongBao.Visibility = Visibility.Collapsed;
            }
        }
        private void btnGoiDienNhanh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(SoDienThoaiKH);
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", DataEmployee.token);
                web.QueryString.Add("phone", SoDienThoaiKH);
                web.UploadValuesCompleted += (sender1, e1) =>
                {
                    LoadDLLichSuCuocGoi();

                };
                web.UploadValuesAsync(new Uri(Properties.Resources.URL + "callCustomer"), "POST", web.QueryString);
            }
        }
        

        private void LoadDuLieuThongBao()
        {
            
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "http://43.239.223.142:9000/api/V2/Notification/GetListNotificationV2/81259";
                    httpClient.DefaultRequestHeaders.Add("Authorization", DataEmployee.token);
                    var kq = httpClient.GetAsync(url);
                    clsThongBao.Root api = JsonConvert.DeserializeObject<clsThongBao.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        //LstThongBao = api.data.listNotification;
                        //lsvSDT.ItemsSource = api.data;
                    }
                    //lsvThongBao.ItemsSource = LstThongBao;
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private List<string> lstDSLS = new List<string>();
        private void LoadDLLichSuCuocGoi()
        {
            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listCallHistory";
                    httpClient.DefaultRequestHeaders.Add("Authorization", DataEmployee.token);
                    var kq = httpClient.GetAsync(url);
                    clsDanhSachLSCuocGoi.Root api = JsonConvert.DeserializeObject<clsDanhSachLSCuocGoi.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        lstDSLS = api.data;
                        //lsvSDT.ItemsSource = api.data;
                    }
                    lsvSDT.ItemsSource = lstDSLS;
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void LoadDLHopDong()
        {
            LstHopDong = new List<clsHopDong.Datum>();
            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listContract";
                    httpClient.DefaultRequestHeaders.Add("Authorization", DataEmployee.token);
                    var kq = httpClient.GetAsync(url);
                    clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            TongSoDongHopDong = api.total.ToString();
                            lstHopDong.Add(item);
                            for (int i = 1; i <= lstHopDong.Count; i++)
                            {
                                item.stt = i.ToString();
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
        public void LoadDataNhomKH(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                //dgv.Items.Clear();
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
                            cboNhomKHCha.Items.Add(item.gr_name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }

        }
        public void LoadDataPhongBan(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                //cbx.Items.Clear();
                using (WebClient webClient = new WebClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = $"https://chamcong.24hpay.vn/service/list_department.php?id_com={data.com_id}";
                    webClient.Headers.Add("Authorization", data.token);
                    var kq = webClient.UploadValues(new Uri(url), webClient.QueryString);
                    Class.clsPhongBanThuocCongTy.Root api = JsonConvert.DeserializeObject<Class.clsPhongBanThuocCongTy.Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            LstPhongBan.Add(item);
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
        public void LoadDataNhanVien(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                //cbx.Items.Clear();
                using (WebClient webClient = new WebClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = $"https://chamcong.24hpay.vn/service/list_all_employee_of_company.php?id_com={data.com_id}";
                    webClient.Headers.Add("Authorization", data.token);
                    var kq = webClient.UploadValues(new Uri(url), webClient.QueryString);
                    clsNhanVien.Root api = JsonConvert.DeserializeObject<clsNhanVien.Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            LstNV.Add(item);
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
        private void LoadDataTinhTrangKhachHang(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listStatusCustomer";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsTinhTrangKhachHang.Root api = JsonConvert.DeserializeObject<clsTinhTrangKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        
                        foreach (var item in api.data)
                        {

                            lstTT.Add(item);
                            cboTinhTrangKH.Items.Add(item.stt_name);
                        }
                        lstTT.Add(new clsTinhTrangKhachHang.Datum() { stt_id = "9", stt_name = "Khách hàng VIP - timviec365.vn", status = 1, is_delete = "0" });
                        cboTinhTrangKH.Items.Add("Khách hàng VIP - timviec365.vn");
                        lstTT.Add(new clsTinhTrangKhachHang.Datum() { stt_id = "10", stt_name = "Khách hàng từng VIP - timviec365.vn", status = 1, is_delete = "0" });
                        cboTinhTrangKH.Items.Add("Khách hàng từng VIP - timviec365.vn");
                        lstTT.Add(new clsTinhTrangKhachHang.Datum() { stt_id = "12", stt_name = "Khách hàng chưa VIP - timviec365.vn", status = 1, is_delete = "0" });
                        cboTinhTrangKH.Items.Add("Khách hàng chưa VIP - timviec365.vn");
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void LoadDataNguonKhachHang(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getResouce";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsNguonKhachHang.Root api = JsonConvert.DeserializeObject<clsNguonKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            lstNguonKH.Add(item);
                            cboNguonKH.Items.Add(item.value);
                            //cboNguonKhachHang.Items.Add(item.value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void LoadDataKhachHang(Model.APIEntity.DataLogin_Employee data)
        {
            lst = new List<clsKhachHang.KhachHang>();
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
                        TongSoDong = api.total.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void LoadDLXepHangKH(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getRank";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsXepHangKhachHang.Root api = JsonConvert.DeserializeObject<clsXepHangKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {

                            LstXepHangKhachHang.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void LoadDLQuyMoNhanSu(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getSizeHuman";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsQuyMoNhanSu.Root api = JsonConvert.DeserializeObject<clsQuyMoNhanSu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {

                            LstQuyMoNhanSu.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void LoadDLDoanhThu(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getRevenue";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsDoanhThu.Root api = JsonConvert.DeserializeObject<clsDoanhThu.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {

                            LstDoanhThu.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void LoadDLNganHang(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getBank";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsNganHang.Root api = JsonConvert.DeserializeObject<clsNganHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {

                            LstNganHang.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void LoadDLTinhThanh(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getCity";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsTinhThanh.Root api = JsonConvert.DeserializeObject<clsTinhThanh.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {

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

        private void loadDLNganhNgheKH(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getCategory";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsNganhNgheKH.Root api = JsonConvert.DeserializeObject<clsNganhNgheKH.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {

                            ListNganhNghe.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void loadDLLoaiHinhKH(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getBusinessType";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsLoaiHinhKhachHang.Root api = JsonConvert.DeserializeObject<clsLoaiHinhKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {

                            ListLoaiHinhKH.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void loadDLLinhVuc(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getBussinessAreas";
                    httpClient.DefaultRequestHeaders.Add("Authorization",data.token);
                    var kq = httpClient.GetAsync(url);
                    clsLinhVucKH.Root api = JsonConvert.DeserializeObject<clsLinhVucKH.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {

                            ListLinhVuc.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        

        private void loadDLPhanLoaiKH(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/getClassify";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsPhanLoaiKhachHang.Root api = JsonConvert.DeserializeObject<clsPhanLoaiKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            ListPhanLoaiKH.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void LoadDLSoLineNguoiPhuTrach(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listLine";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsSoLine.Root api = JsonConvert.DeserializeObject<clsSoLine.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            clsBien.lstSoLine.Add(item);
                            //LstSoLine.Add(item);
                            for(int i = 1; i <= clsBien.lstSoLine.Count; i++)
                            {
                                item.stt = i.ToString();
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
        
        private void btnKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pnlMenuDoc.Visibility = Visibility.Visible;
            pnlIconMenuDoc.Visibility = Visibility.Collapsed;
            btnHienThiMenu.Visibility = Visibility.Collapsed;
            btnThuGonMenu.Visibility = Visibility.Visible;
            pnlMenuKhachHangCon.Visibility = Visibility.Visible;
        }
        
        private void btnDSNKH_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnDSNKH.Foreground = Brushes.YellowGreen;
        }

        private void btnDSNKH_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnDSNKH.Foreground = Brushes.White;
        }

        private void btnDanhSachKH_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnDanhSachKH.Foreground = Brushes.YellowGreen;
        }

        private void btnDanhSachKH_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnDanhSachKH.Foreground = Brushes.White;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //frmTrangChu2 frm = new frmTrangChu2();
            //frm.Show();
        }

        private void btnTrangChu1_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnTrangChu1.Foreground = Brushes.GreenYellow;
        }

        private void btnTrangChu1_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnTrangChu1.Foreground = Brushes.White;
        }

        private void btnHuongDan_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnHuongDan.Foreground = Brushes.GreenYellow;
        }

        private void btnHuongDan_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnHuongDan.Foreground = Brushes.White;
        }

        private void btnTinTuc_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnTinTuc.Foreground = Brushes.GreenYellow;
        }

        private void btnTinTuc_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnTinTuc.Foreground = Brushes.White;
        }

        

        

        

        private void btnTrangChu_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            frmTrangChu2 frm = new frmTrangChu2();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnDangXuat_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnDangXuat.Foreground = Brushes.GreenYellow;
        }

        private void btnDangXuat_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnDangXuat.Foreground = Brushes.White;
        }

        private void btnTrangChu2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            test.Clear();
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.Home frm = new Views.Home(TongSoDong);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnThuGonMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pnlMenuDoc.Visibility = Visibility.Collapsed;
            pnlIconMenuDoc.Visibility = Visibility.Visible;
            btnHienThiMenu.Visibility = Visibility.Visible;
            btnThuGonMenu.Visibility = Visibility.Collapsed;
        }

        private void btnHienThiMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pnlMenuDoc.Visibility = Visibility.Visible;
            pnlIconMenuDoc.Visibility = Visibility.Collapsed;
            btnHienThiMenu.Visibility = Visibility.Collapsed;
            btnThuGonMenu.Visibility = Visibility.Visible;
        }
        private int i = 0;
        private void btnTrangChu2_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void menuMarketing_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pnlMenuMarketing.Visibility == Visibility.Collapsed)
            {
                pnlMenuMarketing.Visibility = Visibility.Visible;
            }
            else
            {
                pnlMenuMarketing.Visibility = Visibility.Collapsed;
            }
        }

        private void menuChamSocKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pnlMenuChamSocKH.Visibility == Visibility.Collapsed)
            {
                pnlMenuChamSocKH.Visibility = Visibility.Visible;
            }
            else
            {
                pnlMenuChamSocKH.Visibility = Visibility.Collapsed;
            }
        }

        private void menuQuanLyThuChi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pnlMenuQuanLyThuChi.Visibility == Visibility.Collapsed)
            {
                pnlMenuQuanLyThuChi.Visibility = Visibility.Visible;
            }
            else
            {
                pnlMenuQuanLyThuChi.Visibility = Visibility.Collapsed;
            }
        }

        

        private void btnTongDai_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.ChamSocKhachHang.TongDai.frmTongDaiSauKetNoi frm = new Views.ChamSocKhachHang.TongDai.frmTongDaiSauKetNoi(this,LstSoLine, DataEmployee, tkE);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textTongDai.Text;
        }

        private void btnLichHen_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.ChamSocKhachHang.LichHen.frmLichHen frm = new Views.ChamSocKhachHang.LichHen.frmLichHen();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textLichHen.Text;
        }

        private void btnLichChamSocKH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.ChamSocKhachHang.LichChamSocKhachHang.frmLichChamSocKH frm = new Views.ChamSocKhachHang.LichChamSocKhachHang.frmLichChamSocKH();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textLichChamSocKH.Text;
        }

        private void btnKhaoSat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.ChamSocKhachHang.KhaoSat.frmKhaoSat frm = new Views.ChamSocKhachHang.KhaoSat.frmKhaoSat();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textKhaoSat.Text;
        }

        private void iconCaiDat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (testCaiDat.Visibility == Visibility.Collapsed)
            {
                showImage();
                testThongBao.Visibility = Visibility.Collapsed;
                testNhacNho.Visibility = Visibility.Collapsed;
                testMessager.Visibility = Visibility.Collapsed;
                testCaiDat.Visibility = Visibility.Visible;
            }
            else
            {
                testCaiDat.Visibility = Visibility.Collapsed;
            }
        }

        private void iconThongBao_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (testThongBao.Visibility == Visibility.Collapsed)
            {
                testThongBao.Visibility = Visibility.Visible;
                testNhacNho.Visibility = Visibility.Collapsed;
                testMessager.Visibility = Visibility.Collapsed;
                testCaiDat.Visibility = Visibility.Collapsed;
            }
            else
            {
                testThongBao.Visibility = Visibility.Collapsed;
            }
        }

        private void iconNhacNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (testNhacNho.Visibility == Visibility.Collapsed)
            {
                testNhacNho.Visibility = Visibility.Visible;
                testThongBao.Visibility = Visibility.Collapsed;
                testCaiDat.Visibility = Visibility.Collapsed;
                testMessager.Visibility = Visibility.Collapsed;
            }
            else
            {
                testNhacNho.Visibility = Visibility.Collapsed;
            }
        }

        private void iconMessager_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (testMessager.Visibility == Visibility.Collapsed)
            {
                testMessager.Visibility = Visibility.Visible;
                testCaiDat.Visibility = Visibility.Collapsed;
                testNhacNho.Visibility = Visibility.Collapsed;
                testThongBao.Visibility = Visibility.Collapsed;
            }
            else
            {
                testMessager.Visibility = Visibility.Collapsed;
            }
        }

        private void menuCaiDat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (this.Width <= 1000)
            //{
            //    pnlMenuDoc.Visibility = Visibility.Collapsed;
            //}
            //Views.CaiDat.frmCaiDat frm = new Views.CaiDat.frmCaiDat();
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
            //textDuongDan.Text = textKhaoSat.Text;
        }

        private void menuCoHoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.CoHoi.frmCoHoi frm = new Views.CoHoi.frmCoHoi();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textCoHoi.Text;
        }

        private void menuChienDich_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.ChienDich.ChienDich frm = new Views.ChienDich.ChienDich();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textChienDich.Text;
        }

        private void borderQlKinhDoanh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pnlQlKinhDoanh.Visibility == Visibility.Visible)
            {
                borderQlKinhDoanh1.Width = 345;
                btnCloseTroLyKinhDoanh.Visibility = Visibility.Collapsed;
                pnlQlKinhDoanh.Visibility = Visibility.Collapsed;
                //pnlQlKinhDoanh.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                borderQlKinhDoanh1.Width = 550;
                btnCloseTroLyKinhDoanh.Visibility = Visibility.Visible;
                //pnlQlKinhDoanh.HorizontalAlignment = HorizontalAlignment.Right;
                pnlQlKinhDoanh.Visibility = Visibility.Visible;

            }
        }

        

        private void menuHopDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            test = new List<object>();
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.HopDong.PageDSHopDongNhanVien frm = new Views.HopDong.PageDSHopDongNhanVien(this, lstHopDong, DataEmployee, TongSoDongHopDong);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textHopDong.Text;
        }

        private void btnTiemNang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.TiemNang.frmTiemNang frm = new Views.TiemNang.frmTiemNang();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnPhanQuyen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pnlMenuPhanQuyenCon.Visibility == Visibility.Collapsed)
            {
                pnlMenuPhanQuyenCon.Visibility = Visibility.Visible;
            }
            else
            {
                pnlMenuPhanQuyenCon.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.Width <= 1000)
            {
                pnlTieuDeThuNho.Visibility = Visibility.Visible;
                pnlTieuDe.Visibility = Visibility.Collapsed;
                pnlMenuDoc.Visibility = Visibility.Collapsed;
                pnlIconMenuDoc.Visibility = Visibility.Collapsed;
                if (testCaiDat.Visibility == Visibility.Visible)
                {
                    testCaiDat.Visibility = Visibility.Collapsed;
                    frmCaiDatThuNho.Visibility = Visibility.Visible;
                }
                if (testThongBao.Visibility == Visibility.Visible)
                {
                    testThongBao.Visibility = Visibility.Collapsed;
                    frmThongBaoThuNho.Visibility = Visibility.Visible;
                }
                if (testNhacNho.Visibility == Visibility.Visible)
                {
                    testNhacNho.Visibility = Visibility.Collapsed;
                    frmNhacNhoThuNho.Visibility = Visibility.Visible;
                }
                if (testMessager.Visibility == Visibility.Visible)
                {
                    testMessager.Visibility = Visibility.Collapsed;
                    frmMessagerThuNho.Visibility = Visibility.Visible;
                }
                
            }
            
            else
            {
                pnlTieuDeThuNho.Visibility = Visibility.Collapsed;
                pnlMenuDoc.Visibility = Visibility.Visible;
                pnlTieuDe.Visibility = Visibility.Visible;
                pnlIconMenuDoc.Visibility = Visibility.Collapsed;
                btnThuGonMenu.Visibility = Visibility.Visible;
                if (frmCaiDatThuNho.Visibility == Visibility.Visible)
                {
                    testCaiDat.Visibility = Visibility.Visible;
                    frmCaiDatThuNho.Visibility = Visibility.Collapsed;
                }
                if (frmThongBaoThuNho.Visibility == Visibility.Visible)
                {
                    testThongBao.Visibility = Visibility.Visible;
                    frmThongBaoThuNho.Visibility = Visibility.Collapsed;
                }
                if (frmNhacNhoThuNho.Visibility == Visibility.Visible)
                {
                    frmNhacNhoThuNho.Visibility = Visibility.Collapsed;
                    testNhacNho.Visibility = Visibility.Visible;
                }
                if (frmMessagerThuNho.Visibility == Visibility.Visible)
                {
                    frmMessagerThuNho.Visibility = Visibility.Collapsed;
                    testMessager.Visibility = Visibility.Visible;
                }
                //pnlIconMenuDoc.Visibility = Visibility.Visible;
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            //pnlMenuDoc.Visibility = Visibility.Visible;
            //pnlIconMenuDoc.Visibility = Visibility.Collapsed;
            //btnThuGonMenu.Visibility = Visibility.Visible;
            ////pnlIconMenuDoc.Visibility = Visibility.Visible;
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pnlMenuDoc.Visibility == Visibility.Collapsed)
            {
                pnlMenuDoc.Visibility = Visibility.Visible;
                pnlIconMenuDoc.Visibility = Visibility.Collapsed;
                btnThuGonMenu.Visibility = Visibility.Visible;
                //pnlIconMenuDoc.Visibility = Visibility.Visible;
            }
            else
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
                pnlIconMenuDoc.Visibility = Visibility.Collapsed;
                btnThuGonMenu.Visibility = Visibility.Visible;
                //pnlIconMenuDoc.Visibility = Visibility.Visible;
            }
        }

        private void iconCaiDatThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (frmCaiDatThuNho.Visibility == Visibility.Collapsed)
            {
                //testThongBao.Visibility = Visibility.Collapsed;
                //testNhacNho.Visibility = Visibility.Collapsed;
                //testMessager.Visibility = Visibility.Collapsed;
                showImage();
                frmCaiDatThuNho.Visibility = Visibility.Visible;
                frmThongBaoThuNho.Visibility = Visibility.Collapsed;
            }
            else
            {
                frmCaiDatThuNho.Visibility = Visibility.Collapsed;
            }
        }

        private void iconThongBaoThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (frmThongBaoThuNho.Visibility == Visibility.Collapsed)
            {
                //testThongBao.Visibility = Visibility.Collapsed;
                //testNhacNho.Visibility = Visibility.Collapsed;
                //testMessager.Visibility = Visibility.Collapsed;
                frmThongBaoThuNho.Visibility = Visibility.Visible;
                frmCaiDatThuNho.Visibility = Visibility.Collapsed;
            }
            else
            {
                frmThongBaoThuNho.Visibility = Visibility.Collapsed;
            }
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Application.Current.Shutdown();
            this.Close();
            frmTrangChu2 frm = new frmTrangChu2();
            frm.Show();

        }
        
        private int _IsFull = 0;
        public int IsFull
        {
            get { return _IsFull; }
            set
            {
                _IsFull = value;
                var workingArea = System.Windows.SystemParameters.WorkArea;
                switch (IsFull)
                {
                    case 0:
                        this.WindowState = WindowState.Normal;
                        Width = workingArea.Right - 180;
                        Height = workingArea.Bottom - 100;
                        Left = (workingArea.Right / 2) - (this.ActualWidth / 2);
                        Top = (workingArea.Bottom / 2) - (this.ActualHeight / 2);
                        this.ResizeMode = ResizeMode.CanResize;
                        break;
                    case 1:
                        this.WindowState = WindowState.Normal;
                        Left = workingArea.TopLeft.X;
                        Top = workingArea.TopLeft.Y;
                        Width = workingArea.Width;
                        Height = workingArea.Height;
                        this.ResizeMode = ResizeMode.NoResize;
                        break;
                    default:
                        break;
                }
                OnPropertyChanged();
            }
        }

        

        private void btnMaximize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            IsFull = 1;
            btnMaximize.Visibility = Visibility.Collapsed;
            btnNomal.Visibility = Visibility.Visible;
        }

        private void btnNomal_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            IsFull = 0;
            btnMaximize.Visibility = Visibility.Visible;
            btnNomal.Visibility = Visibility.Collapsed;
        }


        private void pnlTieuDe1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        public LoginWindow WinLogin { get; set; }
        private void btnDangXuat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();

            WinLogin.WinMain.IsFull = WinLogin.IsFull;
            WinLogin.WinMain.Width = WinLogin.ActualWidth;
            WinLogin.WinMain.Height = WinLogin.ActualHeight;
            WinLogin.WinMain.Left = WinLogin.Left;
            WinLogin.WinMain.Top = WinLogin.Top;
            WinLogin.WinMain.Show();
            //WinLogin.Show();
            //this.Close();

        }

        private void btnDangXuatThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();

            WinLogin.WinMain.IsFull = WinLogin.IsFull;
            WinLogin.WinMain.Width = WinLogin.ActualWidth;
            WinLogin.WinMain.Height = WinLogin.ActualHeight;
            WinLogin.WinMain.Left = WinLogin.Left;
            WinLogin.WinMain.Top = WinLogin.Top;
            WinLogin.WinMain.Show();
        }
        private void btnDanhSachKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsBien.DanhSachKH = false;
            test=new List<object>();
            lsvThongBao.Visibility = Visibility.Collapsed;
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            //LoadAppCRM.Visibility = Visibility.Visible;
            Views.KhachHang.DanhSachKhachHangNhanVien.frmCustomerNhanVien frm = new Views.KhachHang.DanhSachKhachHangNhanVien.frmCustomerNhanVien(this, DataEmployee, lst, TongSoDong, lstNguonKH, lstNhomKHMacDinh, lstNhomKHConMD, lstTT, LstNV, ListPhanLoaiKH, ListLinhVuc, ListLoaiHinhKH, ListNganhNghe, ListTinhThanh, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang, LstPhongBan);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textDanhSachKhachHang.Text;
            
           // LoadAppCRM.Visibility = Visibility.Collapsed;
            //if (frm.DialogResult.HasValue && frm.DialogResult.Value)
            //{
                
            //}

        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                clsBien.DanhSachKH = true;
                test = new List<object>();
                lsvThongBao.Visibility = Visibility.Collapsed;
                if (this.Width <= 1000)
                {
                    pnlMenuDoc.Visibility = Visibility.Collapsed;
                }
                //LoadAppCRM.Visibility = Visibility.Visible;
                Views.KhachHang.DanhSachKhachHangNhanVien.frmCustomerNhanVien frm = new Views.KhachHang.DanhSachKhachHangNhanVien.frmCustomerNhanVien(this, DataEmployee, lst, TongSoDong, lstNguonKH, lstNhomKHMacDinh, lstNhomKHConMD, lstTT, LstNV, ListPhanLoaiKH, ListLinhVuc, ListLoaiHinhKH, ListNganhNghe, ListTinhThanh, LstNganHang, LstDoanhThu, LstQuyMoNhanSu, LstXepHangKhachHang, LstPhongBan);
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                //frm.Close();
                pnlHienThi.Children.Add(content as UIElement);
                textDuongDan.Text = textDanhSachKhachHang.Text;
            }
        }
        private void btnNhomKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            test = new List<object>();
            lsvThongBao.Visibility = Visibility.Collapsed;
            lsvThongBao.Visibility = Visibility.Collapsed;
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.KhachHang.NhomKhachHangNhanVien.frmNhomKhachHangNhanVien frm = new Views.KhachHang.NhomKhachHangNhanVien.frmNhomKhachHangNhanVien(DataEmployee, this);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textNhomKhachHang.Text;
        }

        private void btnTinhTrangKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            test = new List<object>();
            lsvThongBao.Visibility = Visibility.Collapsed;
            LoadFormTinhTrangKhachHang();
        }
        public void LoadFormTinhTrangKhachHang()
        {
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.KhachHang.TinhTrangKhachHangNhanVien.frmTinhTrangKhachHangNhanVien frm = new Views.KhachHang.TinhTrangKhachHangNhanVien.frmTinhTrangKhachHangNhanVien(this, textTenNhanVien.Text, DataEmployee);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textTinhTrangKhachHang.Text;
        }

        private void menuNhapLieu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            test = new List<object>();
            lsvThongBao.Visibility = Visibility.Collapsed;
            if (this.Width <= 1000)
            {
                pnlMenuDoc.Visibility = Visibility.Collapsed;
            }
            Views.KhachHang.NhapLieuNhanVien.frmThemKhachHangNhanVien frm = new Views.KhachHang.NhapLieuNhanVien.frmThemKhachHangNhanVien(this, lstNguonKH, lstNhomKHConMD, lstNhomKHMacDinh, LstNV, lstTT, DataEmployee);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            textDuongDan.Text = textNhapLieu.Text;
        }

        private void menuKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pnlMenuKhachHangCon.Visibility == Visibility.Collapsed)
            {
                pnlMenuKhachHangCon.Visibility = Visibility.Visible;
            }
            else
            {
                pnlMenuKhachHangCon.Visibility = Visibility.Collapsed;
            }    
        }

        private void btnLuu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addCustomerByAssistant")))
            {
                try
                {
                    RestRequest request = new RestRequest();
                    request.Method = Method.Post;
                    request.AlwaysMultipartFormData = true;
                    request.AddHeader("Authorization", DataEmployee.token);
                    //request.AddParameter("id", IdKH);
                    request.AddParameter("name", tb_TenKhachHang.Text);


                    if (tb_SoDienThoai.Text == "")
                    {
                        request.AddParameter("phone", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("phone", tb_SoDienThoai.Text);
                    }
                    if (tb_EmailKH.Text == "")
                    {
                        request.AddParameter("email", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("email", tb_EmailKH.Text);
                    }
                    request.AddParameter("content_call", tb_NoiDungCuocGoi.Text);
                    if (tb_MoTaKH.Text == "")
                    {
                        request.AddParameter("description", "Chưa cập nhật");
                    }
                    else
                    {
                        request.AddParameter("description", tb_MoTaKH.Text);
                    }


                    if (cboNguonKH.Text == "Chọn nguồn khách hàng")
                    {
                        request.AddParameter("resoure", "0");
                    }
                    else
                    {
                        foreach (clsNguonKhachHang.Datum nkh in lstNguonKH)
                        {
                            if (cboNguonKH.Text == nkh.value)
                            {
                                request.AddParameter("resoure", nkh.id.ToString());
                            }
                        }
                    }
                    if (cboNhomKHCha.Text == "Chọn nhóm khách hàng")
                    {
                        request.AddParameter("group", "0");
                    }
                    else
                    {
                        if (cboNhomKHCon.Text == "Chọn nhóm khách hàng")
                        {
                            request.AddParameter("group", "0");
                        }
                        else
                        {
                            foreach (clsNhomKhachHang nhkh in lstNhomKH)
                            {
                                foreach (ListsChildCustomer nhkhc in nhkh.lists_child)
                                {
                                    if (cboNhomKHCon.Text == nhkhc.gr_name)
                                    {
                                        request.AddParameter("group", nhkhc.gr_id.ToString());
                                    }
                                }
                            }
                        }
                    }
                    if (cboTinhTrangKH.Text == "Chọn tình trạng khách hàng")
                    {
                        request.AddParameter("status", "0");
                    }
                    else
                    {
                        foreach (clsTinhTrangKhachHang.Datum ttkh in lstTT)
                        {
                            if (cboTinhTrangKH.Text == ttkh.stt_name)
                            {
                                request.AddParameter("status", ttkh.stt_id.ToString());
                            }
                        }
                    }
                    request.AddParameter("start_date", dtpTuNgay.Text);
                    request.AddParameter("end_date", dtpDenNgay.Text);
                    RestResponse resAlbum = restclient.Execute(request);
                    var b = resAlbum.Content;
                    LoadDataKhachHang(DataEmployee);
                    tb_SoDienThoai.Text = "";
                    tb_TenKhachHang.Text = "";
                    tb_EmailKH.Text = "";
                    tb_MoTaKH.Text = "";
                    tb_NoiDungCuocGoi.Text = "";
                    cboNhomKHCha.Text = "Chọn nhóm khách hàng";
                    cboNhomKHCon.Text = "Chọn nhóm khách hàng";
                    cboTinhTrangKH.Text = "Chọn tình trạng khách hàng";
                    cboNguonKH.Text = "Chọn nguồn khách hàng";
                    Socket.UserDisconnect(DataEmployee.ep_id);
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
                foreach (clsNhomKhachHangMacDinh.Datum nhomcha in lstNhomKHMacDinh)
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
                                httpClient.DefaultRequestHeaders.Add("Authorization", DataEmployee.token);
                                var kq = httpClient.GetAsync(url);
                                clsNhomKHConMacDinh.Root api = JsonConvert.DeserializeObject<clsNhomKHConMacDinh.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                                if (api != null)
                                {
                                    foreach (var item in api.data)
                                    {
                                        lstNhomkHConMacDinh.Add(item);
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

        private void btnGoiDien_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", DataEmployee.token);
                    httpClient.QueryString.Add("phone", tb_SoDienThoai.Text);
                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {
                        LoadDLLichSuCuocGoi();
                        
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "callCustomer"), "POST", httpClient.QueryString);
                }
                catch
                {
                }
            }
            
        }
        private List<string> lstSearchSDT = new List<string>();
        private void tb_SoDienThoai_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvSDT.Visibility = Visibility.Visible;
            //lsvSDT.Items.Clear();
            lstSearchSDT = new List<string>();
            foreach (string str in lstDSLS)
            {
                if (str.Contains(tb_SoDienThoai.Text))
                {
                    lstSearchSDT.Add(str);
                }
            }
            lsvSDT.ItemsSource = lstSearchSDT;
        }

        private void formMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lsvSDT.Visibility = Visibility.Collapsed;
            
        }

        private void pnlQlKinhDoanh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lsvSDT.Visibility = Visibility.Collapsed;
        }

        private void lsvSDT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] SDT = lsvSDT.SelectedItem.ToString().Split(Convert.ToChar("-"));
            tb_SoDienThoai.Text = SDT[0];
            //MessageBox.Show(lsvSDT.SelectedItem.ToString());
        }

        private void iconNhacNhoThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (frmNhacNhoThuNho.Visibility == Visibility.Collapsed)
            {
                frmNhacNhoThuNho.Visibility = Visibility.Visible;
            }
            else
            {
                frmNhacNhoThuNho.Visibility = Visibility.Collapsed;
            }
        }

        private void iconMessagerThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (frmMessagerThuNho.Visibility == Visibility.Collapsed)
            {
                frmMessagerThuNho.Visibility = Visibility.Visible;
            }
            else
            {
                frmMessagerThuNho.Visibility = Visibility.Collapsed;
            }
        }

        private void btnThongTinCaNhan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://chamcong.timviec365.vn/thong-bao.html?s=81b016d57ec189daa8e04dd2d59a22c3." + DataEmployee.ep_id + "." + DataEmployee.pass + "&link=https://quanlychung.timviec365.vn/quan-ly-thong-tin-tai-khoan-nhan-vien.html");
        }

        private void btnThongTinCaNhanThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://chamcong.timviec365.vn/thong-bao.html?s=81b016d57ec189daa8e04dd2d59a22c3." + DataEmployee.ep_id + "." + DataEmployee.pass + "&link=https://quanlychung.timviec365.vn/quan-ly-thong-tin-tai-khoan-nhan-vien.html");
        }
        private void tb_TenKhachHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvSDT.Visibility = Visibility.Collapsed;
        }

        private void tb_TenKhachHang_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            lsvSDT.Visibility = Visibility.Collapsed;
        }

        private void tb_TenKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lsvSDT.Visibility = Visibility.Collapsed;
        }

        private void textDuongDan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

    }
}
