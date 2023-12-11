using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace AppCRM
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Test()
        {
            InitializeComponent();
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnHienThiMenu_Click(object sender, RoutedEventArgs e)
        {
            //if (pnlMenuDoc.Visibility == Visibility.Collapsed)
            //{
            //    pnlMenuDoc.Visibility = Visibility.Visible;
            //    pnlIconMenuDoc.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    pnlMenuDoc.Visibility = Visibility.Collapsed;
            //    pnlIconMenuDoc.Visibility = Visibility.Visible;
            //}
        }
        private void btnTrangChu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //frmTrangChu2 frm = new frmTrangChu2();
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnTest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.TinhTrangKhachHang.frmTinhTrangKhachHang frm = new Views.KhachHang.TinhTrangKhachHang.frmTinhTrangKhachHang();
            //pnlHienThi2.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi2.Children.Add(content as UIElement);
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

        private void btnDSNKH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.NhomKhachHang.frmNhomKhachHang frm = new Views.KhachHang.NhomKhachHang.frmNhomKhachHang();
            //pnlHienThi2.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi2.Children.Add(content as UIElement);
        }
        private void btnMatKhau_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnMatKhau.Foreground = Brushes.White;
        }
        private void menuKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (pnlMenuKhachHangCon.Visibility == Visibility.Collapsed)
            //{
            //    pnlMenuKhachHangCon.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    pnlMenuKhachHangCon.Visibility = Visibility.Collapsed;
            //}
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

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

        private void btnDanhSachKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.DanhSachKhachHang.frmCustomer frm = new Views.KhachHang.DanhSachKhachHang.frmCustomer();
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnNhomKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.NhomKhachHang.frmNhomKhachHang frm = new Views.KhachHang.NhomKhachHang.frmNhomKhachHang();
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnTinhTrangKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Views.KhachHang.TinhTrangKhachHang.frmTinhTrangKhachHang frm = new Views.KhachHang.TinhTrangKhachHang.frmTinhTrangKhachHang();
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnTrangChu_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //frmTrangChu2 frm = new frmTrangChu2();
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
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
            //frmTrangChu2 frm = new frmTrangChu2();
            //pnlHienThi.Children.Clear();
            //object content = frm.Content;
            //frm.Content = null;
            //frm.Close();
            //pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnThuGonMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //pnlMenuDoc.Visibility = Visibility.Collapsed;
            //pnlIconTrangChu.Visibility = Visibility.Visible;
            //pnlIconPhanQuyen.Visibility = Visibility.Visible;
            //pnlIconTiemNang.Visibility = Visibility.Visible;
            //pnlIconKhachHang.Visibility = Visibility.Visible;
            //btnHienThiMenu.Visibility = Visibility.Visible;
            //btnThuGonMenu.Visibility = Visibility.Collapsed;
            
        }

        private void btnHienThiMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //pnlMenuDoc.Visibility = Visibility.Visible;
            //pnlIconTrangChu.Visibility = Visibility.Collapsed;
            //pnlIconPhanQuyen.Visibility = Visibility.Collapsed;
            //pnlIconTiemNang.Visibility = Visibility.Collapsed;
            //pnlIconKhachHang.Visibility = Visibility.Collapsed;
            //btnHienThiMenu.Visibility = Visibility.Collapsed;
            //btnThuGonMenu.Visibility = Visibility.Visible;
            
        }
        //public static string DuongDan = "";
        public static Views.KhachHang.NhomKhachHang.frmNhomKhachHang frmNhomKH;
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

        //private List<int> _PageNVCacNhom;

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
        private void ve_page_1(object sender, MouseButtonEventArgs e)
        {
            //string time = DateTime.Now.ToString("MM");
            //if (selectDate.SelectedDate != null)
            //    time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //string id_phong = "";
            //if (cbPhong.SelectedIndex > -1)
            //{
            //    Item_dep pb = (Item_dep)cbPhong.SelectedItem;
            //    if (pb.dep_id != "-1")
            //        id_phong = pb.dep_id;
            //}
            //string id_user = "";
            //if (cbNV.SelectedIndex > -1)
            //{
            //    ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
            //    if (nv.ep_id != "-1")
            //        id_user = nv.ep_id;
            //}
            //getData(time, id_phong, id_user, 1);
            //BrushConverter bc = new BrushConverter();
            //Page1.Background = (Brush)bc.ConvertFrom("#4C5BD4");
            //Page2.Background = (Brush)bc.ConvertFrom("#FFFFFF");
            //Page3.Background = (Brush)bc.ConvertFrom("#FFFFFF");
            //txtpage1.Text = "1";
            //txtpage1.Foreground = (Brush)bc.ConvertFrom("#ffffff");
            //txtpage2.Foreground = (Brush)bc.ConvertFrom("#444");
            //txtpage3.Foreground = (Brush)bc.ConvertFrom("#444");
        }
        private void page_truoc_click(object sender, MouseButtonEventArgs e)
        {
            //string time = DateTime.Now.ToString("MM");
            //if (selectDate.SelectedDate != null)
            //    time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //string id_phong = "";
            //if (cbPhong.SelectedIndex > -1)
            //{
            //    Item_dep pb = (Item_dep)cbPhong.SelectedItem;
            //    if (pb.dep_id != "-1")
            //        id_phong = pb.dep_id;
            //}
            //string id_user = "";
            //if (cbNV.SelectedIndex > -1)
            //{
            //    ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
            //    if (nv.ep_id != "-1")
            //        id_user = nv.ep_id;
            //}
            //getData(time, id_phong, id_user, pagenow - 1);
        }
        private void page_sau_click(object sender, MouseButtonEventArgs e)
        {
            //string time = DateTime.Now.ToString("MM");
            //if (selectDate.SelectedDate != null)
            //    time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //string id_phong = "";
            //if (cbPhong.SelectedIndex > -1)
            //{
            //    Item_dep pb = (Item_dep)cbPhong.SelectedItem;
            //    if (pb.dep_id != "-1")
            //        id_phong = pb.dep_id;
            //}
            //string id_user = "";
            //if (cbNV.SelectedIndex > -1)
            //{
            //    ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
            //    if (nv.ep_id != "-1")
            //        id_user = nv.ep_id;
            //}
            //getData(time, id_phong, id_user, pagenow + 1);
        }
        private void page_cuoi_click(object sender, MouseButtonEventArgs e)
        {
            //string time = DateTime.Now.ToString("MM");
            //if (selectDate.SelectedDate != null)
            //    time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //string id_phong = "";
            //if (cbPhong.SelectedIndex > -1)
            //{
            //    Item_dep pb = (Item_dep)cbPhong.SelectedItem;
            //    if (pb.dep_id != "-1")
            //        id_phong = pb.dep_id;
            //}
            //string id_user = "";
            //if (cbNV.SelectedIndex > -1)
            //{
            //    ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
            //    if (nv.ep_id != "-1")
            //        id_user = nv.ep_id;
            //}
            //getData(time, id_phong, id_user, PageNVCacNhom.Count);
        }
        private void select_page_click1(object sender, MouseButtonEventArgs e)
        {
            //System.Windows.Controls.Border b = sender as System.Windows.Controls.Border;
            //int pagenumber = int.Parse(txtpage1.Text);
            //string time = DateTime.Now.ToString("MM");
            //if (selectDate.SelectedDate != null)
            //    time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //string id_phong = "";
            //if (cbPhong.SelectedIndex > -1)
            //{
            //    Item_dep pb = (Item_dep)cbPhong.SelectedItem;
            //    if (pb.dep_id != "-1")
            //        id_phong = pb.dep_id;
            //}
            //string id_user = "";
            //if (cbNV.SelectedIndex > -1)
            //{
            //    ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
            //    if (nv.ep_id != "-1")
            //        id_user = nv.ep_id;
            //}
            //getData(time, id_phong, id_user, pagenumber);
            // b.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        }
        private void select_page_click2(object sender, MouseButtonEventArgs e)
        {
            //System.Windows.Controls.Border b = sender as System.Windows.Controls.Border;
            //int pagenumber = int.Parse(txtpage2.Text);
            //string time = DateTime.Now.ToString("MM");
            //if (selectDate.SelectedDate != null)
            //    time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //string id_phong = "";
            //if (cbPhong.SelectedIndex > -1)
            //{
            //    Item_dep pb = (Item_dep)cbPhong.SelectedItem;
            //    if (pb.dep_id != "-1")
            //        id_phong = pb.dep_id;
            //}
            //string id_user = "";
            //if (cbNV.SelectedIndex > -1)
            //{
            //    ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
            //    if (nv.ep_id != "-1")
            //        id_user = nv.ep_id;
            //}
            //getData(time, id_phong, id_user, pagenumber);
            //// b.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        }
        private void select_page_click3(object sender, MouseButtonEventArgs e)
        {
            //System.Windows.Controls.Border b = sender as System.Windows.Controls.Border;
            //int pagenumber = int.Parse(txtpage3.Text);
            //string time = DateTime.Now.ToString("MM");
            //if (selectDate.SelectedDate != null)
            //    time = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //string id_phong = "";
            //if (cbPhong.SelectedIndex > -1)
            //{
            //    Item_dep pb = (Item_dep)cbPhong.SelectedItem;
            //    if (pb.dep_id != "-1")
            //        id_phong = pb.dep_id;
            //}
            //string id_user = "";
            //if (cbNV.SelectedIndex > -1)
            //{
            //    ListEmployee nv = (ListEmployee)cbNV.SelectedItem;
            //    if (nv.ep_id != "-1")
            //        id_user = nv.ep_id;
            //}
            //getData(time, id_phong, id_user, pagenumber);
            //// b.Background = (Brush)bc.ConvertFrom("#4C5BD4");
        }
        private static int totalNVCacNhom;
        private void getData(string time, string dep, string user, int page)
        {
            //using (WebClient web = new WebClient())
            //{
            //    web.QueryString.Add("token", Main.CurrentCompany.token);
            //    web.QueryString.Add("id_comp", Main.CurrentCompany.com_id);
            //    web.QueryString.Add("page", page + "");
            //    web.QueryString.Add("time", time);
            //    web.QueryString.Add("id_dep", dep);
            //    web.QueryString.Add("id_emp", user);
            //    web.UploadValuesCompleted += (s, e) =>
            //    {
            //        try
            //        {
            //            API_Tbl_Salary_Manager api = JsonConvert.DeserializeObject<API_Tbl_Salary_Manager>(UnicodeEncoding.UTF8.GetString(e.Result));
            //            if (api.data != null)
            //            {
            //                listNhanVien = api.data.list_emp;
            //                totalNVCacNhom = api.data.total_item;
            //                PageNVCacNhom = ListPageNumber(totalNVCacNhom);
            //                loadPage(page, PageNVCacNhom);
            //            }
                        
            //        }
            //        catch { }
            //    };
            //    web.UploadValuesTaskAsync("https://tinhluong.timviec365.vn/api_app/company/tbl_salary_manager.php", web.QueryString);
            //}
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //popup.Visibility = Visibility.Collapsed;
        }

        private void TextBox_DragLeave(object sender, DragEventArgs e)
        {
            //MessageBox.Show("ok");
        }

        

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show("okok");
        }

        
    }
}
