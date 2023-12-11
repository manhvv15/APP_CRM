using AppCRM.Views.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AppCRM.ViewsCongTy.HopDong.Popup
{
    /// <summary>
    /// Interaction logic for PopUpTruongMacDinh.xaml
    /// </summary>
    public partial class PopUpTruongMacDinh : UserControl
    {
        private ThemMoiHopDong frmThemMoi;
        public PopUpTruongMacDinh(ThemMoiHopDong frm)
        {
            InitializeComponent();
            frmThemMoi = frm;
            lsvTruongMacDinh.Items.Add("Chọn trường mặc định");
            lsvTruongMacDinh.Items.Add("@Tên công ty");
            lsvTruongMacDinh.Items.Add("@Địa chỉ");
            lsvTruongMacDinh.Items.Add("@Gmail");
            lsvTruongMacDinh.Items.Add("@Số điện thoại");
            lsvTruongMacDinh.Items.Add("@ngày");
            lsvTruongMacDinh.Items.Add("@tháng");
            lsvTruongMacDinh.Items.Add("@năm");
            lsvTruongMacDinh.Items.Add("@mã số thuế");
            lsvTruongMacDinh.Items.Add("@Tên chuyên viên");
            lsvTruongMacDinh.Items.Add("@Số điện thoại chuyên viên");
            lsvTruongMacDinh.Items.Add("@Email chuyên viên");
            lsvTruongMacDinh.Items.Add("@Ngân hàng nhận tiền");
            lsvTruongMacDinh.Items.Add("@Số tài khoản ngân hàng");
            lsvTruongMacDinh.Items.Add("@Chủ tài khoản");
        }
        private void borTruongMacDinh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (borDanhSachTruongMacDinh.Visibility == Visibility.Visible)
            {
                borDanhSachTruongMacDinh.Visibility = Visibility.Collapsed;
            }
            else
            {
                borDanhSachTruongMacDinh.Visibility = Visibility.Visible;
                btnHuy.IsEnabled = false;
            }
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btnHuy.IsEnabled = true;
            this.Visibility = Visibility.Collapsed;
        }
        public string TenTruong = "";
        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TenTruong = textTenTruongMD.Text;
            string MaTruong = "";
            MaTruong = "HDB-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "VN";
            string str = "";
            foreach (var item in frmThemMoi.lstTuTimKiem)
            {
                str = str + item + ",";
            }
            str = str.Remove(str.Length - 1);
            clsTruongThayDoi.Data cls = new clsTruongThayDoi.Data();
            cls.IdTruong = MaTruong;
            cls.TenTruong = textTenTruongMD.Text;
            cls.TuTK = frmThemMoi.TuTimKiem;
            cls.ViTriThayDoi = str;
            if (textTenTruongMD.Text == "@Tên công ty")
            {
                cls.TruongMacDinh = "1";
            }
            else if (textTenTruongMD.Text == "@Địa chỉ")
            {
                cls.TruongMacDinh = "2";
            }
            else if (textTenTruongMD.Text == "@Gmail")
            {
                cls.TruongMacDinh = "3";
            }
            else if (textTenTruongMD.Text == "Số điện thoại")
            {
                cls.TruongMacDinh = "4";
            }
            else if (textTenTruongMD.Text == "@ngày")
            {
                cls.TruongMacDinh = "5";
            }
            else if (textTenTruongMD.Text == "@tháng")
            {
                cls.TruongMacDinh = "6";
            }
            else if (textTenTruongMD.Text == "@năm")
            {
                cls.TruongMacDinh = "7";
            }
            else if (textTenTruongMD.Text == "@mã số thuế")
            {
                cls.TruongMacDinh = "8";
            }
            else if (textTenTruongMD.Text == "@Tên chuyên viên")
            {
                cls.TruongMacDinh = "9";
            }
            else if (textTenTruongMD.Text == "@Số điện thoại chuyện viên")
            {
                cls.TruongMacDinh = "10";
            }
            else if (textTenTruongMD.Text == "@Email chuyên viên")
            {
                cls.TruongMacDinh = "11";
            }
            else if (textTenTruongMD.Text == "@Ngân hàng nhận tiền")
            {
                cls.TruongMacDinh = "12";
            }
            else if (textTenTruongMD.Text == "@Số tài khoản ngân hàng")
            {
                cls.TruongMacDinh = "13";
            }
            else if (textTenTruongMD.Text == "@Chủ tài khoản")
            {
                cls.TruongMacDinh = "14";
            }
            frmThemMoi.lstTruongThayDoi.Add(cls);
            frmThemMoi.lstTruongThayDoi = frmThemMoi.lstTruongThayDoi.ToList();
            frmThemMoi.lsvTruongThayDoi.ItemsSource = frmThemMoi.lstTruongThayDoi;
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void lsvTruongMacDinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            borDanhSachTruongMacDinh.Visibility = Visibility.Collapsed;
            textTenTruongMD.Text = lsvTruongMacDinh.SelectedItem.ToString();

        }
    }
}
