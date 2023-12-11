using AppCRM.Views.ChamSocKhachHang.TongDai;
using AppCRM.Views.HopDong;
using AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppCRM
{
    public class clsBien:INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public static List<string> listPhongBan = new List<string>();
        public static List<string> listIDPhongBan = new List<string>();
        public static List<string> listNhanVien = new List<string>();
        public static ObservableCollection<string> listIDNhanVien = new ObservableCollection<string>();
        public static List<string> listTinhTrang = new List<string>();
        public static List<string> listIdTinhTrang = new List<string>();
        public static List<object> listMangXaHoi = new List<object>();
        public static List<string> listIDMangXaHoi = new List<string>();
        public static List<object> listSDT = new List<object>();
        public static List<object> listFile = new List<object>();
        public static List<clsHopDong.Datum> lstHopDong = new List<clsHopDong.Datum>();
        public static List<clsSoLine.Datum> lstSoLine = new List<clsSoLine.Datum>();
        public static List<clsGhiChu.Datum> lstGhiChu = new List<clsGhiChu.Datum>();
        private static List<object> _lstNhanVienThuocCongTy = new List<object>();
        public static string TongSoHopDong = "";
        public static string TrangThaiTongDai = "";
        //public static Views.KhachHang.NhomKhachHang.frmNhomKhachHang frmNhomKH;
        public static string Gio1 = "";
        public static string Phut1 = "";
        public static string Gio2 = "";
        public static string Phut2 = "";
        public static string DateTuNgay = "";
        public static string DateDenNgay = "";
        public static string NguonKH = "";
        public static string NhomKhCha = "";
        public static string GhimNhomKHCha = "";
        public static string NhomKHCon = "";
        public static string NhanVienPT = "";
        public static string NhanVienTao = "";
        public static string TimKiem = "";
        public static string Trang = "";
        public static string DuLieuToiDa = "";
        public static string TongSoTrang = "";
        public static bool DanhSachKH = false;

        public static List<object> lstNhanVienThuocCongTy { get => _lstNhanVienThuocCongTy; set =>_lstNhanVienThuocCongTy = value; }
        public static string IdCongTy = "";
        public static List<Class.clsNhanVienThuocPhongBan> lstNhanVienPB = new List<Class.clsNhanVienThuocPhongBan>();
        //public List<int> ListPageNumber(int total)
        //{
        //    int Pages = total / 20;
        //    if (total % 20 > 0) Pages++;
        //    List<int> pnb = new List<int>();
        //    for (int i = 1; i <= Pages; i++)
        //    {
        //        pnb.Add(i);
        //    }
        //    return pnb;
        //}


        //public List<int> PageNVCacNhom
        //{
        //    get { return _PageNVCacNhom; }
        //    set { _PageNVCacNhom = value; OnPropertyChanged(); }
        //}

        //private int pagenow;

        //private void loadPage(int pagenb, List<int> loaiPage)
        //{
        //    BrushConverter bc = new BrushConverter();
        //    pagenow = pagenb;
        //    if (pagenb == 1)
        //    {
        //        Page1.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //        Page2.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        Page3.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        txtpage1.Text = "1";
        //        txtpage1.Foreground = (Brush)bc.ConvertFrom("#ffffff");
        //        txtpage2.Foreground = (Brush)bc.ConvertFrom("#444");
        //        txtpage3.Foreground = (Brush)bc.ConvertFrom("#444");
        //        PageTruoc.Visibility = Visibility.Collapsed;
        //        PageDau.Visibility = Visibility.Collapsed;
        //        Page1.Visibility = Visibility.Visible;
        //        if (loaiPage.Count > 3)
        //        {
        //            PageCuoi.Visibility = Visibility.Visible;
        //            txtpage3.Text = "3";
        //            txtpage2.Text = "2";
        //            PageTiep.Visibility = Visibility.Visible;
        //            Page3.Visibility = Visibility.Visible;
        //            Page2.Visibility = Visibility.Visible;
        //            Page1.Visibility = Visibility.Visible;
        //        }
        //        else if (loaiPage.Count > 2)
        //        {
        //            txtpage3.Text = "3";
        //            txtpage2.Text = "2";
        //            PageTiep.Visibility = Visibility.Visible;
        //            Page3.Visibility = Visibility.Visible;
        //            Page2.Visibility = Visibility.Visible;
        //            Page1.Visibility = Visibility.Visible;
        //        }
        //        else if (loaiPage.Count > 1)
        //        {
        //            Page3.Visibility = Visibility.Collapsed;
        //            PageTiep.Visibility = Visibility.Visible;
        //            txtpage2.Text = "2";
        //            Page2.Visibility = Visibility.Visible;
        //            PageCuoi.Visibility = Visibility.Collapsed;
        //        }
        //        else
        //        {
        //            PageTiep.Visibility = Visibility.Collapsed;
        //            Page3.Visibility = Visibility.Collapsed;
        //            PageCuoi.Visibility = Visibility.Collapsed;
        //            Page2.Visibility = Visibility.Collapsed;
        //        }
        //    }
        //    else if (pagenb == loaiPage.Count)
        //    {
        //        Page3.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //        Page2.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        Page1.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        txtpage3.Text = pagenb + "";
        //        txtpage3.Foreground = (Brush)bc.ConvertFrom("#ffffff");
        //        txtpage2.Foreground = (Brush)bc.ConvertFrom("#444");
        //        txtpage1.Foreground = (Brush)bc.ConvertFrom("#444");
        //        Page3.Visibility = Visibility.Visible;
        //        PageTiep.Visibility = Visibility.Collapsed;
        //        PageCuoi.Visibility = Visibility.Collapsed;
        //        if (loaiPage.Count > 3)
        //        {
        //            txtpage2.Text = (pagenb - 1) + "";
        //            txtpage1.Text = (pagenb - 2) + "";
        //            Page2.Visibility = Visibility.Visible;
        //            PageDau.Visibility = Visibility.Visible;
        //            PageTruoc.Visibility = Visibility.Visible;
        //            Page1.Visibility = Visibility.Visible;
        //        }
        //        else if (loaiPage.Count > 2)
        //        {
        //            txtpage2.Text = "2";
        //            txtpage1.Text = "1";
        //            Page2.Visibility = Visibility.Visible;
        //            PageTruoc.Visibility = Visibility.Visible;
        //            Page1.Visibility = Visibility.Visible;
        //            PageDau.Visibility = Visibility.Collapsed;

        //        }
        //        else if (loaiPage.Count > 1)
        //        {
        //            Page1.Visibility = Visibility.Collapsed;
        //            txtpage2.Text = "1";
        //            Page2.Visibility = Visibility.Visible;
        //            PageTruoc.Visibility = Visibility.Visible;
        //            PageDau.Visibility = Visibility.Collapsed;
        //        }
        //    }
        //    else if (pagenb == loaiPage.Count - 1)
        //    {
        //        Page2.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //        Page3.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        Page1.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        txtpage2.Text = pagenb + "";
        //        txtpage2.Foreground = (Brush)bc.ConvertFrom("#ffffff");
        //        txtpage2.Foreground = (Brush)bc.ConvertFrom("#444");
        //        txtpage2.Foreground = (Brush)bc.ConvertFrom("#444");
        //        Page2.Visibility = Visibility.Visible;
        //        PageTiep.Visibility = Visibility.Visible;
        //        PageCuoi.Visibility = Visibility.Collapsed;
        //        PageTruoc.Visibility = Visibility.Visible;
        //        Page3.Visibility = Visibility.Visible;
        //        Page1.Visibility = Visibility.Visible;
        //        txtpage3.Text = (pagenb + 1) + "";
        //        txtpage1.Text = (pagenb - 1) + "";
        //        if (loaiPage.Count > 3) PageDau.Visibility = Visibility.Visible;
        //        else PageDau.Visibility = Visibility.Collapsed;
        //    }
        //    else if (pagenb == 2)
        //    {
        //        Page2.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //        Page3.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        Page1.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        txtpage2.Text = "2";
        //        txtpage2.Foreground = (Brush)bc.ConvertFrom("#ffffff");
        //        txtpage3.Foreground = (Brush)bc.ConvertFrom("#444");
        //        txtpage1.Foreground = (Brush)bc.ConvertFrom("#444");
        //        txtpage1.Text = "1";
        //        txtpage3.Text = "3";
        //        PageTruoc.Visibility = Visibility.Visible;
        //        PageDau.Visibility = Visibility.Collapsed;
        //        Page1.Visibility = Visibility.Visible;
        //        Page2.Visibility = Visibility.Visible;
        //        Page3.Visibility = Visibility.Visible;
        //        PageTiep.Visibility = Visibility.Visible;
        //        if (loaiPage.Count > 3) PageCuoi.Visibility = Visibility.Visible;
        //        else PageCuoi.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        Page2.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //        Page3.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        Page1.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //        txtpage2.Text = pagenb + "";
        //        txtpage2.Foreground = (Brush)bc.ConvertFrom("#ffffff");
        //        txtpage3.Foreground = (Brush)bc.ConvertFrom("#444");
        //        txtpage1.Foreground = (Brush)bc.ConvertFrom("#444");
        //        txtpage1.Text = (pagenb - 1) + "";
        //        txtpage3.Text = (pagenb + 1) + "";
        //        PageTruoc.Visibility = Visibility.Visible;
        //        PageDau.Visibility = Visibility.Visible;
        //        PageCuoi.Visibility = Visibility.Visible;
        //        Page1.Visibility = Visibility.Visible;
        //        Page2.Visibility = Visibility.Visible;
        //        Page3.Visibility = Visibility.Visible;
        //        PageTiep.Visibility = Visibility.Visible;
        //    }
        //}
        //private void ve_page_1(object sender, MouseButtonEventArgs e)
        //{
        //    string time = DateTime.Now.ToString("MM");
        //    if (selectDate.SelectedDate != null)
        //        time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
        //    string id_phong = "";
        //    if (cbPhong.SelectedIndex > -1)
        //    {
        //        Item_dep pb = (Item_dep)cbPhong.SelectedItem;
        //        if (pb.dep_id != "-1")
        //            id_phong = pb.dep_id;
        //    }
        //    string id_user = "";
        //    if (cbNV.SelectedIndex > -1)
        //    {
        //        ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
        //        if (nv.ep_id != "-1")
        //            id_user = nv.ep_id;
        //    }
        //    getData(time, id_phong, id_user, 1);
        //    BrushConverter bc = new BrushConverter();
        //    Page1.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //    Page2.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //    Page3.Background = (Brush)bc.ConvertFrom("#FFFFFF");
        //    txtpage1.Text = "1";
        //    txtpage1.Foreground = (Brush)bc.ConvertFrom("#ffffff");
        //    txtpage2.Foreground = (Brush)bc.ConvertFrom("#444");
        //    txtpage3.Foreground = (Brush)bc.ConvertFrom("#444");
        //}

        //private void page_truoc_click(object sender, MouseButtonEventArgs e)
        //{
        //    string time = DateTime.Now.ToString("MM");
        //    if (selectDate.SelectedDate != null)
        //        time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
        //    string id_phong = "";
        //    if (cbPhong.SelectedIndex > -1)
        //    {
        //        Item_dep pb = (Item_dep)cbPhong.SelectedItem;
        //        if (pb.dep_id != "-1")
        //            id_phong = pb.dep_id;
        //    }
        //    string id_user = "";
        //    if (cbNV.SelectedIndex > -1)
        //    {
        //        ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
        //        if (nv.ep_id != "-1")
        //            id_user = nv.ep_id;
        //    }
        //    getData(time, id_phong, id_user, pagenow - 1);
        //}

        //private void page_sau_click(object sender, MouseButtonEventArgs e)
        //{
        //    string time = DateTime.Now.ToString("MM");
        //    if (selectDate.SelectedDate != null)
        //        time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
        //    string id_phong = "";
        //    if (cbPhong.SelectedIndex > -1)
        //    {
        //        Item_dep pb = (Item_dep)cbPhong.SelectedItem;
        //        if (pb.dep_id != "-1")
        //            id_phong = pb.dep_id;
        //    }
        //    string id_user = "";
        //    if (cbNV.SelectedIndex > -1)
        //    {
        //        ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
        //        if (nv.ep_id != "-1")
        //            id_user = nv.ep_id;
        //    }
        //    getData(time, id_phong, id_user, pagenow + 1);
        //}

        //private void page_cuoi_click(object sender, MouseButtonEventArgs e)
        //{
        //    string time = DateTime.Now.ToString("MM");
        //    if (selectDate.SelectedDate != null)
        //        time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
        //    string id_phong = "";
        //    if (cbPhong.SelectedIndex > -1)
        //    {
        //        Item_dep pb = (Item_dep)cbPhong.SelectedItem;
        //        if (pb.dep_id != "-1")
        //            id_phong = pb.dep_id;
        //    }
        //    string id_user = "";
        //    if (cbNV.SelectedIndex > -1)
        //    {
        //        ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
        //        if (nv.ep_id != "-1")
        //            id_user = nv.ep_id;
        //    }
        //    getData(time, id_phong, id_user, PageNVCacNhom.Count);
        //}
        //private void select_page_click1(object sender, MouseButtonEventArgs e)
        //{
        //    System.Windows.Controls.Border b = sender as System.Windows.Controls.Border;
        //    int pagenumber = int.Parse(txtpage1.Text);
        //    string time = DateTime.Now.ToString("MM");
        //    if (selectDate.SelectedDate != null)
        //        time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
        //    string id_phong = "";
        //    if (cbPhong.SelectedIndex > -1)
        //    {
        //        Item_dep pb = (Item_dep)cbPhong.SelectedItem;
        //        if (pb.dep_id != "-1")
        //            id_phong = pb.dep_id;
        //    }
        //    string id_user = "";
        //    if (cbNV.SelectedIndex > -1)
        //    {
        //        ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
        //        if (nv.ep_id != "-1")
        //            id_user = nv.ep_id;
        //    }
        //    getData(time, id_phong, id_user, pagenumber);
        //    // b.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //}

        //private void select_page_click2(object sender, MouseButtonEventArgs e)
        //{
        //    System.Windows.Controls.Border b = sender as System.Windows.Controls.Border;
        //    int pagenumber = int.Parse(txtpage2.Text);
        //    string time = DateTime.Now.ToString("MM");
        //    if (selectDate.SelectedDate != null)
        //        time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
        //    string id_phong = "";
        //    if (cbPhong.SelectedIndex > -1)
        //    {
        //        Item_dep pb = (Item_dep)cbPhong.SelectedItem;
        //        if (pb.dep_id != "-1")
        //            id_phong = pb.dep_id;
        //    }
        //    string id_user = "";
        //    if (cbNV.SelectedIndex > -1)
        //    {
        //        ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
        //        if (nv.ep_id != "-1")
        //            id_user = nv.ep_id;
        //    }
        //    getData(time, id_phong, id_user, pagenumber);
        //    // b.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //}

        //private void select_page_click3(object sender, MouseButtonEventArgs e)
        //{
        //    System.Windows.Controls.Border b = sender as System.Windows.Controls.Border;
        //    int pagenumber = int.Parse(txtpage3.Text);
        //    string time = DateTime.Now.ToString("MM");
        //    if (selectDate.SelectedDate != null)
        //        time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
        //    string id_phong = "";
        //    if (cbPhong.SelectedIndex > -1)
        //    {
        //        Item_dep pb = (Item_dep)cbPhong.SelectedItem;
        //        if (pb.dep_id != "-1")
        //            id_phong = pb.dep_id;
        //    }
        //    string id_user = "";
        //    if (cbNV.SelectedIndex > -1)
        //    {
        //        ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
        //        if (nv.ep_id != "-1")
        //            id_user = nv.ep_id;
        //    }
        //    getData(time, id_phong, id_user, pagenumber);
        //    // b.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        //}
        //private static int totalNVCacNhom;
        //private void getData(string time, string dep, string user, int page)
        //{
        //    using (WebClient web = new WebClient())
        //    {
        //        web.QueryString.Add("token", Main.CurrentCompany.token);
        //        web.QueryString.Add("id_comp", Main.CurrentCompany.com_id);
        //        web.QueryString.Add("page", page + "");
        //        web.QueryString.Add("time", time);
        //        web.QueryString.Add("id_dep", dep);
        //        web.QueryString.Add("id_emp", user);
        //        web.UploadValuesCompleted += (s, e) =>
        //        {
        //            try
        //            {
        //                API_Tbl_Salary_Manager api = JsonConvert.DeserializeObject<API_Tbl_Salary_Manager>(UnicodeEncoding.UTF8.GetString(e.Result));
        //                if (api.data != null)
        //                {
        //                    listNhanVien = api.data.list_emp;
        //                    totalNVCacNhom = api.data.total_item;
        //                    PageNVCacNhom = ListPageNumber(totalNVCacNhom);
        //                    loadPage(page, PageNVCacNhom);
        //                }
        //                foreach (ItemEmp item in listNhanVien)
        //                {
        //                    if (item.ep_image == "")
        //                    {
        //                        item.ep_image = "https://tinhluong.timviec365.vn/img/add.png";
        //                    }
        //                    else
        //                        item.ep_image = "https://chamcong.24hpay.vn/upload/employee/" + item.ep_image;
        //                }
        //            }
        //            catch { }
        //        };
        //        web.UploadValuesTaskAsync("https://tinhluong.timviec365.vn/api_app/company/tbl_salary_manager.php", web.QueryString);
        //    }
        //}

    }
}
