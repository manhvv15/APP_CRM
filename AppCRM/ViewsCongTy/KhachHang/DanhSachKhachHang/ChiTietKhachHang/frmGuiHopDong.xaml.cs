using AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang;
using AppCRM.Views.KhachHang.NhomKhachHang;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCRM.ViewsCongTy.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmGuiHopDong.xaml
    /// </summary>
    public partial class frmGuiHopDong : Page,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private frmTrangChuSauDangNhapCongTy frmMain;
        private Model.APIEntity.DataLogin_Company data;
        private string IdKhachHang = "";
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        private List<string> lstTenNV = new List<string>();
        private List<string> lstTenPB = new List<string>();
        private List<Class.clsPhongBanThuocCongTy.Item> lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        private List<string> lstChucVu = new List<string>() { "Chọn chức vụ", "Sinh viên thực tập", "Nhân viên parttime", "Nhân viên thử việc", "Nhân viên chính thức", "Trưởng nhóm", "Phó nhóm", "Tổ trưởng", "Phó tổ trưởng", "Trưởng ban dự án", "Phó ban dự án", "Trưởng phòng", "Phó trưởng phòng", "Giám đốc", "Phó giám đốc", "Tổng giám đốc", "Phó tổng giám đốc", "Tổng giám đốc tập đoàn", "Phó tổng giám đốc tập đoàn", "Chủ tịch hội đồng quản trị", "Phó chủ tịch hội đồng quản trị", "Thành viên hội đồng quản trị" };
        private string IdHopDong = "";
        private string TenKH = "";
        private string EmailKH = "";
        private string SdtKH = "";
        public frmGuiHopDong(Model.APIEntity.DataLogin_Company dt, List<clsNhanVien.Item> lstNV, List<Class.clsPhongBanThuocCongTy.Item> lstPB, string IdHd, frmTrangChuSauDangNhapCongTy frm,string IdKH,string tenkh,string emailkh,string sdtkh)
        {
            InitializeComponent();
            this.DataContext = this;
            TenKH = tenkh;
            EmailKH = emailkh;
            SdtKH = sdtkh;
            IdKhachHang = IdKH;
            frmMain = frm;
            IdHopDong = IdHd;
            lstNhanVien = lstNV;
            lstPhongBan = lstPB;
            data = dt;
            lstTenNV.Add("Chọn nhân viên");
            lstTenPB.Add("Chọn phòng ban");
            //lstNV.Insert(0, new clsNhanVien.Item { ep_name = "Chọn nhân viên" });
            //lstPB.Insert(0, new Class.clsPhongBanThuocCongTy.Item { dep_name = "Chọn phòng ban" });
            foreach (clsNhanVien.Item Nv in lstNV)
            {
                lstTenNV.Add("(" + Nv.ep_id + ")" + " " + Nv.ep_name);
            }
            lsvNhanVien.ItemsSource = lstTenNV;
            foreach (Class.clsPhongBanThuocCongTy.Item Pb in lstPB)
            {
                lstTenPB.Add(Pb.dep_name);
            }
            lsvPhongBan.ItemsSource = lstTenPB;
            lsvChucVu.ItemsSource = lstChucVu;
            lstNVDuocChon = new List<Class.HopDong.clsNhanVienDuocChon.Data>();
            lstIdNV = new List<string>();
        }
        private List<object> _test = new List<object>();

        public List<object> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged(); }
        }
        private void cboNhanVien_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (borDSNhanVien.Visibility == Visibility.Visible)
            {
                borDSNhanVien.Visibility = Visibility.Collapsed;
            }
            else
            {
                borDSNhanVien.Visibility = Visibility.Visible;
                borDSChucVu.Visibility = Visibility.Collapsed;
                borDSPhongBan.Visibility = Visibility.Collapsed;
            }
        }

        private void cboChucVu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (borDSChucVu.Visibility == Visibility.Visible)
            {
                borDSChucVu.Visibility = Visibility.Collapsed;
            }
            else
            {
                borDSChucVu.Visibility = Visibility.Visible;
                borDSNhanVien.Visibility = Visibility.Collapsed;
                borDSPhongBan.Visibility = Visibility.Collapsed;
            }
        }

        private void cboPhongBan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (borDSPhongBan.Visibility == Visibility.Visible)
            {
                borDSPhongBan.Visibility = Visibility.Collapsed;
            }
            else
            {
                borDSPhongBan.Visibility = Visibility.Visible;
                borDSChucVu.Visibility = Visibility.Collapsed;
                borDSNhanVien.Visibility = Visibility.Collapsed;
            }
        }
        private List<Class.HopDong.clsNhanVienDuocChon.Data> lstNVDuocChon = new List<Class.HopDong.clsNhanVienDuocChon.Data>();
        private void lsvNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                textNhanVien.Text = lsvNhanVien.SelectedItem.ToString();
                string[] Id1 = textNhanVien.Text.Split(Convert.ToChar(")"));
                string Id2 = Id1[0];
                string[] Id3 = Id2.Split(Convert.ToChar("("));
                string MaNhanVien = Id3[Id3.Length - 1];
                borDSNhanVien.Visibility = Visibility.Collapsed;
                dgv.Visibility = Visibility.Visible;
                Class.HopDong.clsNhanVienDuocChon.Data NhanVien = new Class.HopDong.clsNhanVienDuocChon.Data();
                NhanVien.IdNhanVien = MaNhanVien;
                foreach (clsNhanVien.Item nv in lstNhanVien)
                {
                    if (NhanVien.IdNhanVien == nv.ep_id)
                    {
                        NhanVien.TenNhanVien = nv.ep_name;
                        if (nv.position_id == "3")
                        {
                            NhanVien.ChucVu = "Nhân viên chính thức";
                        }
                        else if (nv.position_id == "4")
                        {
                            NhanVien.ChucVu = "Trưởng nhóm";
                        }
                        else if (nv.position_id == "2")
                        {
                            NhanVien.ChucVu = "Nhân viên thử việc";
                        }
                        else if (nv.position_id == "1")
                        {
                            NhanVien.ChucVu = "Sinh viên thực tập";
                        }
                        else if (nv.position_id == "5")
                        {
                            NhanVien.ChucVu = "Phó trưởng phòng";
                        }
                        else if (nv.position_id == "6")
                        {
                            NhanVien.ChucVu = "Trưởng phòng";
                        }
                        else if (nv.position_id == "7")
                        {
                            NhanVien.ChucVu = "Phó giám đốc";
                        }
                        else if (nv.position_id == "8")
                        {
                            NhanVien.ChucVu = "Giám đốc";
                        }
                        else if (nv.position_id == "9")
                        {
                            NhanVien.ChucVu = "Nhân viên parttime";
                        }
                        else if (nv.position_id == "10")
                        {
                            NhanVien.ChucVu = "Phó ban dự án";
                        }
                        else if (nv.position_id == "11")
                        {
                            NhanVien.ChucVu = "Trưởng ban dự án";
                        }
                        else if (nv.position_id == "12")
                        {
                            NhanVien.ChucVu = "Phó tổ trưởng";
                        }
                        else if (nv.position_id == "13")
                        {
                            NhanVien.ChucVu = "Tổ trưởng";
                        }
                        else if (nv.position_id == "14")
                        {
                            NhanVien.ChucVu = "Phó tổng giám đốc";
                        }
                        else if (nv.position_id == "16")
                        {
                            NhanVien.ChucVu = "Tổng giám đốc";
                        }
                        else if (nv.position_id == "17")
                        {
                            NhanVien.ChucVu = "Thành viên hội đồng quản trị";
                        }
                        else if (nv.position_id == "18")
                        {
                            NhanVien.ChucVu = "Phó chủ tịch hội đồng quản trị";
                        }
                        else if (nv.position_id == "19")
                        {
                            NhanVien.ChucVu = "Chủ tịch hội đồng quản trị";
                        }
                        else if (nv.position_id == "20")
                        {
                            NhanVien.ChucVu = "Nhóm phó";
                        }
                        else if (nv.position_id == "21")
                        {
                            NhanVien.ChucVu = "Tổng giám đốc tập đoàn";
                        }
                        else if (nv.position_id == "22")
                        {
                            NhanVien.ChucVu = "Phó tổng giám đốc tập đoàn";
                        }

                        NhanVien.PhongBan = nv.dep_name;
                    }
                }
                lstNVDuocChon.Add(NhanVien);
                for (int i = 1; i <= lstNVDuocChon.Count; i++)
                {
                    NhanVien.Stt = i.ToString();
                }
                //dgv.ItemsSource = lstNVDuocChon;
                dgv.Items.Add(NhanVien);
            }
            catch (Exception ex)
            {

            }
        }
        private List<string> lstNhanVienThuocPhongBan = new List<string>();
        private void lsvPhongBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstNhanVienThuocPhongBan = new List<string>();
            textPhongBan.Text = lsvPhongBan.SelectedItem.ToString();
            foreach (clsNhanVien.Item nv in lstNhanVien)
            {
                if (lsvPhongBan.SelectedItem.ToString() == nv.dep_name)
                {
                    lstNhanVienThuocPhongBan.Add("(" + nv.ep_id + ")" + " " + nv.ep_name);
                }
            }
            lsvNhanVien.ItemsSource = lstNhanVienThuocPhongBan;
            borDSPhongBan.Visibility = Visibility.Collapsed;
        }
        private List<string> lstSearchPB = new List<string>();
        private void textSearchPhongBan_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstSearchPB = new List<string>();
            foreach (string str in lstTenPB)
            {
                if (str.Contains(textSearchPhongBan.Text))
                {
                    lstSearchPB.Add(str);
                }
            }
            lsvPhongBan.ItemsSource = lstSearchPB;
        }
        private List<string> lstSearchNV = new List<string>();
        private void textSearchNhanVien_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstSearchNV = new List<string>();
            foreach (string str in lstTenNV)
            {
                if (str.Contains(textSearchNhanVien.Text))
                {
                    lstSearchNV.Add(str);
                }
            }
            lsvNhanVien.ItemsSource = lstSearchNV;
        }

        private void chkNoiBoCongTy_Checked(object sender, RoutedEventArgs e)
        {
            borNoiBoCongTy.Visibility = Visibility.Visible;
        }

        private void chkNoiBoCongTy_Unchecked(object sender, RoutedEventArgs e)
        {
            borNoiBoCongTy.Visibility = Visibility.Collapsed;
        }

        private void chkNgoaiCongTy_Checked(object sender, RoutedEventArgs e)
        {
            borNgoaiCongTy.Visibility = Visibility.Visible;
        }

        private void chkNgoaiCongTy_Unchecked(object sender, RoutedEventArgs e)
        {
            borNgoaiCongTy.Visibility = Visibility.Collapsed;
        }

        private void TKCaNhan_Checked(object sender, RoutedEventArgs e)
        {
            borTKCaNhan.Visibility = Visibility.Visible;
        }

        private void TKCaNhan_Unchecked(object sender, RoutedEventArgs e)
        {
            borTKCaNhan.Visibility = Visibility.Collapsed;
        }

        private void tetXoaNV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Class.HopDong.clsNhanVienDuocChon.Data nv = (Class.HopDong.clsNhanVienDuocChon.Data)dgv.SelectedItem;
            if (nv != null)
            {
                lstNVDuocChon.Remove(nv);
                dgv.Items.Remove(nv);
            }

        }

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //private frmThemHopDongBan frmThemHD;
        private void bd_GuiHopDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lstIdNV.Count > 0 && lstNVDuocChon.Count > 0)
            {
                List<string> lstIdNVNoiBo = new List<string>();
                string DSIdNhanVienNoiBo = "";
                foreach (Class.HopDong.clsNhanVienDuocChon.Data nv in lstNVDuocChon)
                {
                    lstIdNVNoiBo.Add(nv.IdNhanVien);
                }
                foreach (string str in lstIdNVNoiBo)
                {
                    DSIdNhanVienNoiBo = DSIdNhanVienNoiBo + str + ",";
                }
                DSIdNhanVienNoiBo = DSIdNhanVienNoiBo.Remove(DSIdNhanVienNoiBo.Length - 1);
                string DSIdNhanVien = "";
                foreach (string nv in lstIdNV)
                {
                    DSIdNhanVien = DSIdNhanVien + nv + ",";
                }
                DSIdNhanVien = DSIdNhanVien.Remove(DSIdNhanVien.Length - 1);
                using (WebClient web = new WebClient())
                {
                    web.Headers.Add("Authorization", data.token);
                    web.QueryString.Add("contractId", IdHopDong);
                    web.QueryString.Add("internal_employee", DSIdNhanVienNoiBo);
                    web.QueryString.Add("public_employee", DSIdNhanVien);
                    web.UploadValuesCompleted += (sender1, e1) =>
                    {
                        frmHopDongBan frm = new frmHopDongBan(frmMain, IdKhachHang, data, lstNhanVien, lstPhongBan, TenKH, EmailKH, SdtKH);
                        pnlHienThi.Children.Clear();
                        object content = frm.Content;
                        frm.Content = null;
                        pnlHienThi.Children.Add(content as UIElement);
                        frmMain.pnlShowPopup.Children.Add(new Tool.PopUpThongBaoThanhCongCongTy("Đã gửi hợp đồng thành công"));
                    };
                    web.UploadValuesAsync(new Uri(Properties.Resources.URL + "sendContractCus"), "POST", web.QueryString);
                }
            }
            else if (lstNVDuocChon.Count > 0)
            {
                List<string> lstIdNV = new List<string>();
                string DSIdNhanVien = "";
                foreach (Class.HopDong.clsNhanVienDuocChon.Data nv in lstNVDuocChon)
                {
                    lstIdNV.Add(nv.IdNhanVien);
                }
                foreach (string str in lstIdNV)
                {
                    DSIdNhanVien = DSIdNhanVien + str + ",";
                }
                DSIdNhanVien = DSIdNhanVien.Remove(DSIdNhanVien.Length - 1);
                using (WebClient web = new WebClient())
                {
                    web.Headers.Add("Authorization", data.token);
                    web.QueryString.Add("contractId", IdHopDong);
                    web.QueryString.Add("internal_employee", DSIdNhanVien);
                    web.UploadValuesCompleted += (sender1, e1) =>
                    {
                        frmHopDongBan frm = new frmHopDongBan(frmMain, IdKhachHang, data, lstNhanVien, lstPhongBan, TenKH, EmailKH, SdtKH);
                        pnlHienThi.Children.Clear();
                        object content = frm.Content;
                        frm.Content = null;
                        pnlHienThi.Children.Add(content as UIElement);
                        frmMain.pnlShowPopup.Children.Add(new Tool.PopUpThongBaoThanhCongCongTy("Đã gửi hợp đồng thành công"));
                    };
                    web.UploadValuesAsync(new Uri(Properties.Resources.URL + "sendContractCus"), "POST", web.QueryString);
                }

            }
            else if (lstIdNV.Count > 0)
            {
                string DSIdNhanVien = "";
                foreach (string nv in lstIdNV)
                {
                    DSIdNhanVien = DSIdNhanVien + nv + ",";
                }
                DSIdNhanVien = DSIdNhanVien.Remove(DSIdNhanVien.Length - 1);
                using (WebClient web = new WebClient())
                {
                    web.Headers.Add("Authorization", data.token);
                    web.QueryString.Add("contractId", IdHopDong);
                    web.QueryString.Add("public_employee", DSIdNhanVien);
                    web.UploadValuesCompleted += (sender1, e1) =>
                    {
                        frmHopDongBan frm = new frmHopDongBan(frmMain, IdKhachHang, data, lstNhanVien, lstPhongBan, TenKH, EmailKH, SdtKH);
                        pnlHienThi.Children.Clear();
                        object content = frm.Content;
                        frm.Content = null;
                        pnlHienThi.Children.Add(content as UIElement);
                        frmMain.pnlShowPopup.Children.Add(new Tool.PopUpThongBaoThanhCongCongTy("Đã gửi hợp đồng thành công"));
                    };
                    web.UploadValuesAsync(new Uri(Properties.Resources.URL + "sendContractCus"), "POST", web.QueryString);
                }
            }
            
        }
        private List<string> lstNhanVienCT = new List<string>();
        private void textNhapEmailCongTy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                using (RestClient restclient = new RestClient(new Uri("https://chamcong.24hpay.vn/api_web_crm/list_employee_of_company_email.php")))
                {
                    RestRequest request = new RestRequest();
                    request.Method = Method.Post;
                    request.AlwaysMultipartFormData = true;
                    request.AddHeader("Authorization", data.token);
                    request.AddParameter("email", textNhapEmailCongTy.Text);
                    
                    RestResponse resAlbum = restclient.Execute(request);
                    var b = resAlbum.Content;
                    Class.clsNhanVienThuocCongTy.Root receivedInfo = JsonConvert.DeserializeObject<Class.clsNhanVienThuocCongTy.Root>(b);
                    if (receivedInfo.data != null)
                    {
                        foreach(var item in receivedInfo.data.user_info)
                        {
                            lstNhanVienCT.Add(item.ep_id + " - " + item.ep_name + " (" + item.ep_email + ")" + " - " + item.dep_name);
                        }
                        lsvNhanVienCT.ItemsSource = lstNhanVienCT;
                    }
                    
                }
            }
        }
        private List<string> lstIdNV = new List<string>();
        private void lsvNhanVienCT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lsvNhanVienCT.Visibility = Visibility.Collapsed;
            string Ten = lsvNhanVienCT.SelectedItem.ToString();
            test.Add(Ten);
            test = test.ToList();
            lsvDSNhanVienCT.ItemsSource = test;
            string[] Id = Ten.Split(Convert.ToChar("-"));
            string Id1 = Id[0];
            lstIdNV.Add(Id1);
        }

        private void btnXoaNV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string Ten = (sender as TextBlock).DataContext as string;
            test.Remove(Ten);
            test = test.ToList();
            lsvDSNhanVienCT.ItemsSource = test;
            string[] Id = Ten.Split(Convert.ToChar("-"));
            string Id1 = Id[0];
            lstIdNV.Remove(Id1);
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lsvNhanVienCT.Visibility == Visibility.Visible)
            {
                lsvNhanVienCT.Visibility = Visibility.Collapsed;
            }
            else
            {
                lsvNhanVienCT.Visibility = Visibility.Visible;
            }
        }

        
        private void Page_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lsvNhanVienCT.Visibility = Visibility.Collapsed;
            lsvPhongBan.Visibility = Visibility.Collapsed;
            lsvNhanVien.Visibility = Visibility.Collapsed;
            lsvChucVu.Visibility = Visibility.Collapsed;
        }
    }
}
