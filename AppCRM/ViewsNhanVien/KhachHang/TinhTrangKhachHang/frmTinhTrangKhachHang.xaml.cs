using AppCRM.Views.KhachHang.TinhTrangKhachHang;
using Newtonsoft.Json;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.TinhTrangKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmTinhTrangKhachHangNhanVien.xaml
    /// </summary>
    public partial class frmTinhTrangKhachHangNhanVien : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<clsTinhTrangKhachHang.Datum> lst = new List<clsTinhTrangKhachHang.Datum>();
        private string _STT = "";
        public string STT { get => _STT; set => _STT = value; }
        public clsTinhTrangKhachHang.Datum Ttrang { get => _ttrang; set => _ttrang = value; }

        private frmThanhMenuDoc frmMain;
        private Model.APIEntity.DataLogin_Employee dt;
        private string _TenCongTy = "";
        public string TenCongTy { get => _TenCongTy; set => _TenCongTy = value; }
        public frmTinhTrangKhachHangNhanVien(frmThanhMenuDoc frm, string TenCTy, Model.APIEntity.DataLogin_Employee data)
        {
            InitializeComponent();
            this.DataContext = this;
            frmMain = frm;
            dt = data;
            TenCongTy = TenCTy;
            STT = "1";
            LoadDataTinhTrangKhachHang(TenCTy);
            frmMain.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }
        private void LoadDataTinhTrangKhachHang(string ten)
        {

            try
            {
                lst = new List<clsTinhTrangKhachHang.Datum>();
                //dgv.Items.Clear();
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listStatusCustomer";
                    httpClient.DefaultRequestHeaders.Add("Authorization", dt.token);
                    var kq = httpClient.GetAsync(url);
                    clsTinhTrangKhachHang.Root api = JsonConvert.DeserializeObject<clsTinhTrangKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            item.nguoi_tao = ten;
                            lst.Add(item);

                        }
                        dgv.ItemsSource = lst;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        string ThemMoiTT = "Thêm mới tình trạng khách hàng";
        string ChinhSuaTT = "Chỉnh sửa tình trạng khách hàng";
        string TenTT = "";
        private void btnThemMoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new PopUpThemMoiTinhTrangNhanVien(this, dt, ThemMoiTT, Ttrang));
            LoadDataTinhTrangKhachHang(TenCongTy);
            //frmThemMoiTinhTrangKHNhanVien frm = new frmThemMoiTinhTrangKHNhanVien(dt, ThemMoiTT, Ttrang);
            //frm.ShowDialog();
            //LoadDataTinhTrangKhachHang(TenCongTy);
        }
        private string MaTT = "";
        private string TrangThai = "";


        private clsTinhTrangKhachHang.Datum _ttrang = new clsTinhTrangKhachHang.Datum();
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsTinhTrangKhachHang.Datum tt = (clsTinhTrangKhachHang.Datum)dgv.SelectedItem;
            Ttrang = tt;
            if (tt != null)
            {
                MaTT = tt.stt_id;
                TenTT = tt.stt_name;
                TrangThai = tt.status.ToString();
            }
        }

        private void btnSua_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new PopUpThemMoiTinhTrangNhanVien(this, dt, ChinhSuaTT, Ttrang));
            LoadDataTinhTrangKhachHang(TenCongTy);
        }
        //private int _isOn = 0;
        //public int isOn { get => _isOn; set { _isOn = value; OnPropertyChanged(); } }
        //private void TurnOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    isOn = isOn == 0 ? 1 : 0;

        //}

        //private void turnOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    isOn = isOn == 1 ? 0 : 1;

        //}
        private void textTrangThai_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", dt.token);
                    httpClient.QueryString.Add("id", MaTT);
                    if (TrangThai == "0")
                    {
                        httpClient.QueryString.Add("status", "1");
                    }
                    else
                    {
                        httpClient.QueryString.Add("status", "0");
                    }
                    //httpClient.QueryString.Add("listIdDep", null);
                    //httpClient.QueryString.Add("listIdEpl", null);

                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {

                        frmTinhTrangKhachHangNhanVien frm = new frmTinhTrangKhachHangNhanVien(frmMain, TenCongTy, dt);
                        pnlHienThi.Children.Clear();
                        object content = frm.Content;
                        frm.Content = null;
                        //frm.Close();
                        pnlHienThi.Children.Add(content as UIElement);
                        //APIRequestContact receiveInfo = JsonConvert.DeserializeObject(UnicodeEncoding.UTF8.GetString(e.Result));
                        //if (receiveInfo.data != null)
                        //{
                        //    DataChat.Socket.DeleteContact(contactId, userId);
                        //}
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateItemStatusCustomer"), "POST", httpClient.QueryString);

                }
                catch
                {
                }
            }
        }
        public void LoadLaiDanhSachTinhTrangKhachHang()
        {
            frmTinhTrangKhachHangNhanVien frm = new frmTinhTrangKhachHangNhanVien(frmMain, TenCongTy, dt);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnXoaTinhTrangKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new PopupMessageXoaTTKHNhanVien(this, MaTT, dt));
            //frmMessageXoaTTKHNhanVien frm = new frmMessageXoaTTKHNhanVien(MaTT, dt);
            //frm.ShowDialog();
            //LoadDataTinhTrangKhachHang(TenCongTy);
        }

        private void dgv_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }
        public List<clsTinhTrangKhachHang.Datum> lstSearch = new List<clsTinhTrangKhachHang.Datum>();
        private void btnTimKiem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstSearch.Clear();

            if (tbsearchCH.Text.Equals(""))
            {
                lstSearch.AddRange(lst);
            }
            else
            {
                foreach (clsTinhTrangKhachHang.Datum anim in lst)
                {

                    if (anim.stt_name.Contains(tbsearchCH.Text))
                    {
                        lstSearch.Add(anim);
                    }
                }
            }

            dgv.ItemsSource = lstSearch.ToList();
        }

        private void te_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmDemo frm = new frmDemo(lst);
            frm.ShowDialog();
        }

        private void TurnOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clsTinhTrangKhachHang.Datum item = (sender as Border).DataContext as clsTinhTrangKhachHang.Datum;
            item.status = item.status == 1 ? 0 : 1;
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", dt.token);
                    httpClient.QueryString.Add("id", item.stt_id);
                    httpClient.QueryString.Add("status", item.status.ToString());
                    httpClient.UploadValuesTaskAsync(new Uri(Properties.Resources.URL + "updateItemStatusCustomer"), httpClient.QueryString);
                }
                catch
                {
                }
            }
        }

        private void Xanh_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clsTinhTrangKhachHang.Datum item = (sender as Border).DataContext as clsTinhTrangKhachHang.Datum;
            item.status = item.status == 1 ? 0 : 1;
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", dt.token);
                    httpClient.QueryString.Add("id", item.stt_id);
                    httpClient.QueryString.Add("status", item.status.ToString());
                    httpClient.UploadValuesTaskAsync(new Uri(Properties.Resources.URL + "updateItemStatusCustomer"), httpClient.QueryString);
                }
                catch
                {
                }
            }
        }
    }
}
