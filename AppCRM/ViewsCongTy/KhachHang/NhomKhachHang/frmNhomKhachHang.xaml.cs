using AppCRM.Model.APIEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
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

namespace AppCRM.Views.KhachHang.NhomKhachHang
{
    /// <summary>
    /// Interaction logic for frmNhomKhachHang.xaml
    /// </summary>
    public partial class frmNhomKhachHang : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DataLogin_Company _dt = new DataLogin_Company();
        private List<Item> lstPhongBan = new List<Item>();
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        private frmTrangChuSauDangNhapCongTy frmMain;
        public frmNhomKhachHang(DataLogin_Company data,frmTrangChuSauDangNhapCongTy frm)
        {
            InitializeComponent();
            frmMain = frm;
            this.DataContext = this;
            frmMain.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            //DataCompany = data;
            _dt = data;
            LoadDataNhomKH(data);
            LoadDataPhongBan();
            LoadDataNhanVien();
        }
        private List<clsNhomKhachHang> _ListCustomer = new List<clsNhomKhachHang>();
        public List<clsNhomKhachHang> ListCustomer { get => _ListCustomer; set { _ListCustomer = value; OnPropertyChanged("ListCustomer"); } }

        public void LoadDataNhomKH(Model.APIEntity.DataLogin_Company data)
        {
            try
            {
                dgv.Items.Clear();
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listGroupCustomer";
                    httpClient.DefaultRequestHeaders.Add("Authorization",data.token);
                    var kq = httpClient.GetAsync(url);
                    RootCustomer api = JsonConvert.DeserializeObject<RootCustomer>(kq.Result.Content.ReadAsStringAsync().Result);
                    if(api != null)
                    {
                        foreach (var item in api.data)
                        {
                            ListCustomer.Add(item);
                            //dgv.ItemsSource = ListCustomer;
                            dgv.Items.Add(item);
                            //cbo.Items.Add(item.gr_id);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var check = ex.Message;
            }
            
        }
        
        private void btnThemNhomKH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemMoiNhomKhachHang frm = new frmThemMoiNhomKhachHang(_dt, "Thêm mới nhóm khách hàng", frmMain);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
            //frmThemMoiNhomKhachHang frm = new frmThemMoiNhomKhachHang(DataCompany);
            //frm.ShowDialog();
        }

        private void btnXoa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            
            clsNhomKhachHang item = (sender as DockPanel).DataContext as clsNhomKhachHang;
            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", _dt.token);
                httpClient.QueryString.Add("grId", item.gr_id);
                var api = httpClient.UploadValues(new Uri(Properties.Resources.URL + "deleteGroupCustomer"), "POST", httpClient.QueryString);
                
            }
            ListCustomer.Remove(item);
            ListCustomer = ListCustomer.ToList();
            dgv.Items.Remove(item);
        }
        string MaNhom = "";
        string TenNhomKH = "";
        string MoTa = "";
        string NhomCha = "";

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    clsNhomKhachHang cls = (clsNhomKhachHang)dgv.SelectedItem;
            //    if (cls != null)
            //    {
            //        MaNhom = cls.gr_id;
            //        TenNhomKH = cls.gr_name;
            //        MoTa = cls.gr_description;
            //        NhomCha = cls.group_parent;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    var check = ex.Message;
            //}


        }

        private void btnSua_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsNhomKhachHang dataKHCha = (sender as DockPanel).DataContext as clsNhomKhachHang;
            frmThemMoiNhomKhachHang frm = new frmThemMoiNhomKhachHang(_dt, dataKHCha.gr_id, dataKHCha.gr_name, dataKHCha.gr_description, dataKHCha.group_parent, "Chỉnh sửa nhóm khách hàng", dataKHCha);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            
        }

        private void textTenNhomKH_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            try
            {
                clsNhomKhachHang item = (sender as TextBlock).DataContext as clsNhomKhachHang;
                if (item.lists_child.Count > 0)
                {
                    item.isClick = item.isClick == 0 ? 1 : 0;
                    if (item.isClick == 1)
                    {
                        int index = dgv.Items.IndexOf(item);
                        foreach (ListsChildCustomer child in item.lists_child)
                        {
                            dgv.Items.Insert(index + 1, child);
                        }
                    }
                    else if (item.isClick == 0)
                    {
                        foreach (var itemChild in item.lists_child)
                        {
                            dgv.Items.Remove(itemChild);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cha");
                }



            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }

        private void dgv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListsChildCustomer cls = (ListsChildCustomer)dgv.SelectedItem;
                if (cls != null)
                {
                    MaNhom = cls.gr_id;
                    TenNhomKH = cls.gr_name;
                    MoTa = cls.gr_description;
                    NhomCha = cls.group_parent;
                    frmChinhSuaNhomKhachHangCon frm = new frmChinhSuaNhomKhachHangCon(_dt, MaNhom, TenNhomKH, MoTa, NhomCha);
                    pnlHienThi.Children.Clear();
                    object content = frm.Content;
                    frm.Content = null;
                    //frm.Close();
                    pnlHienThi.Children.Add(content as UIElement);
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        public List<clsNhomKhachHang> lstSearch = new List<clsNhomKhachHang>();
        private void btnTimKiem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            lstSearch.Clear();

            if (TbsearchHD.Text.Equals(""))
            {
                lstSearch.AddRange(ListCustomer);
            }
            else
            {
                foreach (clsNhomKhachHang anim in ListCustomer)
                {

                    if (anim.gr_name.Contains(TbsearchHD.Text))
                    {
                        lstSearch.Add(anim);
                    }
                }
            }

            dgv.ItemsSource = lstSearch.ToList();
        }
        public void LoadDataPhongBan(/*Model.APIEntity.DataLogin_Company data*/)
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
                    Root api = JsonConvert.DeserializeObject<Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            lstPhongBan.Add(item);
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
        public void LoadDataNhanVien(/*Model.APIEntity.DataLogin_Company data*/)
        {
            try
            {
                //cbx.Items.Clear();
                using (WebClient webClient = new WebClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://chamcong.24hpay.vn/service/list_all_employee_of_company.php";
                    webClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = webClient.UploadValues(new Uri(url), webClient.QueryString);
                    clsNhanVien.Root api = JsonConvert.DeserializeObject<clsNhanVien.Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            lstNhanVien.Add(item);
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
        private void pnlDanhSachDoiTuong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            List<string> lstIdPhongBan = new List<string>();
            List<string> lstTenNhanVien = new List<string>();
            List<clsNhanVien.Item> oopNV = new List<clsNhanVien.Item>();
            clsNhomKhachHang cls = (clsNhomKhachHang)dgv.SelectedItem;
            if (cls != null)
            {
                string[] danhsachidphong = cls.dep_id.Split(Convert.ToChar(","));
                string[] danhsachidnhanvien = cls.emp_id.Split(Convert.ToChar(","));
                foreach (string idphong in danhsachidphong)
                {
                    lstIdPhongBan.Add(idphong);
                    
                }
                foreach (string idnhanvien in danhsachidnhanvien)
                {
                    foreach (clsNhanVien.Item it in lstNhanVien)
                    {
                        if (it.ep_id == idnhanvien)
                        {
                            lstTenNhanVien.Add(it.ep_name);
                            oopNV.Add(it);
                        }

                    }
                }
            }
            frmDanhSachDoiTuongChiaSe frm = new frmDanhSachDoiTuongChiaSe(lstIdPhongBan,lstPhongBan, oopNV);
            frm.ShowDialog();
        }

        private void btnDau_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnPage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnPage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnPage3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnCuoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
