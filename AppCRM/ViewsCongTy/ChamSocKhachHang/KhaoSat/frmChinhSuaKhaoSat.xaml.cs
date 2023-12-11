using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AppCRM.Views.ChamSocKhachHang.KhaoSat
{
    /// <summary>
    /// Interaction logic for frmChinhSuaKhaoSat.xaml
    /// </summary>
    public partial class frmChinhSuaKhaoSat : UserControl
    {
        public frmChinhSuaKhaoSat()
        {
            InitializeComponent();
        }
        ObservableCollection<string> _lst = new ObservableCollection<string>();
        public ObservableCollection<string> lst { get => _lst; set { _lst = value; } }
        private void txtThemTuyChon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lst.Add("1");
        }

        private void chonLoaiCauHoi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            frame_LoaiCauHoi.Visibility = Visibility.Visible;
            tracNghiem.Visibility = Visibility.Collapsed;
            tuLuan.Visibility = Visibility.Collapsed;
            frame_LoaiCauHoi.NavigationService.Navigate(new ChonLoaiCauHoi(this));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            bd_Huy.Background = Brushes.Red;
            tbl_Huy.Foreground = Brushes.White;
        }

        private void bd_Huy_MouseLeave(object sender, MouseEventArgs e)
        {
            bd_Huy.Background = Brushes.White;
            tbl_Huy.Foreground = Brushes.Red;
        }

        private void bd_Luu_MouseEnter(object sender, MouseEventArgs e)
        {
            bd_Luu.Background = Brushes.Blue;
            tbl_Luu.Foreground = Brushes.White;
        }

        private void bd_Luu_MouseLeave(object sender, MouseEventArgs e)
        {
            bd_Luu.Background = Brushes.White;
            tbl_Luu.Foreground = Brushes.Blue;
        }
    }
}
